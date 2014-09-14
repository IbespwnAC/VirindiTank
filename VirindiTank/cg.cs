using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using uTank2;

internal class cg : ef
{
    private ev a;
    private int b;
    private List<sCoord> c = new List<sCoord>();
    private e3 d = new e3();
    private bool e;

    public cg(int A_0, ev A_1)
    {
        this.b = A_0;
        this.a = A_1;
        this.d.a(new EventHandler(this.a));
        this.d.a(0x67);
        this.d.d();
    }

    public void a(TextReader A_0)
    {
        this.b = Convert.ToInt32(A_0.ReadLine(), CultureInfo.InvariantCulture);
    }

    public void a(TextWriter A_0)
    {
        A_0.WriteLine(Convert.ToString(this.b, CultureInfo.InvariantCulture));
    }

    private void a(object A_0, EventArgs A_1)
    {
        try
        {
            fj.b("Object pathing follow update tick");
            this.f();
            fj.a("Object pathing follow update tick", 70.0);
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    private void e()
    {
        int num;
        sCoord coord = dh.a(PluginCore.cg, PluginCore.cq.ax.get_Actions());
        for (num = this.c.Count - 1; num >= 1; num--)
        {
            if (dh.a(this.c[num], this.c[num - 1], true) < 0.0004)
            {
                this.c.RemoveAt(num - 1);
            }
        }
        for (num = this.c.Count - 1; num >= 1; num--)
        {
            if ((dh.a(coord, this.c[num], this.c[num - 1]) < 0.01) && (dh.a(coord, this.c[num]) < 1.0))
            {
                this.c.RemoveRange(0, num);
                return;
            }
        }
    }

    private void f()
    {
        if (!er.j("FollowAroundCorners"))
        {
            this.c.Clear();
        }
        else
        {
            sCoord item = dh.a(this.b, PluginCore.cq.ax.get_Actions());
            if (item.invalid)
            {
                this.c.Clear();
            }
            else
            {
                this.c.Add(item);
                this.e();
            }
        }
    }

    public double g()
    {
        if (!er.j("FollowAroundCorners"))
        {
            return dh.a(dh.a(this.b, this.a.ax.get_Actions()), dh.a(this.a.aw.get_CharacterFilter().get_Id(), this.a.ax.get_Actions()), false);
        }
        if (this.c.Count == 0)
        {
            return double.MaxValue;
        }
        return dh.a(dh.a(PluginCore.cg, PluginCore.cq.ax.get_Actions()), this.c[this.c.Count - 1]);
    }

    public string h()
    {
        string str = this.b.ToString();
        cv cv = this.a.p.d(this.b);
        if (cv != null)
        {
            str = cv.g();
        }
        return ("Object (PF): " + str);
    }

    public sCoord i()
    {
        if (!er.j("FollowAroundCorners"))
        {
            return dh.a(this.b, this.a.ax.get_Actions());
        }
        this.f();
        if (this.c.Count > 0)
        {
            return this.c[0];
        }
        return sCoord.NoWhere;
    }

    public void j()
    {
    }

    public bool k()
    {
        return true;
    }

    public eWaypointType l()
    {
        return eWaypointType.Other;
    }

    public bool m()
    {
        return false;
    }

    public bool n()
    {
        return false;
    }

    public void o()
    {
        if (!this.e)
        {
            this.e = true;
            GC.SuppressFinalize(this);
            this.d.e();
        }
    }

    public int p()
    {
        return this.b;
    }
}

