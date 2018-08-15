using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;
using Mirror.Models;

namespace Mirror.Events
{
    public static class PushAppearanceChanges
    {
        public static void Event(Client client, params object[] args)
        {
            if (!client.HasData("Mirror_Appearance"))
                return;

            if (!(client.GetData("Mirror_Appearance") is Appearance app))
                return;

            // 0 - 5
            app.FatherAttributes = new double[] { Convert.ToDouble(args[1]), Convert.ToDouble(args[4]) };
            app.MotherAttributes = new double[] { Convert.ToDouble(args[2]), Convert.ToDouble(args[5]) };
            app.ThirdAttributes = new double[] { Convert.ToDouble(args[3]), Convert.ToDouble(args[6]) };

            
            // 6 - 8 Last: Third blend Amount
            app.SkinBlendAttributes = new float[] { Convert.ToSingle(args[7]), Convert.ToSingle(args[8]), Convert.ToSingle(args[9]) };

            for (int i = 10; i < 30; i++)
            {
                app.FacialFeatures[i - 10] = Convert.ToSingle(args[i]);
            }
            
            // Hair, Texture, Color, Highlight
            for (int i = 30; i < 34; i++)
            {
                app.Hair[i - 30] = Convert.ToInt32(args[i]);
            }

            app.EyeColor = Convert.ToInt32(args[34]);

            app.Update();
            app.UpdateAppearance(client);
        }
    }
}
