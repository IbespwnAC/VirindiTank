using System;
using System.Runtime.CompilerServices;
using uTank2;

internal abstract class dr : IDisposable
{
    private bool a;
    private dr.a b;
    private DateTimeOffset c;
    private int d;
    protected TimeSpan e;
    private e3 f;
    private e3 g;
    private dr.b h;

    public dr()
    {
        this.d = 0x7d0;
        this.e = TimeSpan.FromSeconds(3.0);
        this.f = new e3();
        this.f.a(0x7cd);
        this.f.a(new EventHandler(this.b));
        this.g = new e3();
        this.g.a(0x31d);
        this.g.a(new EventHandler(this.a));
    }

    public dr(int A_0, int A_1)
    {
        this.d = 0x7d0;
        this.e = TimeSpan.FromSeconds(3.0);
        this.f = new e3();
        this.f.a(A_1);
        this.f.a(new EventHandler(this.b));
        this.g = new e3();
        this.g.a(A_0);
        this.g.a(new EventHandler(this.a));
    }

    public virtual void a()
    {
        if (!this.a)
        {
            this.a = true;
            this.f.a(false);
            this.f.b(new EventHandler(this.b));
            this.g.a(false);
            this.g.b(new EventHandler(this.a));
            if (this.f != null)
            {
                this.f.e();
            }
            if (this.g != null)
            {
                this.g.e();
            }
            this.f = null;
            this.g = null;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void a(dr.a A_0)
    {
        this.b = (dr.a) Delegate.Remove(this.b, A_0);
    }

    protected virtual void a(dr.b A_0)
    {
        switch (A_0)
        {
            case dr.b.a:
                this.g.a(false);
                this.f.a(false);
                PluginCore.cq.n.n.a(ActionLockType.ItemUse);
                PluginCore.cq.n.k = false;
                break;

            case dr.b.b:
                this.g.a(true);
                this.f.a(false);
                PluginCore.cq.n.n.a(ActionLockType.ItemUse, TimeSpan.FromSeconds(5.0));
                PluginCore.cq.n.k = true;
                this.c = DateTimeOffset.Now;
                this.b();
                break;

            case dr.b.c:
                this.g.a(false);
                this.f.a(true);
                PluginCore.cq.n.k = true;
                break;
        }
        this.h = A_0;
        if (this.b != null)
        {
            this.b(A_0);
        }
    }

    protected void a(TimeSpan A_0)
    {
        this.d = (int) A_0.TotalMilliseconds;
        this.f.a(this.d);
    }

    private void a(object A_0, EventArgs A_1)
    {
        try
        {
            if ((DateTimeOffset.Now - this.c) > this.e)
            {
                this.a(dr.b.a);
            }
            else
            {
                this.b();
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    protected abstract void b();
    [MethodImpl(MethodImplOptions.Synchronized)]
    public void b(dr.a A_0)
    {
        this.b = (dr.a) Delegate.Combine(this.b, A_0);
    }

    private void b(object A_0, EventArgs A_1)
    {
        try
        {
            this.a(dr.b.a);
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    public virtual dr.b c()
    {
        return this.h;
    }

    protected TimeSpan d()
    {
        return TimeSpan.FromMilliseconds((double) this.d);
    }

    public delegate void a(dr.b A_0);

    public enum b
    {
        a,
        b,
        c
    }
}

