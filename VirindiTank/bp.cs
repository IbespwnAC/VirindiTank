using System;
using uTank2;

internal class bp : IDisposable
{
    private e3 a = new e3();
    private double b;
    private int c;
    private bool d;
    private bool e;

    public bp()
    {
        this.a.a(1);
        this.a.a(new EventHandler(this.a));
    }

    public void a()
    {
        if (!this.e)
        {
            this.e = true;
            GC.SuppressFinalize(this);
            this.a.e();
        }
    }

    public bool a(double A_0)
    {
        double num = dh.a((double) ((A_0 * 180.0) / 3.1415926535897931));
        if (!this.a.g() && (num != this.b))
        {
            this.c = 0;
        }
        this.b = num;
        this.a.a(true);
        this.a(null, null);
        return !this.a.g();
    }

    private void a(object A_0, EventArgs A_1)
    {
        if (dh.b(PluginCore.cq.ax.get_Actions().get_Heading(), this.b) <= (0.5 + (0.4 * this.c)))
        {
            PluginCore.cq.m.b(u.d, false);
            PluginCore.cq.m.b(u.c, false);
            this.a.a(false);
        }
        else if (!dh.i())
        {
            bool flag = dh.c(PluginCore.cq.ax.get_Actions().get_Heading(), this.b);
            if (flag)
            {
                PluginCore.cq.m.b(u.d, false);
                PluginCore.cq.m.b(u.c, true);
            }
            else
            {
                PluginCore.cq.m.b(u.c, false);
                PluginCore.cq.m.b(u.d, true);
            }
            if (flag != this.d)
            {
                this.d = flag;
                this.c++;
            }
        }
    }

    public void b()
    {
        this.c = 0;
        this.a.a(false);
        PluginCore.cq.m.b(u.d, false);
        PluginCore.cq.m.b(u.c, false);
    }

    protected override void c()
    {
        try
        {
            this.a();
        }
        finally
        {
            base.Finalize();
        }
    }
}

