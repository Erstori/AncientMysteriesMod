﻿using AncientMysteries.AmmoTypes;
using AncientMysteries.Localization.Enums;
using AncientMysteries.Utilities;
using DuckGame;
using static AncientMysteries.groupNames;

namespace AncientMysteries.Items.MachineGuns
{
    [EditorGroup(g_rifles)]
    public sealed class Iridescence : AMGun
    {
        public override string GetLocalizedName(AMLang lang) => lang switch
        {
            AMLang.schinese => "斑驳溢彩",
            _ => "Iridescence",
        };

        public Iridescence(float xval, float yval) : base(xval, yval)
        {
            this.ammo = 500;
            this._ammoType = new AT_Iridescence()
            {

            };
            this._type = "gun";
            this.ReadyToRunMap("rainbowGun.png");
            this._barrelOffsetTL = new Vec2(33f, 6f);
            BarrelSmoke.color = Color.White;
            this._fireSound = "laserRifle";
            this._fireWait = 0.6f;
            this._fireSoundPitch = 0.9f;
            this._kickForce = 0.25f;
            this._fullAuto = true;
            loseAccuracy = 0.01f;
            maxAccuracyLost = 0.02f;
            _holdOffset = new Vec2(-2.5f, 0.2f);
        }

        public override void Update()
        {
            base.Update();
            var color = HSL.FromHslFloat(Rando.Float(1), Rando.Float(0.1f, 0.9f), Rando.Float(0.45f, 0.65f));
            _flare.color = color;
        }
    }
}
