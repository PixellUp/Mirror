using GTANetworkAPI;
using Mirror.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Events
{
    public static class PushFacialChanges
    {
        public static void Event (Client client, params object[] args)
        {
            if (!client.HasData("Mirror_Appearance"))
                return;

            Appearance app = (Appearance)client.GetData("Mirror_Appearance");
            app.Blemish = new double[] { Convert.ToDouble(args[1]), Convert.ToDouble(args[2]), Convert.ToDouble(args[3]) };
            app.FacialHair = new double[] { Convert.ToDouble(args[4]), Convert.ToDouble(args[5]), Convert.ToDouble(args[6]) };
            app.Eyebrows = new double[] { Convert.ToDouble(args[7]), Convert.ToDouble(args[8]), Convert.ToDouble(args[9]) };
            app.Age = new double[] { Convert.ToDouble(args[10]), Convert.ToDouble(args[11]), Convert.ToDouble(args[12]) };
            app.Makeup = new double[] { Convert.ToDouble(args[13]), Convert.ToDouble(args[14]), Convert.ToDouble(args[15]) };
            app.Blush = new double[] { Convert.ToDouble(args[16]), Convert.ToDouble(args[17]), Convert.ToDouble(args[18]) };
            app.Complexion = new double[] { Convert.ToDouble(args[19]), Convert.ToDouble(args[20]), Convert.ToDouble(args[21]) };
            app.SunDamage = new double[] { Convert.ToDouble(args[22]), Convert.ToDouble(args[23]), Convert.ToDouble(args[24]) };
            app.Lipstick = new double[] { Convert.ToDouble(args[25]), Convert.ToDouble(args[26]), Convert.ToDouble(args[27]) };
            app.Moles = new double[] { Convert.ToDouble(args[28]), Convert.ToDouble(args[29]), Convert.ToDouble(args[30]) };

            app.Update();
            app.UpdateAppearance(client);
        }
    }
}
