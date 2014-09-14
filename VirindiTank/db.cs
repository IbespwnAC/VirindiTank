using System;
using uTank2;

internal class db : dw, fl
{
    private int a = 0x1869f;

    public override k a()
    {
        return k.a(this.a);
    }

    public override void a(k A_0)
    {
        this.a = k.e(A_0);
    }

    protected override string a(int A_0)
    {
        if (A_0 == 0)
        {
            return "Seconds in state (start/stop persistent):";
        }
        return "";
    }

    protected override void a(int A_0, string A_1)
    {
        if (A_0 == 0)
        {
            int.TryParse(A_1, out this.a);
        }
    }

    public c3 b()
    {
        return c3.w;
    }

    protected override string b(int A_0)
    {
        if (A_0 == 0)
        {
            return this.a.ToString();
        }
        return "";
    }

    public bool c()
    {
        TimeSpan span = (TimeSpan) (DateTimeOffset.Now - PluginCore.cq.@as.h);
        return (span.TotalSeconds >= this.a);
    }

    public override string d()
    {
        return ("Seconds in state (P) >= " + this.a.ToString());
    }

    public override string e()
    {
        return "Seconds in state (P) >=";
    }

    protected override int f()
    {
        return 1;
    }
}

