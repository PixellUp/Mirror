using GTANetworkAPI;
using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Commands
{
    public class Sandbox : Script
    {
        [Command("cv")]
        public void CreateVehicle(Client client, string value)
        {
            VehicleHash veh = (VehicleHash)Enum.Parse(typeof(VehicleHash), value);
            Vehicle newVeh = NAPI.Vehicle.CreateVehicle(veh, client.Position.Around(5), 0, 45, 45, "TESTING", 255, false, true);
        }

        [Command("time")]
        public void SetTime(Client client, int hour)
        {
            NAPI.World.SetTime(hour, 0, 0);
        }

        [Command("update")]
        public void UpdateClothing(Client client)
        {
            if (!client.HasData("Mirror_Account"))
                return;

            Account acc = client.GetData("Mirror_Account") as Account;

            Appearance app = Appearance.RetrieveAppearance(acc);
            app.Attach(client);

            Clothing clothing = Clothing.RetrieveClothing(acc);
            clothing.Attach(client);
        }

        [Command("setpoint")]
        public void CmdSetPoint(Client client, string type, int radius = 5)
        {
            Location.CreatePosition(client, type, radius);
        }


        [RemoteEvent("createTopFemale")]
        public void CreateTopSandbox(Client client, params object[] args)
        {
            FemaleValidTopConfiguration.Create(Convert.ToInt32(args[0]), Convert.ToInt32(args[1]), Convert.ToInt32(args[2]));
        }

        [RemoteEvent("createTopMale")]
        public void CreateTopMaleSandbox(Client client, params object[] args)
        {
            MaleValidTopConfiguration.Create(Convert.ToInt32(args[0]), Convert.ToInt32(args[1]), Convert.ToInt32(args[2]));
        }
    }
}
