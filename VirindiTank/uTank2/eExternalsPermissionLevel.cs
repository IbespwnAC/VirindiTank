namespace uTank2
{
    using System;

    [Flags]
    public enum eExternalsPermissionLevel
    {
        FullUnderlying = 4,
        LogicObject = 8,
        None = 0,
        ReadSettings = 1,
        WriteSettings = 2
    }
}

