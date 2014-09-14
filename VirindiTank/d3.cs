using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using uTank2;

internal class d3 : d7, fl
{
    public override string a()
    {
        return "Monster Priority Count Within Distance";
    }

    protected override List<d7.a> b()
    {
        return new List<d7.a> { d7.a.Create<int>("Monster Priority:", "p", -1), d7.a.Create<int>("Monster count (>=):", "c", 1), d7.a.Create<double>("Range (meters):", "r", 5.0) };
    }

    public c3 c()
    {
        return c3.o;
    }

    public bool d()
    {
        ReadOnlyCollection<cv> onlys = PluginCore.cq.p.a(ObjectClass.Monster);
        dz dz = PluginCore.cq.p.d(PluginCore.cq.p.f()).b(PluginCore.cq.ax.get_Actions());
        double num = k.f(base.a["r"]) / 240.0;
        int num2 = k.e(base.a["c"]);
        int num3 = k.e(base.a["p"]);
        int num4 = 0;
        foreach (cv cv in onlys)
        {
            if ((PluginCore.cq.d.a(cv).a == num3) && (dz.a(cv.b(PluginCore.cq.ax.get_Actions()), true) <= num))
            {
                num4++;
                if (num4 >= num2)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override string e()
    {
        object[] objArray = new object[] { "#", k.e(base.a["c"]).ToString(), " Mons Prio ", k.e(base.a["p"]), " dist ", k.f(base.a["r"]).ToString() };
        return string.Concat(objArray);
    }
}

