using System;
using uTank2;

internal class a3 : bc
{
    protected override string a()
    {
        return "Health to Mana Self I";
    }

    protected override eRechargeVital_Single b()
    {
        return eRechargeVital_Single.Mana;
    }

    protected override eRechargeVital_Single c()
    {
        return eRechargeVital_Single.Health;
    }

    protected override string d()
    {
        return "Health to Mana";
    }
}

