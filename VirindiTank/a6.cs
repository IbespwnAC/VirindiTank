using System;
using System.IO;
using uTank2;

internal class a6 : ef
{
    private ev a;
    private string b;
    private bool c;

    public a6(string A_0)
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
        if (this.a.q.a(er.h(this.b)))
        {
            return dh.a(dh.a(this.a.q.i, this.a.ax.get_Actions()), dh.a(this.a.aw.get_CharacterFilter().get_Id(), this.a.ax.get_Actions()), true);
        }
        return 0.0;
    }

    public string f()
    {
        return ("CorpseApproach (" + this.b + ")");
    }

    public sCoord g()
    {
        if (this.a.q.a(er.h(this.b)))
        {
            return dh.a(this.a.q.i, this.a.ax.get_Actions());
        }
        return new sCoord();
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
        return eWaypointType.Other;
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

