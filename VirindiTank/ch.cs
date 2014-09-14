using System;
using uTank2;

internal class ch : dw, fl
{
    private int a;
    private int b;

    public override k a()
    {
        a0 a = new a0(new string[] { "k", "v" });
        v v = new v(a);
        v[0] = k.a("sid");
        v[1] = k.a(this.a);
        a.c(v);
        v = new v(a);
        v[0] = k.a("sec");
        v[1] = k.a(this.b);
        a.c(v);
        return new k(a);
    }

    public override void a(k A_0)
    {
        a0 a = A_0.c() as a0;
        this.a = k.e(a.a(0, k.a("sid"))[1]);
        this.b = k.e(a.a(0, k.a("sec"))[1]);
    }

    protected override string a(int A_0)
    {
        switch (A_0)
        {
            case 0:
                return "SpellID";

            case 1:
                return "Time Left (Seconds)";
        }
        return null;
    }

    protected override void a(int A_0, string A_1)
    {
        switch (A_0)
        {
            case 0:
                int.TryParse(A_1, out this.a);
                return;

            case 1:
                int.TryParse(A_1, out this.b);
                return;
        }
    }

    public bool b()
    {
        return PluginCore.cq.a.b(this.a, this.b);
    }

    protected override string b(int A_0)
    {
        switch (A_0)
        {
            case 0:
                return this.a.ToString();

            case 1:
                return this.b.ToString();
        }
        return null;
    }

    public c3 c()
    {
        return c3.x;
    }

    public override string d()
    {
        string str = "";
        if (PluginCore.cq.e.c(this.a))
        {
            str = " (" + PluginCore.cq.e.b(this.a).Name + ")";
        }
        return (">=" + this.b.ToString() + "s on s" + this.a.ToString() + str);
    }

    public override string e()
    {
        return "Time Left On Spell >=";
    }

    protected override int f()
    {
        return 2;
    }
}

