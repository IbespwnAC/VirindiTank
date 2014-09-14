using Decal.Adapter.Wrappers;
using System;
using uTank2;

internal class ao
{
    public static int a(CharFilterVitalType A_0)
    {
        int num;
        ev cq = PluginCore.cq;
        switch (A_0)
        {
            case 2:
                num = cq.ax.get_Actions().get_Vital().get_Item(2);
                return ((100 * num) / cq.ax.get_Actions().get_Vital().get_Item(1));

            case 4:
                num = cq.ax.get_Actions().get_Vital().get_Item(4);
                return ((100 * num) / cq.ax.get_Actions().get_Vital().get_Item(3));

            case 6:
                num = cq.ax.get_Actions().get_Vital().get_Item(6);
                return ((100 * num) / cq.ax.get_Actions().get_Vital().get_Item(5));
        }
        return 100;
    }

    public static bool a(string A_0)
    {
        ev cq = PluginCore.cq;
        double num = er.i(A_0);
        double num2 = cq.ax.get_Actions().get_Vital().get_Item(6);
        double num3 = cq.ax.get_Actions().get_Vital().get_Item(5);
        if ((num2 != num3) && cq.n.n.b(ActionLockType.RechargeLevelBoost_Mana))
        {
            num2 -= er.i("RechargeBoostAmount");
            if (num2 < 0.0)
            {
                num2 = 0.0;
            }
        }
        return (((100.0 * num2) / num3) < num);
    }

    public static bool b(string A_0)
    {
        ev cq = PluginCore.cq;
        double num = er.i(A_0);
        double num2 = cq.ax.get_Actions().get_Vital().get_Item(4);
        double num3 = cq.ax.get_Actions().get_Vital().get_Item(3);
        if ((num2 != num3) && cq.n.n.b(ActionLockType.RechargeLevelBoost_Stam))
        {
            num2 -= er.i("RechargeBoostAmount");
            if (num2 < 0.0)
            {
                num2 = 0.0;
            }
        }
        return (((100.0 * num2) / num3) < num);
    }

    public static bool c(string A_0)
    {
        ev cq = PluginCore.cq;
        double num = er.i(A_0);
        double num2 = cq.ax.get_Actions().get_Vital().get_Item(2);
        double num3 = cq.ax.get_Actions().get_Vital().get_Item(1);
        if ((num2 != num3) && cq.n.n.b(ActionLockType.RechargeLevelBoost_HP))
        {
            num2 -= er.i("RechargeBoostAmount");
            if (num2 < 0.0)
            {
                num2 = 0.0;
            }
        }
        return (((100.0 * num2) / num3) < num);
    }
}

