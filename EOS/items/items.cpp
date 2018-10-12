#include "items.hpp"

namespace MirrorItems {
    void Items::issueitem( account_name account, uint64_t key, string itemname, string type, string properties ) {
        require_auth( _self );

        print("Got here...");

        eosio_assert( account != _self, "Cannot transfer to self");

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
            print("Tried adding...");
            additem( _self , account, key, itemname, type, properties);
        }
    }

    void Items::additem( account_name from, account_name to, uint64_t key, string itemname, string type, string properties ) {
        eosio_assert( from != to, "Cannot transfer to self.");
        eosio_assert( from == _self, "Cannot create item.");

        print("Something...");

        require_recipient( from );
        require_recipient( to );

        eosio_assert( is_account( to ), "Account does not exist");

        accountindex accounts( _self, _self );
        auto foundAccount = accounts.find( to );

        print("Went Wrong...");

        eosio_assert( foundAccount != accounts.end(), "Account doesn't exist.");

        print("Here...");

        accounts.modify( foundAccount, _self, [&](auto& acc) {
            acc.items.push_back(accitems {
                key,
                itemname,
                type,
                properties
            });
        });

        print("FUCK...");
    }

    void Items::consumeitem( account_name account, uint64_t key ) {
        require_auth( account );
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

            // Make sure the item actually exists.
            eosio_assert(foundItem != acc.items.end(), "Item not found.");
            
            // Determine the index.
            int index = distance(acc.items.begin(), foundItem);
            
            // Add to queue.
            addtoqueue( account, acc.items.at(index) );

            // Remove from player's items.
            acc.items.erase(acc.items.begin() + index);
        });
    }

    void Items::remqueue( account_name account, uint64_t key, string memo ) {
        require_auth( _self );

        queueindex queue(_self, _self);
        auto foundAccount = queue.find( account );

        eosio_assert(foundAccount != queue.end(), "Account doesn't have any queued items.");

        queue.modify(foundAccount, 0, [&](auto& q) {
            auto foundItem = find_if(q.items.begin(), q.items.end(), [=] (accitems const& itemHelper) {
                return (itemHelper.key == key);
            });

            eosio_assert(foundItem != q.items.end(), "Item not found.");

            int index = distance(q.items.begin(), foundItem);

            q.items.erase(q.items.begin() + index);
        });
    }

    void Items::addtoqueue( account_name account, accitems item ) {
        queueindex queue( _self, _self );
        auto foundAccount = queue.find( account );

        // If account is not found...
        if (foundAccount == queue.end()) {
            queue.emplace( _self, [&](auto& q) {
                q.owner = account;
                q.items.push_back(item);
            });
        } else {
            queue.modify( foundAccount, 0, [&](auto& q) {
                q.items.push_back(item);
            });
        }
    }
}