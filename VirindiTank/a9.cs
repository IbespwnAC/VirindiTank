using System;
using uTank2;

internal class a9 : bc
{
    protected override string a()
    {
        return "Health to Stamina Self I";
    }

    protected override eRechargeVital_Single b()
    {
        return eRechargeVital_Single.Stamina;
    }

    protected override eRechargeVital_Single c()
    {
        return eRechargeVital_Single.Health;
    }

    protected override string d()
    {
        return "Health to Stamina";
    }
}

