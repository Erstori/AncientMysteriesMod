﻿namespace AncientMysteries.Items.True
{
    public class Overgrowth_AmmoType_Big : AMAmmoType
    {
        public Overgrowth_AmmoType_Big()
        {
            sprite = t_OvergrowthBig.ModSprite();
            bulletSpeed = 4f;
            accuracy = 0.4f;
            speedVariation = 3f;
            bulletLength = 0f;
            rangeVariation = 50f;
            penetration = 1f;
            range = 180f;
            bulletType = typeof(Overgrowth_Bullet_Big);
        }
    }
}
