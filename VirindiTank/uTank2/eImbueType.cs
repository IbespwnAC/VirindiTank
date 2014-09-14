namespace uTank2
{
    using System;

    [Flags]
    public enum eImbueType
    {
        AcidRend = 0x40,
        ArmorRend = 4,
        BludgeonRend = 0x20,
        ColdRend = 0x80,
        CripplingBlow = 2,
        CriticalStrike = 1,
        FireRend = 0x200,
        LightningRend = 0x100,
        None = 0,
        PierceRend = 0x10,
        SlashRend = 8
    }
}

