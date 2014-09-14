using System;
using System.Collections.Generic;
using uTank2;

internal abstract class ew : b1
{
    private b1 a;

    protected ew()
    {
    }

    public void b(b1 A_0)
    {
        this.a = A_0;
    }

    public abstract string g();
    public virtual void h()
    {
        if (this.a != null)
        {
            this.a.c();
        }
    }

    public abstract void h(k A_0);
    public abstract k i();
    public abstract void j(object A_0);
    public abstract string k();
    public void l()
    {
        PluginCore.cq.@as.d();
        if (this.m() != null)
        {
            this.m().c();
        }
    }

    public b1 m()
    {
        return this.a;
    }

    public List<string> n()
    {
        return null;
    }
}

