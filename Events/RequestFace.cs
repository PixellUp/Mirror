﻿using GTANetworkAPI;
using Mirror.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Mirror.Events
{
    public static class RequestFace
    {
        public static void Event(Client client, params object[] args)
        {
            if (!(client.GetData("Mirror_Appearance") is Appearance app))
                return;
            
            double[] faceValues = new double[] {
                app.FatherAttributes[0],
                app.MotherAttributes[0],
                app.ThirdAttributes[0],
                app.FatherAttributes[1],
                app.MotherAttributes[1],
                app.ThirdAttributes[1],
                app.SkinBlendAttributes[0],
                app.SkinBlendAttributes[1],
                app.SkinBlendAttributes[2],
                app.FacialFeatures[0],
                app.FacialFeatures[1],
                app.FacialFeatures[2],
                app.FacialFeatures[3],
                app.FacialFeatures[4],
                app.FacialFeatures[5],
                app.FacialFeatures[6],
                app.FacialFeatures[7],
                app.FacialFeatures[8],
                app.FacialFeatures[9],
                app.FacialFeatures[10],
                app.FacialFeatures[11],
                app.FacialFeatures[12],
                app.FacialFeatures[13],
                app.FacialFeatures[14],
                app.FacialFeatures[15],
                app.FacialFeatures[16],
                app.FacialFeatures[17],
                app.FacialFeatures[18],
                app.FacialFeatures[19],
                app.Hair[0],
                app.Hair[1],
                app.Hair[2],
                app.Hair[3],
                app.EyeColor[0]
            };

            string facialJson = JsonConvert.SerializeObject(faceValues);

            double[][] overlayValues = new double[][]
            {
                app.Blemish,
                app.FacialHair,
                app.Eyebrows,
                app.Age,
                app.Makeup,
                app.Blush,
                app.Complexion,
                app.SunDamage,
                app.Lipstick,
                app.Moles,
            };

            string overlayJson = JsonConvert.SerializeObject(overlayValues);

            client.TriggerEvent("RecieveFace", facialJson, overlayJson);
        }
    }
}
