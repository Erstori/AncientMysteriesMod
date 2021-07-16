﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AncientMysteries.Utilities
{
    public static class Math2
    {
        public static Vec2 GetVectorFromDegress(float degress, float speed = 1f)
        {
            return Maths.AngleToVec(Maths.DegToRad(degress)) * speed;
        }
    }
}