using MetaViewWrappers;
using System;
using uTank2;

internal class en : IDisposable
{
    private bool a;
    private IView b;
    private IList c;
    private e3 d;
    private bool e;

    public void a()
    {
        if (!this.a)
        {
            this.a = true;
            GC.SuppressFinalize(this);
            this.a(false);
            if (this.d != null)
            {
                this.d.e();
            }
        }
    }

    public void a(bool A_0)
    {
        if (A_0 != this.e)
        {
            this.e = A_0;
            if (A_0)
            {
                this.b = ff.f(PluginCore.cq.ax, "uTank2.Debug.DebugUI.xml");
                this.c = (IList) this.b["lRefcounts"];
                this.d = new e3();
                this.d.a(new EventHandler(this.a));
                this.d.a(0x42d);
                this.d.d();
            }
            else
            {
                this.d.f();
                this.d.b(new EventHandler(this.a));
                this.d = null;
                this.c = null;
                this.b.Dispose();
                this.b = null;
            }
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
    }

    public bool b()
    {
        return this.e;
    }
}

