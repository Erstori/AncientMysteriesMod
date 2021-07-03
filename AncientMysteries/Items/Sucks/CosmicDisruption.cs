﻿namespace AncientMysteries.Items.Sucks
{
    [EditorGroup(g_wtf)]
    public sealed class CosmicDisruption : AMGun
    {
        public override string GetLocalizedName(AMLang lang) => lang switch
        {
            _ => "Cosmic Disruption",
        };

        public CosmicDisruption(float xval, float yval) : base(xval, yval)
        {
            ammo = byte.MaxValue;
            _ammoType = new CosmicDisruption_AmmoType();
            _type = "gun";
            this.ReadyToRunMap("rainbowGun.png");
            _barrelOffsetTL = new Vec2(33f, 6f);
            BarrelSmoke.color = Color.White;
            _fireSound = "laserRifle";
            _fireWait = 0f;
            _fireSoundPitch = 0.9f;
            _kickForce = 0f;
            _fullAuto = true;
            loseAccuracy = 1f;
            maxAccuracyLost = 1f;
            _holdOffset = new Vec2(-2.5f, 0.2f);
        }

        public override void Update()
        {
            ammo = byte.MaxValue;
            base.Update();
        }
    }
}