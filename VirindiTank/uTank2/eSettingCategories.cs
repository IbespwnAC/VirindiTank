namespace uTank2
{
    using System;

    [Flags]
    public enum eSettingCategories
    {
        Buffing = 0x40,
        Crafting = 0x80,
        Looting = 0x100,
        MeleeCombat = 4,
        Misc = 1,
        Navigation = 0x20,
        Ranges = 0x10,
        Recharge = 2,
        SpellCombat = 8
    }
}

