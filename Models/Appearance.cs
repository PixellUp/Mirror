using GTANetworkAPI;
using Mirror.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Models
{
    public enum Sex
    {
        Male,
        Female
    }

    public class Appearance : StandardData
    {
        // Sex
        public Sex Sex { get; set; } = Sex.Male;
        // Face Number, Skin Number
        public double[] FatherAttributes { get; set; } = new double[] { 0, 0 };
        public double[] MotherAttributes { get; set; } = new double[] { 0, 0 };
        public double[] ThirdAttributes { get; set; } = new double[] { 0, 0 };
        // Blend Data, Shape + Skin
        public float[] SkinBlendAttributes { get; set; } = new float[] { 0.5f, 0.5f, 0.5f };
        // Overlays: Slot, Color, Opacity
        public double[] Blemish { get; set; } = new double[] { 0, 0, 0.0 }; // 0
        public double[] FacialHair { get; set; } = new double[] { 0, 0, 0.0 };
        public double[] Eyebrows { get; set; } = new double[] { 0, 0, 0.0 };
        public double[] Age { get; set; } = new double[] { 0, 0, 0.0 };
        public double[] Makeup { get; set; } = new double[] { 0, 0, 0.0 };
        public double[] Blush { get; set; } = new double[] { 0, 0, 0.0 };
        public double[] Complexion { get; set; } = new double[] { 0, 0, 0.0 };
        public double[] SunDamage { get; set; } = new double[] { 0, 0, 0.0 };
        public double[] Lipstick { get; set; } = new double[] { 0, 0, 0.0 };
        public double[] Moles { get; set; } = new double[] { 0, 0, 0.0 };
        public double[] ChestHair { get; set; } = new double[] { 0, 0, 0.0 };
        public double[] BodyBlemish { get; set; } = new double[] { 0, 0, 0.0 };
        // Hair, Texture, Color, Highlight
        public int[] Hair { get; set; } = new int[] { 0, 0, 0, 0 };
        // Literally Eye Color
        public int[] EyeColor { get; set; } = new int[] { 0 };
        // Facial Features
        public float[] FacialFeatures { get; set; } = new float[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        public void Create(int id)
        {
            UserID = id;
            DatabaseUtilities.Upsert(this);
        }

        public void Attach(Client client)
        {
            UpdateAppearance(client);
        }

        public void Update()
        {
            DatabaseUtilities.UpdateData(this);
        }

        /// <summary>
        ///  Update the player's appearance.
        /// </summary>
        /// <param name="client"></param>
        public void UpdateAppearance(Client client)
        {
            // Attach the data to the player.
            client.SetData("Mirror_Appearance", this);

            // Update Character Model
            if (this.Sex.ToString() == "Female")
                client.SetSkin(PedHash.FreemodeFemale01);

            if (this.Sex.ToString() == "Male")
                client.SetSkin(PedHash.FreemodeMale01);

            // Face Details
            NAPI.Player.SetPlayerHeadBlend(client, new HeadBlend()
            {
                ShapeFirst = (byte)FatherAttributes[0],
                ShapeSecond = (byte)MotherAttributes[0],
                ShapeThird = (byte)ThirdAttributes[0],
                SkinFirst = (byte)FatherAttributes[1],
                SkinSecond = (byte)MotherAttributes[1],
                SkinThird = (byte)ThirdAttributes[1],
                ShapeMix = Convert.ToSingle(SkinBlendAttributes[0]),
                SkinMix = Convert.ToSingle(SkinBlendAttributes[1]),
                ThirdMix = Convert.ToSingle(SkinBlendAttributes[2])
            });

            // Facial Features
            for (int i = 0; i < FacialFeatures.Length; i++)
            {
                NAPI.Player.SetPlayerFaceFeature(client, i, FacialFeatures[i]);
            }

            // 11 Overlay Slots
            double[][] overlays = new double[][] { Blemish, FacialHair, Eyebrows, Age, Makeup, Blush, Complexion, SunDamage, Lipstick, Moles, ChestHair, BodyBlemish };
            for (int i = 0; i < overlays.Length; i++)
            {
                NAPI.Player.SetPlayerHeadOverlay(client, i, new HeadOverlay()
                {
                    Index = (byte)Convert.ToSingle(overlays[i][0]),
                    Color = (byte)Convert.ToSingle(overlays[i][1]),
                    Opacity = Convert.ToSingle(overlays[i][2])
                });
            }

            // Face
            NAPI.Player.SetPlayerClothes(client, 2, Hair[0], Hair[1]);
            NAPI.Player.SetPlayerHairColor(client, (byte)Hair[2], (byte)Hair[3]);
            NAPI.Player.SetPlayerEyeColor(client, (byte)EyeColor[0]);

            client.SetSharedData("Mirror_Appearance_JSON", JsonConvert.SerializeObject(this));
        }

        /// <summary>
        /// Retrieve the character's appearance settings.
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        public static Appearance RetrieveAppearance(Account account)
        {
            return DatabaseUtilities.GetById<Appearance>(account.UserID);
        }
    }


}
