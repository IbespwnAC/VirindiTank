using System;
using System.IO;
using uTank2;

internal class bs : ef
{
    private ev a;
    private bool b = false;
    private bool c;

    public bs(ev A_0)
    {
        this.a = A_0;
    }

    public double a(int A_0)
    {
        if (A_0 >= this.a.l.k.b.Count)
        {
            return 0.0;
        }
        if (this.a.l.k.b[A_0].g())
        {
            this.b = true;
            return 999999.0;
        }
        return this.a.l.k.b[A_0].f();
    }

    public void a(TextReader A_0)
    {
    }

    public void a(TextWriter A_0)
    {
    }

    public double e()
    {
        double num3;
        bool flag;
        int l = this.a.n.l;
        if (this.a.l.k.c == eNavType.Target)
        {
            if (this.a.l.k.d == 0)
            {
                return 0.0;
            }
            if (this.a.l.k.b.Count == 0)
            {
                return 0.0;
            }
            return this.a.l.k.b[0].f();
        }
        if (this.a.l.k.b.Count == 0)
        {
            return 0.0;
        }
        if (this.a.n.l < 0)
        {
            throw new Exception("Cycle advance 1");
        }
        if (this.a.n.l >= this.a.l.k.b.Count)
        {
            throw new Exception("Cycle advance 2");
        }
        if (this.a.l.k.b[this.a.n.l].g())
        {
            this.b = true;
            return -1.0;
        }
        int num2 = this.a.n.l;
        if (this.b)
        {
            this.b = false;
            if (this.a.l.k.b[this.a.n.l].h())
            {
                if (this.a.l.k.c == eNavType.Circular)
                {
                    this.a.n.l++;
                    if (this.a.n.l >= this.a.l.k.b.Count)
                    {
                        this.a.n.l = 0;
                    }
                }
                else if (this.a.l.k.c == eNavType.Linear)
                {
                    if (!this.a.n.m)
                    {
                        this.a.n.l++;
                        if (this.a.n.l >= this.a.l.k.b.Count)
                        {
                            this.a.n.l--;
                            this.a.n.m = true;
                            if (this.a.n.l < 0)
                            {
                                this.a.n.l = 0;
                            }
                        }
                    }
                    else
                    {
                        this.a.n.l--;
                        if (this.a.n.l < 0)
                        {
                            this.a.n.l++;
                            this.a.n.m = false;
                            if (this.a.n.l >= this.a.l.k.b.Count)
                            {
                                this.a.n.l = 0;
                            }
                        }
                    }
                }
                else if (this.a.l.k.c == eNavType.Once)
                {
                    if (this.a.l.k.b.Count == 0)
                    {
                        throw new Exception("Cycle advance 3");
                    }
                    this.a.l.k.b.RemoveAt(0);
                }
            }
        }
        if (this.a.l.k.b.Count == 0)
        {
            return 0.0;
        }
        if (this.a.l.k.c == eNavType.Circular)
        {
            this.a.n.m = false;
            num3 = this.a(this.a.n.l);
            while (num3 < er.h("NavCloseStopRange"))
            {
                this.a.n.l++;
                if (this.a.n.l >= this.a.l.k.b.Count)
                {
                    this.a.n.l = 0;
                }
                if (this.a.n.l < 0)
                {
                    throw new Exception("Cycle advance 4");
                }
                if (this.a.n.l >= this.a.l.k.b.Count)
                {
                    throw new Exception("Cycle advance 5");
                }
                this.a.l.k.b[this.a.n.l].i();
                num3 = this.a(this.a.n.l);
                if (this.a.n.l == num2)
                {
                    return 0.0;
                }
            }
            if (this.a.n.l != l)
            {
                if (PluginCore.cq.ay.bl.RowCount <= num2)
                {
                    throw new Exception("Cycle advance 6");
                }
                if (PluginCore.cq.ay.bl.RowCount <= this.a.n.l)
                {
                    throw new Exception("Cycle advance 7");
                }
                PluginCore.cq.ay.bl[num2][1][0] = "";
                PluginCore.cq.ay.bl[this.a.n.l][1][0] = "<<";
                PluginCore.cq.ay.ae();
            }
            return num3;
        }
        if (this.a.l.k.c != eNavType.Linear)
        {
            if (this.a.l.k.c != eNavType.Once)
            {
                return 0.0;
            }
            flag = false;
            if (this.a.n.l != 0)
            {
                this.a.n.l = 0;
                flag = true;
            }
            num3 = this.a(this.a.n.l);
            while (num3 < er.h("NavCloseStopRange"))
            {
                flag = true;
                this.a.l.k.b.RemoveAt(0);
                if (this.a.l.k.b.Count > 0)
                {
                    if (this.a.n.l < 0)
                    {
                        throw new Exception("Cycle advance 12");
                    }
                    if (this.a.n.l >= this.a.l.k.b.Count)
                    {
                        throw new Exception("Cycle advance 13");
                    }
                    this.a.l.k.b[this.a.n.l].i();
                    num3 = this.a(this.a.n.l);
                }
                else
                {
                    num3 = 0.0;
                    break;
                }
            }
        }
        else
        {
            num3 = this.a(this.a.n.l);
            int num4 = 0;
            while (num3 < er.h("NavCloseStopRange"))
            {
                if (!this.a.n.m)
                {
                    this.a.n.l++;
                    if (this.a.n.l >= this.a.l.k.b.Count)
                    {
                        this.a.n.l = num2;
                        this.a.n.m = true;
                    }
                }
                else
                {
                    this.a.n.l--;
                    if (this.a.n.l < 0)
                    {
                        this.a.n.l = num2;
                        this.a.n.m = false;
                    }
                }
                if (this.a.n.l < 0)
                {
                    throw new Exception("Cycle advance 8");
                }
                if (this.a.n.l >= this.a.l.k.b.Count)
                {
                    throw new Exception("Cycle advance 9");
                }
                this.a.l.k.b[this.a.n.l].i();
                num3 = this.a(this.a.n.l);
                num4++;
                if (num4 > this.a.l.k.b.Count)
                {
                    break;
                }
            }
            if (this.a.n.l != l)
            {
                if (PluginCore.cq.ay.bl.RowCount <= num2)
                {
                    throw new Exception("Cycle advance 10");
                }
                if (PluginCore.cq.ay.bl.RowCount <= this.a.n.l)
                {
                    throw new Exception("Cycle advance 11");
                }
                PluginCore.cq.ay.bl[num2][1][0] = "";
                PluginCore.cq.ay.bl[this.a.n.l][1][0] = "<<";
                PluginCore.cq.ay.ae();
            }
            return num3;
        }
        if (flag)
        {
            PluginCore.PC.ao();
        }
        PluginCore.cq.ay.ae();
        return num3;
    }

    public string f()
    {
        return "?????";
    }

    public sCoord g()
    {
        if (this.a.l.k.c == eNavType.Target)
        {
            if (this.a.l.k.d == 0)
            {
                return dh.a(PluginCore.cg, this.a.ax.get_Actions());
            }
            if (this.a.l.k.b.Count == 0)
            {
                return dh.a(PluginCore.cg, this.a.ax.get_Actions());
            }
            return this.a.l.k.b[0].e();
        }
        if (this.a.l.k.b.Count == 0)
        {
            return new sCoord();
        }
        return this.a.l.k.b[this.a.n.l].e();
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
        return (this.e() < 0.0);
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

