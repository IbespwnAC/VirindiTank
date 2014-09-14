using System;
using System.Collections.Generic;
using uTank2;

internal class eu : d7, fl
{
    public override string a()
    {
        return "Inventory Item Count >=";
    }

    protected override List<d7.a> b()
    {
        return new List<d7.a> { d7.a.Create<string>("Item name:", "n", ""), d7.a.Create<int>("Item count:", "c", 0) };
    }

    public c3 c()
    {
        return c3.m;
    }

    public bool d()
    {
        return (PluginCore.cq.p.d(k.b(base.a["n"])) >= k.e(base.a["c"]));
    }

    public override string e()
    {
        return ("Item \"" + k.b(base.a["n"]) + "\" >= " + k.e(base.a["c"]).ToString());
    }
}

