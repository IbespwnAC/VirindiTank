using System;
using System.IO;
using uTank2;

internal abstract class eq : ef
{
    private bool a = true;
    private bool b;
    protected ev c;

    public eq(ev A_0)
    {
        this.c = A_0;
    }

    public abstract eWaypointType a();
    public abstract int b();
    public abstract bool c();
    public abstract string d();
    protected abstract bool e();
    public abstract void e(TextReader A_0);
    protected abstract void f();
    public abstract void f(TextWriter A_0);
    public void l()
    {
        this.b = false;
        this.a = true;
    }

    public sCoord m()
    {
        return dh.a(this.c.aw.get_CharacterFilter().get_Id(), this.c.ax.get_Actions());
    }

    public virtual void n()
    {
    }

    public bool o()
    {
        return this.a;
    }

    public bool p()
    {
        if (this.b)
        {
            return false;
        }
        if (this.a)
        {
            this.a = false;
            this.f();
        }
        bool flag = this.e();
        if (!flag)
        {
            this.b = true;
        }
        return flag;
    }

    public double q()
    {
        return 0.0;
    }
}

