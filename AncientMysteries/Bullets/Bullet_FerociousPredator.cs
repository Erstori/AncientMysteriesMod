﻿using DuckGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AncientMysteries.Bullets
{
    public class Bullet_FerociousPredato : Bullet
    {
        public Bullet_FerociousPredato(float xval, float yval, AmmoType type, float ang = -1, Thing owner = null, bool rbound = false, float distance = -1, bool tracer = false, bool network = true) : base(xval, yval, type, ang, owner, rbound, distance, tracer, network)
        {

        }

        public override void OnCollide(Vec2 pos, Thing t, bool willBeStopped)
        {
            if (!willBeStopped || !isLocal)
            {
                return;
            }
            for (int repeat = 0; repeat < 6; repeat++)
            {
                ExplosionPart ins = new ExplosionPart(pos.x - 8f + Rando.Float(32f), pos.y - 8f + Rando.Float(32f));
                ins.xscale = 3f;
                ins.yscale = 3f;
                Level.Add(ins);
            }
            SFX.Play("explode");
            List<Bullet> firedBullets = new List<Bullet>(24);
            Vec2 bPos = pos;
            bPos -= travelDirNormalized;
            for (int i = 0; i < 24; i++)
            {
                float dir = (float)i * 30f - 10f + Rando.Float(20f);
                ATGrenadeLauncherShrapnel shrap = new ATGrenadeLauncherShrapnel();
                shrap.range = 100f + Rando.Float(20f);
                Bullet bullet = new Bullet(bPos.x, bPos.y, shrap, dir);
                bullet.firedFrom = this;
                firedBullets.Add(bullet);
                Level.Add(bullet);
            }
            if (Network.isActive && isLocal)
            {
                NMFireGun gunEvent = new NMFireGun(null, firedBullets, 0, rel: false, 4);
                Send.Message(gunEvent, NetMessagePriority.ReliableOrdered);
                firedBullets.Clear();
            }
            IEnumerable<Window> windows = Level.CheckCircleAll<Window>(position, 20f);
            foreach (Window w in windows)
            {
                if (Level.CheckLine<Block>(position, w.position, w) == null)
                {
                    w.Destroy(new DTImpact(this));
                }
            }
        }
    }
}
