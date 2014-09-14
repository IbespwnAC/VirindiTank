using System;
using System.Collections.Generic;
using uTank2;

internal class bm : IRechargeHandler
{
    public string a(eRechargeVital_Single A_0)
    {
        switch (A_0)
        {
            case eRechargeVital_Single.Health:
                return "Healing Food/Potion";

            case eRechargeVital_Single.Stamina:
                return "Stamina Food/Potion";

            case eRechargeVital_Single.Mana:
                return "Mana Food/Potion";
        }
        return "Recharge With Food";
    }

    public bool b(eRechargeVital_Single A_0)
    {
        fz b = fz.b;
        switch (A_0)
        {
            case eRechargeVital_Single.Stamina:
                b = fz.d;
                break;

            case eRechargeVital_Single.Mana:
                b = fz.f;
                break;
        }
        cv cv = null;
        int num = -2147483648;
        foreach (KeyValuePair<string, fz> pair in PluginCore.cq.l.h)
        {
            if (((fz) pair.Value) == b)
            {
                foreach (cv cv2 in PluginCore.cq.p.a(pair.Key))
                {
                    if (!cx.b(cv2))
                    {
                        int num2 = 1;
                        if (num2 > num)
                        {
                            cv = cv2;
                            num = num2;
                        }
                    }
                }
            }
        }
        if (cv == null)
        {
            return false;
        }
        if (!cx.a(cv) || !PluginCore.cq.ap.d())
        {
            PluginCore.cq.ax.get_Actions().UseItem(cv.k, 0);
        }
        return true;
    }

    public string uTank2.IRechargeHandler.FriendlyName
    {
        get
        {
            return "Recharge With Food";
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

