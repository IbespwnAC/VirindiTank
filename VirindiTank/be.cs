using System;
using System.Globalization;
using System.IO;
using uTank2;

internal class be : ef
{
    private ev a;
    private int b;
    private bool c;

    public be(int A_0, ev A_1)
    {
        this.b = A_0;
        this.a = A_1;
    }

    public void a(TextReader A_0)
    {
        this.b = Convert.ToInt32(A_0.ReadLine(), CultureInfo.InvariantCulture);
    }

    public void a(TextWriter A_0)
    {
        A_0.WriteLine(Convert.ToString(this.b, CultureInfo.InvariantCulture));
    }

    public double e()
    {
        return dh.a(dh.a(this.b, this.a.ax.get_Actions()), dh.a(this.a.aw.get_CharacterFilter().get_Id(), this.a.ax.get_Actions()), false);
    }

    public string f()
    {
        string str = this.b.ToString();
        cv cv = this.a.p.d(this.b);
        if (cv != null)
        {
            str = cv.g();
        }
        return ("Object (DF): " + str);
    }

    public sCoord g()
    {
        return dh.a(this.b, this.a.ax.get_Actions());
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

