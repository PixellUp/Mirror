using GTANetworkAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes
{
    public class Appearance : StandardData
    {
        public int Father { get; set; } = 16;
        public int Mother { get; set; } = 44;
        public int FatherSkin { get; set; } = 16;
        public int MotherSkin { get; set; } = 20;
        public float FaceBlend { get; set; } = 0.5f;
        public float SkinBlend { get; set; } = 0.5f;
        public int Blemishes { get; set; } = 0;
        public float BlemishOpacity { get; set; } = 0.5f;
        public int Ageing { get; set; } = 0;
        public float AgeingOpacity { get; set; } = 0.5f;
        public int Complexion { get; set; } = 0;
        public float ComplexionOpacity { get; set; } = 0.5f;
        public int SunDamage { get; set; } = 0;
        public float SunDamageOpacity { get; set; } = 0.5f;
        public int Moles { get; set; } = 0;
        public float MolesOpacity { get; set; } = 0.5f;
        public int BodyBlemishes { get; set; } = 0;
        public float BodyBlemishOpacity { get; set; } = 0.5f;
        public int Hair { get; set; } = 3;
        public int HairColor { get; set; } = 0;
        public int HairHighlight { get; set; } = 0;
        public int FacialHair { get; set; } = 0;
        public int FacialHairColor { get; set; } = 0;
        public float FacialHairOpacity { get; set; } = 0.5f;
        public int Eyebrow { get; set; } = 0;
        public int EyebrowColor { get; set; } = 0;
        public float EyebrowOpacity { get; set; } = 0.5f;
        public int Makeup { get; set; } = 0;
        public float MakeupOpacity { get; set; } = 0.5f;
        public int Facepaint { get; set; } = 0;
        public float FacepaintOpacity { get; set; } = 0.5f;
        public int Lipstick { get; set; } = 0;
        public int LipstickColor { get; set; } = 0;
        public float LipstickOpacity { get; set; } = 0.5f;
        public int ChestHair { get; set; } = 0;
        public int ChestHairColor { get; set; }
        public float ChestHairOpacity { get; set; } = 0.5f;
        public int EyeColor { get; set; } = 0;

        public void LoadAppearanceData(Client client)
        {
            NAPI.Player.SetPlayerHeadBlend(client, new HeadBlend()
            {
                ShapeFirst = (byte)Father,
                ShapeSecond = (byte)Mother,
                SkinFirst = (byte)FatherSkin,
                SkinSecond = (byte)MotherSkin,
                ShapeMix = (byte)FaceBlend,
                SkinMix = (byte)SkinBlend,
            });

            NAPI.Player.SetPlayerClothes(client, 2, Hair, 0);

            NAPI.Player.SetPlayerHairColor(client, (byte)HairColor, (byte)HairHighlight);

            NAPI.Player.SetPlayerEyeColor(client, (byte)EyeColor);

            NAPI.Player.SetPlayerHeadOverlay(client, 0, new HeadOverlay()
            {
                Index = (byte)Blemishes,
                Opacity = (byte)BlemishOpacity
            });

            NAPI.Player.SetPlayerHeadOverlay(client, 1, new HeadOverlay()
            {
                Index = (byte)FacialHair,
                Color = (byte)FacialHairColor,
                Opacity = (byte)FacialHairOpacity
            });

            NAPI.Player.SetPlayerHeadOverlay(client, 2, new HeadOverlay()
            {
                Index = (byte)Eyebrow,
                Opacity = (byte)EyebrowOpacity,
                Color = (byte)EyebrowColor
            });

            NAPI.Player.SetPlayerHeadOverlay(client, 3, new HeadOverlay()
            {
                Index = (byte)Ageing,
                Opacity = (byte)AgeingOpacity
            });

            NAPI.Player.SetPlayerHeadOverlay(client, 4, new HeadOverlay()
            {
                Index = (byte)Makeup,
                Opacity = (byte)MakeupOpacity
            });

            NAPI.Player.SetPlayerHeadOverlay(client, 6, new HeadOverlay()
            {
                Index = (byte)Complexion,
                Opacity = (byte)ComplexionOpacity
            });

            NAPI.Player.SetPlayerHeadOverlay(client, 7, new HeadOverlay()
            {
                Index = (byte)SunDamage,
                Opacity = (byte)SunDamageOpacity
            });

            NAPI.Player.SetPlayerHeadOverlay(client, 8, new HeadOverlay()
            {
                Index = (byte)Lipstick,
                Opacity = (byte)LipstickOpacity,
                Color = (byte)LipstickColor
            });

            NAPI.Player.SetPlayerHeadOverlay(client, 9, new HeadOverlay()
            {
                Index = (byte)Moles,
                Opacity = (byte)MolesOpacity
            });

            NAPI.Player.SetPlayerHeadOverlay(client, 10, new HeadOverlay()
            {
                Index = (byte)ChestHair,
                Opacity = (byte)ChestHairOpacity
            });

            NAPI.Player.SetPlayerHeadOverlay(client, 11, new HeadOverlay()
            {
                Index = (byte)BodyBlemishes,
                Opacity = (byte)BodyBlemishOpacity
            });
        }
    }
}
