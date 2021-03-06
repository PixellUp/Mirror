using System;
using System.Collections.Generic;
using GTANetworkAPI;
using Mirror.Classes.Models;
using Newtonsoft.Json;

namespace Mirror
{
    public class Startup : Script
    {
        public Startup()
        {
            Settings.Settings.Initialize();
            Levels.LevelSystem.InitializeLevels(100);
            TransactionProccess.Initialize();
            MaleValidTopConfiguration.Initialize();
            FemaleValidTopConfiguration.Initialize();
        }
    }
}