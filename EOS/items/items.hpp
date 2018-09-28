#include <eosiolib/eosio.hpp>
#include <eosiolib/print.hpp>
#include <string>
#include <tuple>
#include <algorithm>

namespace MirrorItems {
    using namespace eosio;
    using std::string;

    class Items : public contract {
        using contract::contract;

        public:
            Items(account_name _self ):contract( _self ) {}

            [[eosio::action]]
            void issueitem(account_name account, uint64_t key, string itemname, string type, string properties);

            [[eosio::action]]
            void removeitem( account_name account, uint64_t key );

            [[eosio::action]]
            void consumeitem( account_name account, uint64_t key );

            struct [[eosio::table]] accitems {
                uint64_t key;
                string name;
                string type;
                string properties;

                uint64_t primary_key() const { return key; }

                EOSLIB_SERIALIZE(accitems, (key)(name)(type)(properties))
            };

            struct [[eosio::table]] accvehicle {
                uint64_t key;
                string name;
                string type;
                uint64_t x;
                uint64_t y;
                uint64_t z;

                uint64_t primary_key() const { return key; }
                EOSLIB_SERIALIZE(accvehicle, (key)(name)(type)(x)(y)(z))
            };

            struct [[eosio::table]] acctable {
                account_name owner;
                vector<accitems> items;
                vector<accvehicle> vehicles;

                uint64_t primary_key() const { return owner; }
                EOSLIB_SERIALIZE(acctable, (owner)(items)(vehicles))
            };

            typedef multi_index<N(acctable), acctable> accountindex;

        private:
            void additem(account_name from, account_name to, uint64_t key, string itemname, string type, string properties);
            void deleteitem( account_name target, uint64_t key );
    };

    EOSIO_ABI(Items, (issueitem)(removeitem))
}