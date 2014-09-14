using System;
using System.Globalization;
using System.IO;
using uTank2;

internal class fd : ef
{
    private ev a;
    private sCoord b;
    private bool c;
    private int d;
    private bool e;

    public fd(sCoord A_0)
    {
        this.c = true;
        this.a = PluginCore.cq;
        this.b = A_0;
    }

    public fd(sCoord A_0, int A_1)
    {
        this.c = true;
        this.a = PluginCore.cq;
        this.d = A_1;
        this.b = A_0;
    }

    public void a(TextReader A_0)
    {
        this.d = Convert.ToInt32(A_0.ReadLine(), CultureInfo.InvariantCulture);
    }

    public void a(TextWriter A_0)
    {
        A_0.WriteLine(Convert.ToString(this.d, CultureInfo.InvariantCulture));
    }

    public double e()
    {
        return 0.5;
    }

    public string f()
    {
        string name = this.d.ToString();
        if (this.a.e.c(this.d))
        {
            name = this.a.e.b(this.d).Name;
        }
        return ("Recall: " + name);
    }

    public sCoord g()
    {
        return dh.a(this.a.aw.get_CharacterFilter().get_Id(), this.a.ax.get_Actions());
    }

    public void h()
    {
    }

    public bool i()
    {
        return false;
    }

    public eWaypointType j()
    {
        return eWaypointType.Recall;
    }

    public bool k()
    {
        return this.c;
    }

    public bool l()
    {
        if (this.c)
        {
            this.c = false;
            this.b = dh.a(this.a.aw.get_CharacterFilter().get_Id(), this.a.ax.get_Actions());
        }
        if (dh.a(this.b, dh.a(this.a.aw.get_CharacterFilter().get_Id(), this.a.ax.get_Actions()), false) > 0.01)
        {
            this.c = true;
            return false;
        }
        this.b = dh.a(this.a.aw.get_CharacterFilter().get_Id(), this.a.ax.get_Actions());
        if (!this.a.g.e())
        {
            if (!PluginCore.cq.n.a(8, 0, true))
            {
                return true;
            }
            this.a.g.a(this.a.e.b(this.d), PluginCore.cg);
        }
        return true;
    }

    public void m()
    {
        if (!this.e)
        {
            this.e = true;
            GC.SuppressFinalize(this);
        }
    }

    public int n()
    {
        return this.d;
    }
}

