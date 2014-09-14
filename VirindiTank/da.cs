using Decal.Adapter.Wrappers;
using System;
using System.Collections.Generic;
using uTank2;

internal class da : IDisposable
{
    public List<int> a = new List<int>();
    public List<int> b = new List<int>();
    public List<int> c = new List<int>();
    private bool d;
    private cj e;
    private bool f;

    public da(cj A_0, PluginCore A_1)
    {
        this.e = A_0;
        this.e.j(new cj.c(this.d));
        this.e.g(new cj.c(this.a));
        this.e.f(new cj.c(this.b));
        this.e.d(new cj.c(this.c));
        A_1.ProfileChanged += new PluginCore.EmptyDelegate(this.b);
    }

    private int a()
    {
        if (this.d)
        {
            return er.i("ManaStoneLootCount");
        }
        return 0;
    }

    private void a(cv A_0)
    {
        if (this.a.Contains(A_0.k))
        {
            this.a.Remove(A_0.k);
        }
        if (this.b.Contains(A_0.k))
        {
            this.b.Remove(A_0.k);
            PluginCore.cq.n.n.a(ActionLockType.ManaStoneUse);
        }
    }

    public bool a(WorldObject A_0)
    {
        if (A_0.get_ObjectClass() != 0x10)
        {
            return false;
        }
        if (!PluginCore.cq.l.h.ContainsKey(A_0.get_Name()))
        {
            return false;
        }
        if (((fz) PluginCore.cq.l.h[A_0.get_Name()]) != fz.i)
        {
            return false;
        }
        return true;
    }

    public bool a(int A_0)
    {
        WorldObject obj2 = PluginCore.cq.aw.get_WorldFilter().get_Item(A_0);
        if (obj2 == null)
        {
            return false;
        }
        return this.a(obj2);
    }

    private void b()
    {
        this.a.Clear();
        this.b.Clear();
        this.d = false;
        foreach (KeyValuePair<string, fz> pair in PluginCore.cq.l.h)
        {
            if (((fz) pair.Value) == fz.i)
            {
                this.d = true;
                if (PluginCore.cq.p.j.ContainsKey(pair.Key))
                {
                    foreach (cv cv in PluginCore.cq.p.j[pair.Key])
                    {
                        if (this.a(cv.k) && PluginCore.cq.p.f(cv))
                        {
                            if (cv.b())
                            {
                                this.b.Add(cv.k);
                            }
                            else
                            {
                                this.a.Add(cv.k);
                            }
                        }
                    }
                }
            }
        }
    }

    private void b(cv A_0)
    {
        if (PluginCore.cq.p.f(A_0) && this.a(A_0.k))
        {
            if (A_0.b())
            {
                this.b.Add(A_0.k);
            }
            else
            {
                this.a.Add(A_0.k);
            }
        }
    }

    public bool b(WorldObject A_0)
    {
        if (!PluginCore.cq.p.i.ContainsKey(A_0.get_Id()))
        {
            return false;
        }
        cv cv = PluginCore.cq.p.i[A_0.get_Id()];
        if (!cv.j)
        {
            return false;
        }
        if (!cv.b())
        {
            return false;
        }
        if (!cv.a.ContainsKey(0x6b))
        {
            return false;
        }
        if (cv.a[0x6b] < er.i("ManaTankMinimumMana"))
        {
            return false;
        }
        if (!cv.a.ContainsKey(0x69))
        {
            return false;
        }
        if (cv.a[0x69] == 0)
        {
            return false;
        }
        if (cv.a.ContainsKey(0xab) && (cv.a[0xab] > 0))
        {
            return false;
        }
        return true;
    }

    public void b(int A_0)
    {
    }

    public void c()
    {
        if (!this.f)
        {
            this.f = true;
            GC.SuppressFinalize(this);
            this.e.i(new cj.c(this.d));
            this.e.a(new cj.c(this.a));
            this.e.b(new cj.c(this.b));
            this.e.e(new cj.c(this.c));
            this.e = null;
            GC.SuppressFinalize(this);
        }
    }

    private void c(cv A_0)
    {
        if (this.a(A_0.k))
        {
            if (PluginCore.cq.p.f(A_0))
            {
                if (!this.a.Contains(A_0.k) && !this.b.Contains(A_0.k))
                {
                    if (A_0.b())
                    {
                        this.b.Add(A_0.k);
                    }
                    else
                    {
                        this.a.Add(A_0.k);
                    }
                }
            }
            else
            {
                if (this.a.Contains(A_0.k))
                {
                    this.a.Remove(A_0.k);
                }
                if (this.b.Contains(A_0.k))
                {
                    this.b.Remove(A_0.k);
                }
            }
        }
    }

    public void c(int A_0)
    {
        if (PluginCore.cq.p.i.ContainsKey(A_0) && PluginCore.cq.p.i[A_0].b())
        {
            this.c.Add(A_0);
        }
    }

    public void d()
    {
        int num = this.c[0];
        int num2 = this.a[0];
        PluginCore.cq.ax.get_Actions().ApplyItem(num2, num);
    }

    private void d(cv A_0)
    {
        if (this.a.Contains(A_0.k))
        {
            if (A_0.b())
            {
                this.a.Remove(A_0.k);
                this.b.Add(A_0.k);
            }
        }
        else if (this.b.Contains(A_0.k) && !A_0.b())
        {
            this.b.Remove(A_0.k);
            this.a.Add(A_0.k);
            PluginCore.cq.n.n.a(ActionLockType.ManaStoneUse);
        }
    }

    public void e()
    {
        List<int> list = new List<int>();
        foreach (int num in this.c)
        {
            if (!PluginCore.cq.p.b(num, PluginCore.cq.ax))
            {
                list.Add(num);
            }
        }
        foreach (int num2 in list)
        {
            this.c.Remove(num2);
        }
    }

    public int f()
    {
        int num = this.a.Count + this.b.Count;
        int num2 = this.a();
        if (num >= num2)
        {
            return 0;
        }
        return (num2 - num);
    }

    public bool g()
    {
        return ((this.c.Count > 0) && (this.a.Count > 0));
    }

    public int h()
    {
        int num = this.a.Count - this.c.Count;
        if (num < 0)
        {
            num = 0;
        }
        return num;
    }

    public int i()
    {
        if (this.b.Count == 0)
        {
            return 0;
        }
        int num = this.b[0];
        if (!PluginCore.cq.p.b(num, PluginCore.cq.ax))
        {
            return 0;
        }
        if (!this.a(num))
        {
            return 0;
        }
        cv cv = PluginCore.cq.p.i[num];
        if (!cv.b())
        {
            return 0;
        }
        return num;
    }
}

