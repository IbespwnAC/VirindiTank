using System;
using System.Globalization;
using System.IO;
using uTank2;

internal class fv : ef
{
    private ev a;
    private sCoord b;
    private int c;
    private bool d;
    private bool e;

    public fv(sCoord A_0)
    {
        this.b = A_0;
        this.a = PluginCore.cq;
    }

    public fv(sCoord A_0, int A_1)
    {
        this.b = A_0;
        this.a = PluginCore.cq;
        this.c = A_1;
    }

    public void a(TextReader A_0)
    {
        this.c = Convert.ToInt32(A_0.ReadLine(), CultureInfo.InvariantCulture);
    }

    public void a(TextWriter A_0)
    {
        A_0.WriteLine(Convert.ToString(this.c, CultureInfo.InvariantCulture));
    }

    public double e()
    {
        return dh.a(this.b, dh.a(this.a.aw.get_CharacterFilter().get_Id(), this.a.ax.get_Actions()), false);
    }

    public string f()
    {
        return ("Portal: " + this.c.ToString());
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
        return eWaypointType.Portal;
    }

    public bool k()
    {
        if (this.e)
        {
            this.e = false;
            return false;
        }
        return true;
    }

    public bool l()
    {
        if (dh.b(this.c))
        {
            if (this.a.n.n.b(ActionLockType.TryingPortal) && (this.e() <= er.h("UsePortalDistance")))
            {
                if (!this.a.n.n.b(ActionLockType.ItemUse))
                {
                    this.a.ax.get_Actions().UseItem(this.c, 0);
                    this.a.n.n.a(ActionLockType.ItemUse, TimeSpan.FromSeconds(3.0));
                }
                return true;
            }
            if (this.e() <= er.h("UsePortalDistance"))
            {
                this.a.n.n.a(ActionLockType.TryingPortal, TimeSpan.FromSeconds(30.0));
                return true;
            }
            if (!this.a.n.n.b(ActionLockType.TryingPortal))
            {
                this.e = true;
            }
            else
            {
                this.e = false;
            }
            this.a.n.n.a(ActionLockType.TryingPortal);
        }
        return false;
    }

    public void m()
    {
        if (!this.d)
        {
            this.d = true;
            GC.SuppressFinalize(this);
        }
    }

    public int n()
    {
        return this.c;
    }
}

