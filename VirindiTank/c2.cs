using MyClasses.MyWorldFilter;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using uTank2;

internal class c2 : eq
{
    private string a;
    private dz b;
    private ObjectClass c;
    private dz d;
    private long e;
    private c2.a f;
    private sCoord g;

    public c2(sCoord A_0) : base(PluginCore.cq)
    {
        this.a = "";
        this.b = new dz();
        this.d = new dz();
        this.g = A_0;
    }

    public c2(sCoord A_0, string A_1, dz A_2, ObjectClass A_3) : base(PluginCore.cq)
    {
        this.a = "";
        this.b = new dz();
        this.d = new dz();
        this.g = A_0;
        this.a = A_1;
        this.b = A_2;
        this.c = A_3;
    }

    public override void a(TextReader A_0)
    {
        this.a = A_0.ReadLine();
        this.c = (ObjectClass) Convert.ToInt32(A_0.ReadLine(), CultureInfo.InvariantCulture);
        this.b.a(A_0);
    }

    public override void a(TextWriter A_0)
    {
        A_0.WriteLine(this.a);
        A_0.WriteLine(Convert.ToString((int) this.c, CultureInfo.InvariantCulture));
        this.b.a(A_0);
    }

    protected override bool e()
    {
        switch (this.f)
        {
            case c2.a.a:
                if (this.e == PluginCore.ch)
                {
                    if (!PluginCore.cq.n.n.b(ActionLockType.ItemUse))
                    {
                        int num = this.g();
                        if (num == 0)
                        {
                            PluginCore.e("Warning: cannot find portal object " + this.a + "! Continuing route at next point.");
                            return false;
                        }
                        this.d = PluginCore.cq.p.d(PluginCore.cq.p.f()).b(PluginCore.cq.ax.get_Actions());
                        PluginCore.cq.n.n.a(ActionLockType.ItemUse, TimeSpan.FromSeconds(3.0));
                        PluginCore.cq.ax.get_Actions().UseItem(num, 0);
                    }
                    return true;
                }
                this.f = c2.a.b;
                return true;

            case c2.a.b:
                if (PluginCore.ch < (this.e + 2L))
                {
                    return true;
                }
                if (PluginCore.cq.p.d(PluginCore.cq.p.f()).b(PluginCore.cq.ax.get_Actions()).a(this.d, true) <= 0.0625)
                {
                    PluginCore.e("Warning: use portal route came out of portal space too close to the origin point. Trying again...");
                    this.f = c2.a.a;
                    this.e = PluginCore.ch;
                    return true;
                }
                return false;
        }
        return false;
    }

    protected override void f()
    {
        this.f = c2.a.a;
        this.e = PluginCore.ch;
    }

    private int g()
    {
        ReadOnlyCollection<cv> onlys = PluginCore.cq.p.a(this.a, this.c);
        double maxValue = double.MaxValue;
        int k = 0;
        foreach (cv cv in onlys)
        {
            if (cv.f() == 0)
            {
                double num3 = this.b.a(cv.b(PluginCore.cq.ax.get_Actions()), true);
                if (num3 < maxValue)
                {
                    maxValue = num3;
                    k = cv.k;
                }
            }
        }
        if (maxValue <= 0.0104166)
        {
            return k;
        }
        return 0;
    }

    public override string h()
    {
        return ("Portal: " + this.a);
    }

    public override bool i()
    {
        return false;
    }

    public override eWaypointType j()
    {
        return eWaypointType.Portal2;
    }

    public override int k()
    {
        return 0;
    }

    private enum a
    {
        a = 1,
        b = 2
    }
}

