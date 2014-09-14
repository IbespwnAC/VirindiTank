using System;
using uTank2;

internal class j : IDisposable
{
    private e3 a = new e3();
    private bool b;
    private bool c = true;

    public j()
    {
        this.a.a(0x83);
        this.a.a(new EventHandler(this.a));
    }

    private void a()
    {
        PluginCore.cq.m.b();
    }

    private void a(object A_0, EventArgs A_1)
    {
        try
        {
            if (dh.i())
            {
                this.a();
            }
            else if (this.c)
            {
                PluginCore.cq.m.a(u.f, true);
                PluginCore.cq.m.a(u.an, false);
                PluginCore.cq.m.a(u.q, true);
                this.c = false;
            }
            else
            {
                PluginCore.cq.m.a(u.f, true);
                PluginCore.cq.m.a(u.q, false);
                PluginCore.cq.m.a(u.an, true);
                this.c = true;
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    public void b()
    {
        if (!this.b)
        {
            this.b = true;
            GC.SuppressFinalize(this);
            this.a.b(new EventHandler(this.a));
            if (this.a != null)
            {
                this.a.e();
            }
        }
    }

    public void c()
    {
        this.a.a(true);
        this.a(null, null);
    }

    public void d()
    {
        this.a.a(false);
        this.a();
    }

    protected override void e()
    {
        try
        {
            this.b();
        }
        finally
        {
            base.Finalize();
        }
    }
}

