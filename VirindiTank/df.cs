using Decal.Adapter.Wrappers;
using System;
using System.Collections.Generic;
using uTank2;

internal class df : IRechargeHandler
{
    public string a(eRechargeVital_Single A_0)
    {
        switch (A_0)
        {
            case eRechargeVital_Single.Health:
                return "Health Kit";

            case eRechargeVital_Single.Stamina:
                return "Stamina Kit";

            case eRechargeVital_Single.Mana:
                return "Mana Kit";
        }
        return "Kit Recharge";
    }

    public bool b(eRechargeVital_Single A_0)
    {
        if ((PluginCore.cq.ax.get_Actions().get_CombatMode() == 8) && !er.j("UseKitsInMagicMode"))
        {
            return false;
        }
        if ((A_0 != eRechargeVital_Single.Stamina) && (PluginCore.cq.ax.get_Actions().get_Vital().get_Item(4) < 15))
        {
            return false;
        }
        TrainingType type = PluginCore.cq.aw.get_CharacterFilter().get_Skills().get_Item(0x15).get_Training();
        if ((type != 3) && (type != 2))
        {
            return false;
        }
        fz a = fz.a;
        switch (A_0)
        {
            case eRechargeVital_Single.Stamina:
                a = fz.c;
                break;

            case eRechargeVital_Single.Mana:
                a = fz.e;
                break;
        }
        double num = ((double) er.i("MinimumHealKitSuccessChance")) / 100.0;
        int k = 0;
        int num3 = 0x7fffffff;
        double num4 = -2147483648.0;
        foreach (KeyValuePair<string, fz> pair in PluginCore.cq.l.h)
        {
            if (((fz) pair.Value) == a)
            {
                dp dp = PluginCore.cq.x.a(pair.Key);
                if (dp != null)
                {
                    double b = 1.0;
                    b = dp.b;
                    if (dh.a(dp.c, A_0) >= num)
                    {
                        foreach (cv cv in PluginCore.cq.p.a(pair.Key))
                        {
                            int num7 = cv.a(dt.aa, 0);
                            if ((b > num4) || ((b == num4) && (num7 < num3)))
                            {
                                k = cv.k;
                                num3 = num7;
                                num4 = b;
                            }
                        }
                    }
                }
            }
        }
        if (k == 0)
        {
            return false;
        }
        if (er.j("GoToPeaceModeToUseKits") && (PluginCore.cq.ax.get_Actions().get_CombatMode() != 1))
        {
            dh.a(1);
            return true;
        }
        PluginCore.cq.ax.get_Actions().ApplyItem(k, PluginCore.cg);
        return true;
    }

    public string uTank2.IRechargeHandler.FriendlyName
    {
        get
        {
            return "Kit Recharge";
        }
    }

    public eRechargeVital_Multiple uTank2.IRechargeHandler.ValidVitals
    {
        get
        {
            return (eRechargeVital_Multiple.Mana | eRechargeVital_Multiple.Stamina | eRechargeVital_Multiple.Health);
        }
    }
}

