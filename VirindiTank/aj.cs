using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using uTank2;

[DefaultMember("Item")]
internal class aj : IDisposable, ci, IEnumerable
{
    private Dictionary<aj.a, aj.c> a = new Dictionary<aj.a, aj.c>();
    private bool b = true;
    private Dictionary<aj.a, Dictionary<int, bool>> c = new Dictionary<aj.a, Dictionary<int, bool>>();
    private e3 d = new e3();
    private bool e;

    public aj()
    {
        this.d.a(0xc155c);
        this.d.a(new EventHandler(this.a));
        this.d.d();
    }

    protected override void a()
    {
        try
        {
            this.g();
        }
        finally
        {
            base.Finalize();
        }
    }

    public void a(aj.c A_0)
    {
        this.a("<DEFAULT>", A_0);
    }

    public aj.c a(cv A_0)
    {
        aj.a key = new aj.a(A_0);
        if (this.b && this.a.ContainsKey(key))
        {
            return this.a[key];
        }
        aj.c c = this.a(key, A_0);
        this.a[key] = c;
        return c;
    }

    public void a(TextReader A_0)
    {
    }

    public void a(TextWriter A_0)
    {
    }

    public void a(string A_0)
    {
        if (this.b)
        {
            this.b = false;
        }
    }

    private aj.c a(aj.a A_0, cv A_1)
    {
        int num = PluginCore.cq.l.c["MyMonsters"].c();
        for (int i = 0; i < num; i++)
        {
            string str = k.b(PluginCore.cq.l.c["MyMonsters"].a(i)[0]);
            if (str != "<DEFAULT>")
            {
                if (this.c.ContainsKey(A_0) && this.c[A_0].ContainsKey(i))
                {
                    if (this.c[A_0][i])
                    {
                        return this.c(str);
                    }
                }
                else
                {
                    bool flag;
                    bool flag2 = dk.a(A_0, str, A_1, out flag);
                    if (flag)
                    {
                        if (!this.c.ContainsKey(A_0))
                        {
                            this.c[A_0] = new Dictionary<int, bool>();
                        }
                        this.c[A_0][i] = flag2;
                    }
                    if (flag2)
                    {
                        return this.c(str);
                    }
                }
            }
        }
        return this.d();
    }

    private void a(object A_0, EventArgs A_1)
    {
        this.c();
    }

    public void a(string A_0, aj.c A_1)
    {
        this.c();
        A_1.t = A_0;
        v v = PluginCore.cq.l.c["MyMonsters"].a(0, k.a(A_0));
        if (v == null)
        {
            PluginCore.cq.l.c["MyMonsters"].c(aj.c.a(A_1));
        }
        else
        {
            v v2 = aj.c.a(A_1);
            for (int i = 0; i < v.Count; i++)
            {
                v[i] = v2[i];
            }
        }
    }

    public void a(string A_0, string A_1)
    {
        this.c();
        v v = PluginCore.cq.l.c["MyMonsters"].a(0, k.a(A_0));
        v v2 = PluginCore.cq.l.c["MyMonsters"].a(0, k.a(A_1));
        if ((v != null) && (v2 != null))
        {
            int num = PluginCore.cq.l.c["MyMonsters"].a(v);
            int num2 = PluginCore.cq.l.c["MyMonsters"].a(v2);
            PluginCore.cq.l.c["MyMonsters"].a(num, num2);
        }
    }

    public IEnumerator b()
    {
        return new aj.b();
    }

    public aj.c b(cv A_0)
    {
        aj.a key = new aj.a(A_0);
        int num = PluginCore.cq.l.c["MyMonsters"].c();
        for (int i = 0; i < num; i++)
        {
            string str = k.b(PluginCore.cq.l.c["MyMonsters"].a(i)[0]);
            if (str != "<DEFAULT>")
            {
                if (this.c.ContainsKey(key) && this.c[key].ContainsKey(i))
                {
                    if (this.c[key][i])
                    {
                        PluginCore.e(string.Format("Entry \"{0}\" match! (Result cached)", str));
                        return this.c(str);
                    }
                    PluginCore.e(string.Format("Entry \"{0}\" does not match. (Result cached)", str));
                }
                else
                {
                    bool flag;
                    if (dk.a(key, str, A_0, out flag))
                    {
                        PluginCore.e(string.Format("Entry \"{0}\" match!", str));
                        return this.c(str);
                    }
                    PluginCore.e(string.Format("Entry \"{0}\" does not match.", str));
                }
            }
        }
        PluginCore.e("No rules match selected monster, using default entry.");
        return this.d();
    }

    public void b(string A_0)
    {
        if (A_0 != "<DEFAULT>")
        {
            this.c();
            v v = PluginCore.cq.l.c["MyMonsters"].a(0, k.a(A_0));
            if (v != null)
            {
                PluginCore.cq.l.c["MyMonsters"].b(v);
            }
        }
    }

    public void c()
    {
        this.c.Clear();
        this.a.Clear();
        this.b = true;
    }

    public aj.c c(string A_0)
    {
        v v = PluginCore.cq.l.c["MyMonsters"].a(0, k.a(A_0));
        if (v == null)
        {
            return this.d();
        }
        return aj.c.a(v);
    }

    public aj.c d()
    {
        return this.c("<DEFAULT>");
    }

    public bool d(string A_0)
    {
        return (PluginCore.cq.l.c["MyMonsters"].a(0, k.a(A_0)) != null);
    }

