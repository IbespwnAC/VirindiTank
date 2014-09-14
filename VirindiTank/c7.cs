using System;
using uTank2;

internal class c7 : ew, b3
{
    public bool a()
    {
        if (PluginCore.cq.@as.i.Count == 0)
        {
            PluginCore.e("Meta Error: Call stack underflow, cannot return.");
            PluginCore.e("Disabling Meta.");
            er.b("EnableMeta", k.a(false));
            return false;
        }
        string str = PluginCore.cq.@as.i.Pop();
        PluginCore.cq.@as.a(str);
        return false;
    }

    public override void a(k A_0)
    {
    }

    public override void a(object A_0)
    {
    }

    public override k b()
    {
        return k.a(0);
    }

    public ep c()
    {
        return ep.g;
    }

    public override string d()
    {
        return "Return From Call";
    }

    public override string e()
    {
        return "Return From Call";
    }
}

