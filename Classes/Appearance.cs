using System;
using System.Collections.Generic;
using System.Text;

namespace Mirror.Classes
{
    public class Appearance : StandardData
    {
        public int Father { get; set; } = 0;
        public int Mother { get; set; } = 0;
        public int FatherSkin { get; set; } = 0;
        public int MotherSkin { get; set; } = 0;
        public float FaceBlend { get; set; } = 1f;
        public float SkinBlend { get; set; } = 1f;
        public int Blemishes { get; set; } = 0;
        public int Ageing { get; set; } = 0;
        public int Complexion { get; set; } = 0;
        public int SunDamage { get; set; } = 0;
        public int Moles { get; set; } = 0;
        public int BodyBlemishes { get; set; } = 0;
        public int Hair { get; set; } = 0;
        public int HairColor { get; set; } = 0;
        public int HairHighlight { get; set; } = 0;
        public int FacialHair { get; set; } = 0;
        public int FacialHairColor { get; set; } = 0;
        public float FacialHairOpacity { get; set; } = 1f;
        public int Eyebrow { get; set; } = 0;
        public int EyebrowColor { get; set; } = 0;
        public float EyebrowOpacity { get; set; } = 1f;
        public int Makeup { get; set; } = 0;
        public float MakeupOpacity { get; set; } = 1f;
        public int Facepaint { get; set; } = 0;
        public float FacepaintOpacity { get; set; } = 1f;
        public int Lipstick { get; set; } = 0;
        public int LipstickColor { get; set; } = 0;
        public float LipstickOpacity { get; set; } = 1f;
        public int ChestHair { get; set; } = 0;
        public int ChestHairColor { get; set; }
        public float ChestHairOpacity { get; set; } = 1f;
        public int EyeColor { get; set; } = 0;
    }
}
