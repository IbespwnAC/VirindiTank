using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using uTank2;

internal class b0 : IDisposable
{
    private WorldFilter a;
    private bool b;
    private int c;
    private e3 d = new e3();
    private MyList<int> e = new MyList<int>(0x54);
    private MyDictionary<int, List<b0.b>> f = new MyDictionary<int, List<b0.b>>(0x55);
    private MyDictionary<int, b0.a> g = new MyDictionary<int, b0.a>(0x56);
    private MyDictionary<b0.a, int> h = new MyDictionary<b0.a, int>(0x57);

    public b0(CoreManager A_0, PluginCore A_1, cj A_2)
    {
        this.a = A_0.get_WorldFilter();
        A_2.l(new cj.c(this.a));
        this.d.a(new EventHandler(this.a));
        this.d.a(0x1f3);
        this.d.a(true);
    }

    public void a()
    {
        if (!this.b)
        {
            this.b = true;
            GC.SuppressFinalize(this);
            this.d.b(new EventHandler(this.a));
            if (this.d != null)
            {
                this.d.e();
            }
            PluginCore.cq.p.k(new cj.c(this.a));
            this.a = null;
        }
    }

    public void a(b0.a A_0)
    {
        MyList<int> list = new MyList<int>(0x59);
        foreach (KeyValuePair<int, b0.a> pair in this.g)
        {
            if (((b0.a) pair.Value) == A_0)
            {
                list.Add(pair.Key);
            }
        }
        foreach (int num in list)
        {
            if (this.e.Contains(num))
            {
                this.e.Remove(num);
            }
            if (this.g.ContainsKey(num))
            {
                Dictionary<b0.a, int> dictionary;
                b0.a a;
                (dictionary = this.h)[a = this.g[num]] = dictionary[a] - 1;
                this.g.Remove(num);
            }
            this.a(num, false);
        }
        l.i();
    }

    private void a(cv A_0)
    {
        int k = A_0.k;
        if (this.e.Contains(k))
        {
            this.e.Remove(k);
            if (this.g.ContainsKey(k))
            {
                Dictionary<b0.a, int> dictionary;
                b0.a a;
                (dictionary = this.h)[a = this.g[k]] = dictionary[a] - 1;
                this.g.Remove(k);
            }
            this.a(k, true);
            l.i();
        }
    }

    public bool a(int A_0)
    {
        if (PluginCore.cg == 0)
        {
            return true;
        }
        if (!dh.b(A_0))
        {
            return true;
        }
        if (PluginCore.cq.aw.get_WorldFilter().get_Item(A_0).get_Container() != 0)
        {
            return false;
        }
        return (dh.a(A_0, PluginCore.cg, true) > PluginCore.cq.n.p);
    }

    public void a(int A_0, b0.a A_1)
    {
        if (!this.e.Contains(A_0))
        {
            if (this.h.ContainsKey(A_1))
            {
                Dictionary<b0.a, int> dictionary;
                b0.a a;
                (dictionary = this.h)[a = A_1] = dictionary[a] + 1;
            }
            else
            {
                this.h[A_1] = 1;
            }
            this.g[A_0] = A_1;
            this.e.Add(A_0);
            l.i();
        }
    }

    private void a(int A_0, b0.b A_1)
    {
        if (A_1 != null)
        {
            if (!this.f.ContainsKey(A_0))
            {
                this.f.Add(A_0, new List<b0.b>());
            }
            this.f[A_0].Add(A_1);
        }
    }

    private void a(int A_0, bool A_1)
    {
        if (this.f.ContainsKey(A_0))
        {
            List<b0.b> list = this.f[A_0];
            this.f.Remove(A_0);
            foreach (b0.b b in list)
            {
                b(A_0, A_1);
            }
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        try
        {
            MyList<int> list = new MyList<int>(0x58);
            for (int i = 0; i < this.e.Count; i++)
            {
                if (!dh.b(this.e[i]))
                {
                    list.Add(this.e[i]);
                    if (i < this.c)
                    {
                        this.c--;
                    }
                }
            }
            foreach (int num2 in list)
            {
                if (this.e.Contains(num2))
                {
                    this.e.Remove(num2);
                }
                if (this.g.ContainsKey(num2))
                {
                    Dictionary<b0.a, int> dictionary;
                    b0.a a;
                    (dictionary = this.h)[a = this.g[num2]] = dictionary[a] - 1;
                    this.g.Remove(num2);
                }
                this.a(num2, false);
            }
            if (this.e.Count == 0)
            {
                l.i();
                return;
            }
            this.c++;
            if (this.c < 0)
            {
                this.c = 0;
            }
            if (this.c >= this.e.Count)
            {
                this.c = 0;
            }
            int c = this.c;
            int num4 = 0;
            do
            {
                if (!this.a(this.e[c]))
                {
                    int num5 = this.e[c];
                    PluginCore.cq.ax.get_Actions().RequestId(num5);
                    break;
                }
                c++;
                if (c >= this.e.Count)
                {
                    c = 0;
                }
                num4++;
            }
            while ((num4 <= this.e.Count) && (c != this.c));
            this.c = c;
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
        l.i();
    }

    public void a(int A_0, b0.b A_1, b0.a A_2)
    {
        if (this.e.Contains(A_0))
        {
            this.a(A_0, A_1);
        }
        else
        {
            if (this.h.ContainsKey(A_2))
            {
                Dictionary<b0.a, int> dictionary;
                b0.a a;
                (dictionary = this.h)[a = A_2] = dictionary[a] + 1;
            }
            else
            {
                this.h[A_2] = 1;
            }
            this.g[A_0] = A_2;
            this.e.Add(A_0);
            this.a(A_0, A_1);
            l.i();
        }
    }

    public int b()
    {
        return this.e.Count;
    }

    public int b(b0.a A_0)
    {
        if (this.h.ContainsKey(A_0))
        {
            return this.h[A_0];
        }
        return 0;
    }

    public bool b(int A_0)
    {
        return this.e.Contains(A_0);
    }

    public void b(int A_0, b0.b A_1)
    {
        if (this.e.Contains(A_0))
        {
            this.a(A_0, A_1);
        }
        else
        {
            this.e.Add(A_0);
            this.a(A_0, A_1);
            l.i();
        }
    }

    protected override void c()
    {
        try
        {
            this.a();
        }
        finally
        {
            base.Finalize();
        }
    }

    public bool c(b0.a A_0)
    {
        foreach (int num in this.e)
        {
            if ((!this.a(num) && this.g.ContainsKey(num)) && (((b0.a) this.g[num]) == A_0))
            {
                return true;
            }
        }
        return false;
    }

    public void c(int A_0)
    {
        if (!this.e.Contains(A_0))
        {
            this.e.Add(A_0);
            l.i();
        }
    }

    public bool d()
    {
        foreach (int num in this.e)
        {
            if (!this.a(num))
            {
                return true;
            }
        }
        return false;
    }

    public enum a
    {
        a,
        b,
        c,
        d
    }

    public delegate void b(int A_0, bool A_1);

    [StructLayout(LayoutKind.Sequential)]
    public struct c
    {
        public MyList<int> a;
        public MyDictionary<int, List<b0.b>> b;
        public MyDictionary<int, b0.a> c;
        public MyDictionary<b0.a, int> d;
        public c(b0 A_0)
        {
            this.a = A_0.e;
            this.b = A_0.f;
            this.c = A_0.g;
            this.d = A_0.h;
        }
    }
}

