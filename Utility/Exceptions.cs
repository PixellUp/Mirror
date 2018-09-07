using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Utility
{
    public static class Exceptions
    {
        public const string Prefix = "[Mirror] -> ";
        public const string AccountHasBeenRegistered = Prefix + "Account has been registered.";
        public const string AccountUsernameNotLongEnough = Prefix + "Account username is not long enough. Minimum 4 length.";
        public const string AccountPlayerNameIncorrectFormat = Prefix + "Account player name is in incorrect format. Try a name similar to John_Doe";
        public const string AccountAlreadyExists = Prefix + "Account could not be created. ~o~Try a different username or player name.";
        public const string AccountPasswordNotLongEnough = Prefix + "Account password is not long enough. Minimum is 6.";

        public const string LoginAccountCredentialsInvalid = Prefix + "Account credentials are invalid.";
        public const string LoginAccountAlreadyLoggedIn = Prefix + "Account is already logged in.";
        public const string LoginNullException = Prefix + "Invalid Account. Notify an Admin. 0x001ACC";
        public const string LoginAccountIsBanned = Prefix + "Account has been flagged as banned.";
        public const string LoginSuccess = Prefix + "Account verified. Loading account details...";
        public const string LoginLoadedClothing = Prefix + "Loaded clothing...";
        public const string LoginLoadedAppearance = Prefix + "Loaded appearance...";
        public const string LoginLoadedSkills = Prefix + "Loaded skills...";

        public const string UtilityMoneyLoaded = Prefix + "Loaded existing monetary system.";
        public const string UtilityMoneyEstablished = Prefix + "Created monetary system.";
    }
}
