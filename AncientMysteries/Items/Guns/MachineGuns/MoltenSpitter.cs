﻿namespace AncientMysteries.Items.Guns.MachineGuns
{
    [EditorGroup(g_machineGuns)]
    [MetaImage(t_)]
    [MetaInfo(Lang.english, "Molten Spitter", "desc")]
    [MetaInfo(Lang.schinese, "", "")]
    public sealed partial class MoltenSpitter : AMGun
    {
        public StateBinding _animationFrameBinding = new(nameof(AnimationFrame));

        public SpriteMap _spriteMap;

        public byte AnimationFrame
        {
            get => (byte)_spriteMap._frame;
            set => _spriteMap._frame = value;
        }

        public override string GetLocalizedName(Lang lang) => lang switch
        {
            Lang.schinese => "熔能喷吐",
            _ => "Molten Spitter",
        };
        public override string GetLocalizedDescription(Lang lang) => lang switch
        {
            Lang.schinese => "「像你这样的鸭子，就该在地狱里焚烧」",
            _ => "「Ducks like you, should be burning in hell」",
        };
        public MoltenSpitter(float xval, float yval) : base(xval, yval)
        {
            ammo = 127;
            _ammoType = new MoltenSpitter_AmmoType();
            _type = "gun";
            _spriteMap = this.ReadyToRunWithFrames(t_Gun_MoltenSpitter, 39, 15);
            SetBox(39, 13);
            BarrelSmokeFuckOff();
            _fireSound = "smg";
            _fireSoundPitch = -0.9f;
            _fireWait = 0.6f;
            _kickForce = 2.3f;
            _fullAuto = true;
            _numBulletsPerFire = 2;
            weight = 10f;
            _holdOffset = new Vec2(9f, 2f);
            _spriteMap.AddAnimation("out", 0.2f, false, 0, 1, 2);
            _spriteMap.AddAnimation("back", 0.2f, false, 2, 1, 0);
        }

        public override void Update()
        {
            _barrelOffsetTL = new Vec2(_spriteMap._frame switch
            {
                2 => 38,
                _ => 35,
            }, 9f);
            _spriteMap.SetAnimation(duck != null ? "out" : "back");
            base.Update();
        }
    }
}
