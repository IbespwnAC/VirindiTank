using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using uTank2;

internal class fe : d7, fl
{
    public override string a()
    {
        return "No Monsters Within Distance";
    }

    protected override List<d7.a> b()
    {
        return new List<d7.a> { d7.a.Create<double>("Range (meters):", "r", 5.0) };
    }

    public bool c()
    {
        ReadOnlyCollection<cv> onlys = PluginCore.cq.p.a(ObjectClass.Monster);
        dz dz = PluginCore.cq.p.d(PluginCore.cq.p.f()).b(PluginCore.cq.ax.get_Actions());
        double num = k.f(base.a["r"]) / 240.0;
        foreach (cv cv in onlys)
        {
            if (dz.a(cv.b(PluginCore.cq.ax.get_Actions()), true) <= num)
            {
                return false;
            }
        }
        return true;
    }

    public c3 d()
    {
        return c3.q;
    }

    public override string e()
    {
        double num = k.f(base.a["r"]);
        return ("No Monsters Within " + num.ToString() + "m");
    }
}

