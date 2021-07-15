﻿namespace AncientMysteries.Items.Common
{
    [EditorGroup(g_commons)]
    public class Umbrella : AMNotGun, IPlatform
    {
        //public StateBinding _openedBinding = new StateBinding("_opened");

        public bool _opened = false;

        public override string GetLocalizedName(AMLang lang) => lang switch
        {
            _ => "Umbrella",
        };

        public Umbrella(float xval, float yval) : base(xval, yval)
        {
            this.ReadyToRunMap(t_Holdable_UmbrellaClosed);
            thickness = 1.5f;
            flammable = 1f;
            physicsMaterial = PhysicsMaterial.Rubber;
            _holdOffset = new Vec2(-4, -7);
        }

        public override void Update()
        {
            base.Update();
            if (duck is Duck d)
            {
                if (!_opened)
                {
                    _opened = true;
                    this.ReadyToRunMap(t_Holdable_UmbrellaOpen);
                }
                handAngle = 0;

                if (d.crouch || _triggerHeld)
                {
                    handAngle = -1.56f * -offDir;
                    _holdOffset = new Vec2(-10 , -5);
                    handOffset = new Vec2(0, -4);
                }
                else
                {
                    if (d._hovering)
                    {
                        handAngle = -1.56f * -offDir;
                    }
                    if (d.vSpeed >= 0f)
                    {
                        if (d.vSpeed > 0.4f)
                        {
                            d.vSpeed = 0.4f;
                        }
                        d.vSpeed -= 0.15f;
                    }
                    _holdOffset = new Vec2(-4, -7);
                    handOffset = Vec2.Zero;
                }
            }
            else
            {
                if (_opened)
                {
                    _opened = false;
                    this.ReadyToRunMap(t_Holdable_UmbrellaClosed);
                }
            }
        }

        public override bool Hit(Bullet bullet, Vec2 hitPos)
        {
            return false;
        }
    }
}
