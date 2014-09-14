using System;
using System.IO;
using uTank2;

internal class d5 : ef
{
    private ev a;
    private sCoord b;
    private bool c;

    public d5(sCoord A_0)
    {
        this.b = A_0;
        this.a = PluginCore.cq;
    }

    public void a(TextReader A_0)
    {
    }

    public void a(TextWriter A_0)
    {
    }

    public double e()
    {
        return dh.a(this.b, dh.a(this.a.aw.get_CharacterFilter().get_Id(), this.a.ax.get_Actions()), false);
    }

    public string f()
    {
        return ("Point: " + this.b.ToStringXY());
    }

    public sCoord g()
    {
        return this.b;
    }

    public void h()
    {
    }

    public bool i()
    {
        return true;
    }

    public eWaypointType j()
    {
        return eWaypointType.Point;
    }

    public bool k()
    {
        return true;
    }

    public bool l()
    {
        return false;
    }

    public void m()
    {
        if (!this.c)
        {
            this.c = true;
            GC.SuppressFinalize(this);
        }
    }

    public int n()
    {
        return 0;
    }
}

