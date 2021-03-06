﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Utility
{
    public static class Exceptions
    {
        public const string Prefix = "";
        public const string AccountHasBeenRegistered = Prefix + "Account has been registered.";
        public const string AccountUsernameNotLongEnough = Prefix + "Account username is not long enough. Minimum 5 length.";
        public const string AccountPlayerNameIncorrectFormat = Prefix + "Player name has incorrect format.";
        public const string AccountAlreadyExists = Prefix + "This email already has an account.";
        public const string AccountPasswordNotLongEnough = Prefix + "Account password is not long enough. Minimum is 6.";

        public const string LoginAccountCredentialsInvalid = Prefix + "Account credentials are invalid.";
        public const string LoginAccountAlreadyLoggedIn = Prefix + "Account is already logged in.";
        public const string LoginNullException = Prefix + "Invalid Account. Notify an Admin. 0x001ACC";
        public const string LoginAccountIsBanned = Prefix + "Account has been flagged as banned.";
        public const string LoginSuccess = Prefix + "Account verified. Loading account details...";
        public const string LoginLoadedClothing = Prefix + "Loaded clothing...";
        public const string LoginLoadedAppearance = Prefix + "Loaded appearance...";
        public const string LoginLoadedSkills = Prefix + "Loaded skills...";

        public const string MoneyUserNotFound = Prefix + "User was not found...";
        public const string MoneyNotEnoughBalance = Prefix + "Not enough balance to transfer.";

        public const string UtilityMoneyLoaded = Prefix + "Loaded existing monetary system.";
        public const string UtilityMoneyEstablished = Prefix + "Created monetary system.";
    }
}
