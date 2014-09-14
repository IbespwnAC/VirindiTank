namespace uTank2
{
    using System;

    [Flags]
    public enum eCleaveType
    {
        AcidCleaving = 0x20,
        BludgeCleaving = 4,
        ColdCleaving = 8,
        FireCleaving = 0x10,
        LightningCleaving = 0x40,
        PierceCleaving = 2,
        SlashCleaving = 1
    }
}

