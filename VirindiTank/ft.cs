using Decal.Adapter;
using System;
using uTank2;

internal class ft : IDisposable
{
    public const double a = 0.00625;
    public const double b = 4.0;
    public const double c = 4.0;
    private bool d;
    private DateTimeOffset e;
    private TimeSpan f = TimeSpan.FromSeconds(4.0);
    private bool g;
    private bool h;
    private bool i;
    private ev j;
    private string k;
    private string l;
    private bool m;
    public e3 n = new e3();
    private ef o;
    private DateTimeOffset p = DateTimeOffset.MinValue;
    private bool q;

    public ft(ev A_0, string A_1, string A_2)
    {
        this.k = A_1;
        this.l = A_2;
        this.j = A_0;
        this.n.a(new EventHandler(this.a));
        this.n.a(0x2f);
    }

    private void a()
    {
        if (!this.e())
        {
            this.b();
        }
        else
        {
            sCoord coord = dh.a(this.j.aw.get_CharacterFilter().get_Id(), this.j.ax.get_Actions());
            double num = this.o.f();
            double num2 = dh.b(coord, this.o.e());
            double num3 = dh.b(this.j.ax.get_Actions().get_Heading(), num2);
            if (this.o.g())
            {
                this.j.m.b(u.c, false);
                this.j.m.b(u.d, false);
                this.a(false, 0.0);
                this.p = DateTimeOffset.MinValue;
            }
            else if (dh.i())
            {
                this.j.m.b(u.c, false);
                this.j.m.b(u.d, false);
                if (Math.Abs(num3) <= 4.0)
                {
                    this.a(true, num);
                    this.p = DateTimeOffset.MinValue;
                }
                else
                {
                    this.a(false, 0.0);
                    TimeSpan span = (TimeSpan) (DateTimeOffset.Now - this.p);
                    if (span.TotalSeconds >= 0.7)
                    {
                        this.p = DateTimeOffset.Now;
                        this.j.ax.get_Actions().FaceHeading(num2, false);
                    }
                }
            }
            else if (Math.Abs(num3) > 4.0)
            {
                if (dh.c(this.j.ax.get_Actions().get_Heading(), num2))
                {
                    this.j.m.b(u.d, false);
                    this.j.m.b(u.c, true);
                }
                else
                {
                    this.j.m.b(u.c, false);
                    this.j.m.b(u.d, true);
                }
                if (num > 0.0125)
                {
                    if (Math.Abs(num3) > 45.0)
                    {
                        this.a(false, 0.0);
                    }
                    else
                    {
                        this.a(true, num);
                    }
                }
                else if (Math.Abs(num3) > 15.0)
                {
                    this.a(false, 0.0);
                }
                else
                {
                    this.a(true, num);
                }
            }
            else
            {
                this.j.m.b(u.c, false);
                this.j.m.b(u.d, false);
                this.a(true, num);
            }
        }
    }

    public void a(ef A_0)
    {
        this.b();
        this.o = A_0;
    }

    private void a(bool A_0)
    {
        if (A_0)
        {
            if (dh.i())
            {
                if (this.i)
                {
                    this.i = false;
                    PluginCore.cq.m.a(u.e, false);
                    PluginCore.cq.m.a(u.a, false);
                }
            }
            else if (!this.i)
            {
                this.i = true;
                PluginCore.cq.m.a(u.a, true);
                PluginCore.cq.m.a(u.e, true);
            }
        }
        else if (this.i)
        {
            this.i = false;
            PluginCore.cq.m.a(u.e, false);
            PluginCore.cq.m.a(u.a, false);
        }
        this.h = A_0;
    }

    private bool a(double A_0)
    {
        return (A_0 < 0.00625);
    }

