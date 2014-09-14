using System;
using uTank2;

internal class e4 : ew, fl
{
    public override k a()
    {
        return k.a(0);
    }

    public override void a(k A_0)
    {
    }

    public override void a(object A_0)
    {
    }

    public c3 b()
    {
        return c3.p;
    }

    public bool c()
    {
        bool flag;
        int num = er.i("RebuffTimeRemainingSeconds");
        if (PluginCore.cq.n.n.b(ActionLockType.BuffCastRecast))
        {
            num += er.i("BuffCastRecast_Seconds");
        }
        if (num < 10)
        {
            num = 10;
        }
        return PluginCore.cq.j.a(num, true, out flag);
    }

    public override string d()
    {
        return "Need to Buff";
    }

    public override string e()
    {
        return "Need to Buff";
    }
}

