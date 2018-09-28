#include "items.hpp"

namespace MirrorItems {
    void Items::issueitem( account_name account, uint64_t key, string itemname, string type, string properties ) {
        require_auth( _self );

        accountindex accounts( _self, _self );
        auto foundAccount = accounts.find( account );

        // If account is not found...
        if (foundAccount == accounts.end()) {
            accounts.emplace( _self, [&](auto& acc) {
                acc.owner = account;
                acc.items.push_back(accitems {
                    key,
                    itemname,
                    type,
                    properties
                });
                acc.vehicles.push_back(accvehicle {
                    0,
                    "emperor2",
                    "emperor2",
                    0,
                    0,
                    0
                });
            });
        } else {
            additem( _self , account, key, itemname, type, properties);
        }
    }

    void Items::additem( account_name from, account_name to, uint64_t key, string itemname, string type, string properties ) {
        eosio_assert( from != to, "Cannot transfer to self.");
        eosio_assert( from == _self, "Cannot create item.");

        require_auth( from );
        require_recipient( from );
        require_recipient( to );

        eosio_assert( is_account( to ), "Account does not exist");

        accountindex accounts( _self, _self );
        auto foundAccount = accounts.find( to );

        eosio_assert( foundAccount != accounts.end(), "Account doesn't exist.");

        accounts.modify( foundAccount, 0, [&](auto& acc) {
            acc.items.push_back(accitems {
                key,
                itemname,
                type,
                properties
            });
        });
    }

    void Items::consumeitem( account_name account, uint64_t key ) {
        require_auth( account );

        eosio::print("The fuck");

        deleteitem( account, key );
    }

    void Items::deleteitem( account_name account, uint64_t key ) {
        accountindex accounts( _self, _self );
        auto foundAccount = accounts.find( account );

        eosio_assert(foundAccount != accounts.end(), "Account doesn't exist.");

        accounts.modify(foundAccount, account, [&](auto& acc) {
            auto foundItem = find_if(acc.items.begin(), acc.items.end(), [=] (accitems const& itemHelper) {
                return (itemHelper.key == key);
            });

            eosio_assert(foundItem != acc.items.end(), "Item not found.");

            int index = distance(acc.items.begin(), foundItem);
            acc.items.erase(acc.items.begin() + index);
        });
    }
}