    private void a(bool A_0, double A_1)
    {
        bool flag = false;
        bool flag2 = false;
        if (A_0)
        {
            if (this.a(A_1))
            {
                flag = true;
            }
            else
            {
                flag2 = true;
            }
        }
        if (flag && (PluginCore.cq.ax.get_Actions().get_CombatMode() == 1))
        {
            if (er.j("IdlePeaceMode"))
            {
                ai.a("Warning: Idle peace selected with low waypoint minimum distance. Will switch to magic mode.");
            }
            if (!PluginCore.cq.n.a(8, 0, true))
            {
                flag = false;
            }
        }
        if (this.g && !flag)
        {
            this.g = false;
        }
        if (this.d && !flag2)
        {
            this.d = false;
            this.j.ax.get_Actions().SetAutorun(false);
        }
        if (flag && !this.g)
        {
            this.e = DateTimeOffset.Now + this.f;
            this.g = true;
        }
        if (flag2 && !this.d)
        {
            this.e = DateTimeOffset.Now + this.f;
            this.d = true;
            this.j.ax.get_Actions().SetAutorun(true);
        }
        if ((flag && this.g) && (DateTimeOffset.Now >= this.e))
        {
            this.e = DateTimeOffset.Now + this.f;
            if (this.i)
            {
                PluginCore.cq.m.a(u.e, false);
                PluginCore.cq.m.a(u.a, false);
                PluginCore.cq.m.a(u.a, true);
                PluginCore.cq.m.a(u.e, true);
            }
        }
        if ((flag2 && this.d) && (DateTimeOffset.Now >= this.e))
        {
            this.e = DateTimeOffset.Now + this.f;
            this.j.ax.get_Actions().SetAutorun(true);
        }
        this.a(this.g);
    }

    private void a(object A_0, NetworkMessageEventArgs A_1)
    {
        if ((A_1.get_Message().get_Type() == 0xf7b1) && (A_1.get_Message().Value<int>("action") == 0xf61c))
        {
            this.e = DateTimeOffset.Now + this.f;
            if ((A_1.get_Message().get_RawData()[12] & 8) == 8)
            {
                this.d = true;
            }
            else
            {
                this.d = false;
            }
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        try
        {
            this.a();
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    private void b()
    {
        if (this.q)
        {
            PluginCore.PC.a(new uTank2.PluginCore.b(this.a));
            this.q = false;
            this.n.a(false);
            this.j.m.b(u.c, false);
            this.j.m.b(u.d, false);
            this.a(false, 0.0);
        }
    }

    public void b(bool A_0)
    {
    }

    private void c()
    {
        if (!this.e())
        {
            this.b();
        }
        else if (!this.q)
        {
            PluginCore.PC.b(new uTank2.PluginCore.b(this.a));
            this.q = true;
            this.n.a(true);
            this.a();
        }
    }

    public void c(bool A_0)
    {
        if (A_0)
        {
            this.c();
        }
        else
        {
            this.b();
        }
    }

    private bool d()
    {
        return this.h;
    }

    public bool e()
    {
        return ((this.o != null) && !this.i());
    }

    protected override void f()
    {
        try
        {
            this.m();
        }
        finally
        {
            base.Finalize();
        }
    }

    public bool g()
    {
        return true;
    }

    public ef h()
    {
        return this.o;
    }

    public bool i()
    {
        double num = this.o.f();
        if (this.o.g())
        {
            return false;
        }
        if ((num > er.h(this.k)) && (num <= er.h(this.l)))
        {
            return false;
        }
        return true;
    }

    public bool j()
    {
        sCoord coord = dh.a(this.j.aw.get_CharacterFilter().get_Id(), this.j.ax.get_Actions());
        return this.a(dh.a(coord, this.o.e(), false));
    }

    public bool k()
    {
        if (this.j())
        {
            return false;
        }
        if (this.o.a() == eWaypointType.Recall)
        {
            return false;
        }
        return true;
    }

    public bool l()
    {
        return !this.j();
    }

    public void m()
    {
        if (!this.m)
        {
            this.m = true;
            GC.SuppressFinalize(this);
            this.b();
            if (this.n != null)
            {
                this.n.f();
                this.n.b(new EventHandler(this.a));
                this.n.e();
            }
            this.j = null;
            this.n = null;
        }
    }

    public bool n()
    {
        return this.q;
    }
}

