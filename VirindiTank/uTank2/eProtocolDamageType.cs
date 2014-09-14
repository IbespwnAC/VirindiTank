namespace uTank2
{
    using System;

    [Flags]
    public enum eProtocolDamageType
    {
        Acid = 0x20,
        Bludge = 4,
        Cold = 8,
        Fire = 0x10,
        Lightning = 0x40,
        Nether = 0x400,
        None = 0,
        Pierce = 2,
        Slash = 1
    }
}

