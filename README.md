# Mirror
Open Source Roleplay Framework for RAGE.MP based on Pathfinder D&amp;D Systems

----

Here's what you need to know. This repository has three other Repositories that start with `mirror`.

There is no current login system as it was deprecated when I was moving over to Scatter integration.

I've since removed the scatter integration and now there just isn't a login system implemented.

----

What this uses:

* BCrypt-Core
* LiteDB

----

# How can I get this running?

Start with the server-side code first. It has to be compiled into a `.dll` for it to run.

Work with the client-side code next. You'll need to hook the client-side into the server-side and create a login system.

----

How to create an account:

```
Account account = new Account();
account.Create(..., ... , ..)
```

How to login:
```
// ... Fetch the account from the Database see the account.Create method for more on it.

account.Attach(client)
```






