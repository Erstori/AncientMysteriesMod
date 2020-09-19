﻿using AncientMysteries.Bullets;
using DuckGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AncientMysteries.AmmoTypes
{
    public sealed class AT_Current : AmmoType
    {
        public AT_Current()
        {
            range = 400f;
            rangeVariation = 10f;
            //sprite.CenterOrigin();
            accuracy = 1f;
            penetration = 1f;
            bulletSpeed = 5f;
            bulletThickness = 0.3f;
            rebound = true;
            bulletType = typeof(LaserBullet);
            bulletColor = Color.Yellow;
        }

        public override Bullet FireBullet(Vec2 position, Thing owner = null, float angle = 0, Thing firedFrom = null)
        {
            return base.FireBullet(position, owner, angle, firedFrom);
        }
    }
}