    public aj.c e()
    {
        return new aj.c { a = 1, f = false, j = false, h = false, g = false, i = false, k = false, l = false, s = false, r = true, b = eDamageElement.Auto, c = eDamageElement.None, d = eSecondaryEquipTypeOrObjectID.Auto, e = -1 };
    }

    public int f()
    {
        return PluginCore.cq.l.c["MyMonsters"].c();
    }

    public void g()
    {
        if (!this.e)
        {
            this.e = true;
            GC.SuppressFinalize(this);
            this.d.e();
        }
    }

    public void h()
    {
        this.c();
        PluginCore.cq.l.c["MyMonsters"].f();
        this.a(this.e());
    }

    public class a : IEquatable<aj.a>
    {
        public string a;
        public int b;

        public a(cv A_0)
        {
            this.a = A_0.g();
            this.b = A_0.a(dt.cn, 0);
        }

        public override int a()
        {
            return (this.a.GetHashCode() ^ this.b.GetHashCode());
        }

        public bool a(aj.a A_0)
        {
            return (this.a.Equals(A_0.a) && this.b.Equals(A_0.b));
        }
    }

    public class b : IEnumerator
    {
        private List<v>.Enumerator a = PluginCore.cq.l.c["MyMonsters"].d().GetEnumerator();

        public void a()
        {
            this.a.Dispose();
            this.a = PluginCore.cq.l.c["MyMonsters"].d().GetEnumerator();
        }

        public bool c()
        {
            return this.a.MoveNext();
        }

        [__DynamicallyInvokable]
        public object System.Collections.IEnumerator.Current
        {
            get
            {
                return aj.c.a(this.a.Current);
            }
        }
    }

    public class c : ci
    {
        public int a;
        public eDamageElement b;
        public eDamageElement c;
        public eSecondaryEquipTypeOrObjectID d;
        public int e;
        public bool f;
        public bool g;
        public bool h;
        public bool i;
        public bool j;
        public bool k;
        public bool l;
        public bool m;
        public bool n;
        public bool o;
        public bool p;
        public bool q;
        public bool r;
        public bool s;
        public string t;
        public bool u;

        public static v a(aj.c A_0)
        {
            v v = new v(PluginCore.cq.l.c["MyMonsters"]);
            v[0] = k.a(A_0.t);
            v[1] = k.a(A_0.a);
            v[2] = k.a((int) A_0.b);
            v[3] = k.a(A_0.e);
            v[4] = k.a(A_0.f);
            v[5] = k.a(A_0.g);
            v[6] = k.a(A_0.h);
            v[7] = k.a(A_0.j);
            v[8] = k.a(!A_0.s);
            v[9] = k.a(A_0.i);
            v[10] = k.a(A_0.k);
            v[11] = k.a(A_0.l);
            v[12] = k.a(A_0.m);
            v[13] = k.a(A_0.n);
            v[14] = k.a(A_0.o);
            v[15] = k.a(A_0.p);
            v[0x10] = k.a(A_0.q);
            v[0x11] = k.a(A_0.r);
            v[0x12] = k.a((int) A_0.c);
            v[0x13] = k.a((int) A_0.d);
            return v;
        }

        public void a(TextReader A_0)
        {
            this.a = Convert.ToInt32(A_0.ReadLine());
            this.b = (eDamageElement) Convert.ToInt32(A_0.ReadLine());
            A_0.ReadLine();
            this.f = Convert.ToBoolean(A_0.ReadLine());
            this.g = Convert.ToBoolean(A_0.ReadLine());
            this.h = Convert.ToBoolean(A_0.ReadLine());
            this.i = Convert.ToBoolean(A_0.ReadLine());
            this.j = Convert.ToBoolean(A_0.ReadLine());
            this.s = Convert.ToBoolean(A_0.ReadLine());
            this.e = Convert.ToInt32(A_0.ReadLine());
            this.k = false;
            this.l = false;
            this.m = false;
            this.n = false;
            this.o = false;
            this.p = false;
            this.q = false;
            this.r = false;
        }

        public void a(TextWriter A_0)
        {
            A_0.WriteLine(this.a.ToString());
            A_0.WriteLine(((int) this.b).ToString());
            A_0.WriteLine(0.ToString());
            A_0.WriteLine(this.f.ToString());
            A_0.WriteLine(this.g.ToString());
            A_0.WriteLine(this.h.ToString());
            A_0.WriteLine(this.i.ToString());
            A_0.WriteLine(this.j.ToString());
            A_0.WriteLine(this.s.ToString());
            A_0.WriteLine(this.e.ToString());
        }

        public static aj.c a(v A_0)
        {
            aj.c c;
            return new aj.c { 
                t = k.b(A_0[0]), a = k.e(A_0[1]), b = (eDamageElement) k.e(A_0[2]), e = k.e(A_0[3]), f = k.a(A_0[4]), g = k.a(A_0[5]), h = k.a(A_0[6]), j = k.a(A_0[7]), s = !k.a(A_0[8]), i = k.a(A_0[9]), k = k.a(A_0[10]), l = k.a(A_0[11]), m = k.a(A_0[12]), n = k.a(A_0[13]), o = k.a(A_0[14]), p = k.a(A_0[15]), 
                q = k.a(A_0[0x10]), r = k.a(A_0[0x11]), c = (eDamageElement) k.e(A_0[0x12]), d = (eSecondaryEquipTypeOrObjectID) k.e(A_0[0x13]), u = c.t == "<DEFAULT>"
             };
        }
    }
}

