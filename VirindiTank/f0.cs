using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using uTank2;

internal class f0 : d7, fl
{
    private Regex a = new Regex("");

    public override string a()
    {
        return "Monster Name Count Within Distance";
    }

    protected override List<d7.a> b()
    {
        return new List<d7.a> { d7.a.Create<string>("Monster name (regex):", "n", ""), d7.a.Create<int>("Monster count (>=):", "c", 1), d7.a.Create<double>("Range (meters):", "r", 5.0) };
    }

    public c3 c()
    {
        return c3.n;
    }

    public bool d()
    {
        ReadOnlyCollection<cv> onlys = PluginCore.cq.p.a(ObjectClass.Monster);
        dz dz = PluginCore.cq.p.d(PluginCore.cq.p.f()).b(PluginCore.cq.ax.get_Actions());
        if (this.a.ToString() != k.b(base.a["n"]))
        {
            try
            {
                this.a = new Regex(k.b(base.a["n"]), RegexOptions.Compiled);
            }
            catch
            {
                this.a = new Regex("");
                ai.a("Warning: invalid regex \"" + k.b(base.a["n"]) + "\" in Meta condition.");
            }
        }
        double num = k.f(base.a["r"]) / 240.0;
        int num2 = k.e(base.a["c"]);
        int num3 = 0;
        foreach (cv cv in onlys)
        {
            if (this.a.IsMatch(cv.e()) && (dz.a(cv.b(PluginCore.cq.ax.get_Actions()), true) <= num))
            {
                num3++;
                if (num3 >= num2)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public override string e()
    {
        string[] strArray = new string[] { "#", k.e(base.a["c"]).ToString(), " Mons \"", k.b(base.a["n"]), "\" dist ", k.f(base.a["r"]).ToString() };
        return string.Concat(strArray);
    }
}

