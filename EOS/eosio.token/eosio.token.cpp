/**
 *  @file
 *  @copyright defined in eos/LICENSE.txt
 */

#include "eosio.token.hpp"

namespace eosio {

void token::issue( account_name to, asset quantity, string memo )
{
    auto sym = quantity.symbol;
    eosio_assert( sym.is_valid(), "invalid symbol name" );
    eosio_assert( memo.size() <= 256, "memo too large" );

    auto sym_name = sym.name();
    stats statstable( _self, sym_name );
    auto existing = statstable.find( sym_name );
    eosio_assert( existing != statstable.end(), "symbol does not exist" );
    const auto& st = *existing;

    require_auth( st.issuer );
    eosio_assert( (quantity.is_valid()) && (quantity.amount > 0), "invalid quantity" );
    eosio_assert( quantity.symbol == st.supply.symbol, "symbol precision mismatch" );
    eosio_assert( quantity.amount <= st.max_supply.amount - st.supply.amount, "quantity exceeds available supply");
    
    statstable.modify( st, 0, [&]( auto& s ) {
       s.supply += quantity;
    });

    add_balance( st.issuer, quantity, st.issuer );

    if( to != st.issuer ) {
       SEND_INLINE_ACTION( *this, transfer, {st.issuer,N(active)}, {st.issuer, to, quantity, memo} );
    }
}

void token::transfer( account_name from,
                      account_name to,
                      asset        quantity,
                      string       memo )
{
    eosio_assert( from != to, "not to self" );
    require_auth( from );
    eosio_assert( is_account( to ), "to account invalid");
    auto sym = quantity.symbol.name();
    stats statstable( _self, sym );
    const auto& st = statstable.get( sym );

    require_recipient( from );
    require_recipient( to );

    eosio_assert( quantity.is_valid(), "quantity invalid" );
    eosio_assert( quantity.amount > 0, "not positive quantity" );
    eosio_assert( quantity.symbol == st.supply.symbol, "symbol precision mismatch" );
    eosio_assert( memo.size() <= 256, "memo too large" );

    if ( to != _self ) {
        asset taxAmount(quantity.amount * 0.05, S(2, MIRROR));
        quantity.amount -= taxAmount.amount;
        add_balance(_self, taxAmount, from);
    }

    sub_balance( from, quantity );
    add_balance( to, quantity, from );
}

void token::sub_balance( account_name owner, asset value ) {
   accounts from_acnts( _self, owner );

   const auto& from = from_acnts.get( value.symbol.name(), "no balance object found" );
   eosio_assert( from.balance.amount >= value.amount, "overdrawn balance" );

   if( from.balance.amount == value.amount ) {
      from_acnts.erase( from );
   } else {
      from_acnts.modify( from, owner, [&]( auto& a ) {
          a.balance -= value;
      });
   }
}

void token::add_balance( account_name owner, asset value, account_name ram_payer )
{
   accounts to_acnts( _self, owner );
   auto to = to_acnts.find( value.symbol.name() );
   if( to == to_acnts.end() ) {
      to_acnts.emplace( ram_payer, [&]( auto& a ){
        a.balance = value;
      });
   } else {
      to_acnts.modify( to, 0, [&]( auto& a ) {
        a.balance += value;
      });
   }
}

void token::additem( account_name owner, string receipt, string item)
{
    require_auth( _self );
    eosio_assert( is_account( owner ), "to account invalid");
    require_recipient( owner );

    items items( _self, _self );

    items.emplace(owner, [&](auto& item_receipts) {
        item_receipts.owner = owner;
        item_receipts.receipt = receipt;
        item_receipts.item = item;
    });
}

} /// namespace eosio

EOSIO_ABI( eosio::token, (additem)(issue)(transfer))
