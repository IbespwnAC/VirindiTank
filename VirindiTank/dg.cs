using System;
using System.Collections.Generic;
using System.IO;
using uTank2;

internal class dg : IDisposable
{
    private ev a;
    public MySortedList<int, MySortedList<int, MySortedList<int, dg.a>>> b = new MySortedList<int, MySortedList<int, MySortedList<int, dg.a>>>(0x34);
    public MySortedList<int, MySortedList<int, MyList<dg.b>>> c = new MySortedList<int, MySortedList<int, MyList<dg.b>>>(0x35);
    private e3 d = new e3();
    private bool e;
    private string f;
    private bf g;

    public dg(ev A_0)
    {
        this.a = A_0;
        this.d.a(0x3df);
        this.a.g.a(new dv.b(this.b));
        this.a.z.a(new s.a(this.a));
        this.d.a(new EventHandler(this.a));
        this.d.d();
    }

    private void a()
    {
        foreach (v v in this.g["Spells"].d())
        {
            MySpell spell = PluginCore.cq.e.b(k.e(v[0]));
            int num = k.e(v[1]) - dh.a();
            if (num >= 0)
            {
                DateTimeOffset offset = DateTimeOffset.Now + TimeSpan.FromSeconds((double) num);
                this.a(spell, k.e(v[2]), offset);
            }
        }
    }

    public void a(int A_0)
    {
        if (this.b.ContainsKey(A_0))
        {
            for (int i = this.b[A_0].Keys.Count - 1; i >= 0; i--)
            {
                int num2 = this.b[A_0].Keys[i];
                for (int j = this.b[A_0][num2].Keys.Count - 1; j >= 0; j--)
                {
                    int num4 = this.b[A_0][num2].Keys[j];
                    this.b[A_0][num2][num4].a = this.b[A_0][num2][num4].b;
                }
            }
        }
    }

    public bool a(int A_0, int A_1)
    {
        return (this.b.ContainsKey(A_0) && this.b[A_0].ContainsKey(A_1));
    }

    public TimeSpan a(int A_0, MySpell A_1)
    {
        if (A_1 == null)
        {
            return TimeSpan.Zero;
        }
        TimeSpan zero = TimeSpan.Zero;
        if (this.c.ContainsKey(A_0) && this.c[A_0].ContainsKey(A_1.RealFamily))
        {
            foreach (dg.b b in this.c[A_0][A_1.RealFamily])
            {
                if ((PluginCore.cq.e.b(b.c).Quality >= A_1.Quality) && (b.a > DateTimeOffset.Now))
                {
                    return TimeSpan.MaxValue;
                }
            }
        }
        if (this.b.ContainsKey(A_0) && this.b[A_0].ContainsKey(A_1.RealFamily))
        {
            int quality = A_1.Quality;
            for (int i = 0; i < this.b[A_0][A_1.RealFamily].Keys.Count; i++)
            {
                int num3 = this.b[A_0][A_1.RealFamily].Keys[i];
                if (this.a.e.b(num3).Quality >= quality)
                {
                    TimeSpan span2 = (TimeSpan) (this.b[A_0][A_1.RealFamily][num3].a - DateTimeOffset.Now);
                    if (span2 > zero)
                    {
                        zero = span2;
                    }
                }
            }
        }
        return zero;
    }

    private void a(object A_0, EventArgs A_1)
    {
        try
        {
            for (int i = this.c.Keys.Count - 1; i >= 0; i--)
            {
                int key = this.c.Keys[i];
                for (int k = this.c[key].Keys.Count - 1; k >= 0; k--)
                {
                    int num4 = this.c[key].Keys[k];
                    for (int m = this.c[key][num4].Count - 1; m >= 0; m--)
                    {
                        dg.b b = this.c[key][num4][m];
                        if (b.a < DateTimeOffset.Now)
                        {
                            this.c[key][num4].RemoveAt(m);
                            if (this.c[key][num4].Count == 0)
                            {
                                this.c[key].Remove(num4);
                                if (this.c[key].Count == 0)
                                {
                                    this.c.Remove(key);
                                }
                            }
                        }
                    }
                }
            }
            for (int j = this.b.Keys.Count - 1; j >= 0; j--)
            {
                int num7 = this.b.Keys[j];
                for (int n = this.b[num7].Keys.Count - 1; n >= 0; n--)
                {
                    int num9 = this.b[num7].Keys[n];
                    for (int num10 = this.b[num7][num9].Keys.Count - 1; num10 >= 0; num10--)
                    {
                        int num11 = this.b[num7][num9].Keys[num10];
                        if (this.b[num7][num9][num11].b < DateTimeOffset.Now)
                        {
                            this.b[num7][num9].Remove(num11);
                            if (this.b[num7][num9].Count == 0)
                            {
                                this.b[num7].Remove(num9);
                                if (this.b[num7].Count == 0)
                                {
                                    this.b.Remove(num7);
                                }
                            }
                        }
                    }
                }
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    public void a(MySpell A_0, int A_1)
    {
        if (A_0.Duration > 0.0)
        {
            this.a(A_0, A_1, DateTimeOffset.Now + TimeSpan.FromMilliseconds(A_0.DurationMS));
            this.a(A_1, A_0.Id, (int) A_0.Duration);
            PluginCore.PC.d(A_0.Id, A_1, (int) A_0.DurationMS);
        }
    }

    private void a(int A_0, int A_1, int A_2)
    {
        if ((A_0 == PluginCore.cg) || PluginCore.cq.p.b(A_0, PluginCore.cq.ax))
        {
            this.b();
            v v = new v(this.g["Spells"]);
            v[0] = k.a(A_1);
            v[1] = k.a((int) (dh.a() + A_2));
            v[2] = k.a(A_0);
            v[3] = k.a(dh.a());
            this.g["Spells"].c(v);
            this.g.c(this.f);
        }
    }

    private void a(MySpell A_0, int A_1, DateTimeOffset A_2)
    {
        if (!this.b.ContainsKey(A_1))
        {
            this.b.Add(A_1, new MySortedList<int, MySortedList<int, dg.a>>(0x36));
        }
        if (!this.b[A_1].ContainsKey(A_0.RealFamily))
        {
            this.b[A_1].Add(A_0.RealFamily, new MySortedList<int, dg.a>(0x37));
        }
        if (!this.b[A_1][A_0.RealFamily].ContainsKey(A_0.Id))
        {
            this.b[A_1][A_0.RealFamily].Add(A_0.Id, new dg.a(DateTimeOffset.MinValue));
        }
        if (this.a.i.b[A_1][A_0.RealFamily][A_0.Id].b < A_2)
        {
            PluginCore.cq.n.a(string.Format("Cast {0} on {1} ending at {2}, OVERRIDDEN", A_0.Name, A_1, A_2.ToString()), e8.e);
            this.b[A_1][A_0.RealFamily][A_0.Id] = new dg.a(A_2);
        }
        else
        {
            PluginCore.cq.n.a(string.Format("Cast {0} on {1} ending at {2}, newer already present", A_0.Name, A_1, A_2.ToString()), e8.e);
        }
    }

    private void a(MySpell A_0, int A_1, bool A_2, bool A_3)
    {
        this.a(A_0, A_1);
    }

    private void b()
    {
        MyList<v> list = this.g["Spells"].d();
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (k.e(list[i][1]) < dh.a())
            {
                this.g["Spells"].e(i);
            }
        }
    }

    public void b(int A_0)
    {
        if (this.b.ContainsKey(A_0))
        {
            for (int i = this.b[A_0].Keys.Count - 1; i >= 0; i--)
            {
                int num2 = this.b[A_0].Keys[i];
                for (int j = this.b[A_0][num2].Keys.Count - 1; j >= 0; j--)
                {
                    int num4 = this.b[A_0][num2].Keys[j];
                    this.b[A_0][num2][num4].a = DateTimeOffset.Now;
                }
            }
        }
    }

    public void b(int A_0, int A_1, int A_2)
    {
        if (this.a.e.c(A_0))
        {
            MySpell spell = PluginCore.cq.e.b(A_0);
            if (!this.c.ContainsKey(A_1))
            {
                this.c.Add(A_1, new MySortedList<int, MyList<dg.b>>(0x38));
            }
            if (!this.c[A_1].ContainsKey(spell.RealFamily))
            {
                this.c[A_1].Add(spell.RealFamily, new MyList<dg.b>(0x39));
            }
            PluginCore.cq.n.a(string.Format("External attempt {0} on {1}", spell.Name, A_1), e8.e);
            this.c[A_1][spell.RealFamily].Add(new dg.b(DateTimeOffset.Now + TimeSpan.FromMilliseconds(6000.0), A_2, A_0));
        }
    }

    private void b(MySpell A_0, int A_1, bool A_2, bool A_3)
    {
        if (A_0.Duration > 0.0)
        {
            this.a(A_0, A_1, DateTimeOffset.Now + TimeSpan.FromMilliseconds((double) A_0.EffectiveDurationMS));
            this.a(A_1, A_0.Id, A_0.EffectiveDurationS);
            PluginCore.PC.d(A_0.Id, A_1, A_0.EffectiveDurationMS);
        }
    }

    private int c()
    {
        int num = 0;
        foreach (v v in this.g["Spells"].d())
        {
            if ((k.e(v[3]) > dh.a()) && (k.e(v[3]) > num))
            {
                num = k.e(v[3]);
            }
        }
        return num;
    }

    public void c(int A_0)
    {
    }

    public void d()
    {
        if (!this.e)
        {
            this.e = true;
            GC.SuppressFinalize(this);
            this.a.g.b(new dv.b(this.b));
            this.a.z.b(new s.a(this.a));
            this.d.b(new EventHandler(this.a));
            this.d.f();
            this.d.e();
            this.a = null;
        }
    }

    public void e()
    {
        this.f = Path.Combine(PluginCore.ci, PluginCore.cq.aw.get_CharacterFilter().get_Name() + "_" + PluginCore.cq.aw.get_CharacterFilter().get_Server() + ".ast");
        try
        {
            this.g = new bf(this.f);
            int num = this.c();
            if (num > 0)
            {
                this.g = new bf();
                this.g.d("uTank2.Resources.defaultitemagedb.ugd");
                this.g.c(this.f);
                a5.a(eChatType.Warnings, "Rollback detected. Resetting stored item spell timers. (Spell cast " + ((num - dh.a())).ToString() + " seconds in the future)");
            }
            else
            {
                this.a();
            }
        }
        catch (Exception)
        {
            this.g = new bf();
            this.g.d("uTank2.Resources.defaultitemagedb.ugd");
            this.g.c(this.f);
        }
    }

    public void f()
    {
        foreach (KeyValuePair<int, MySortedList<int, MySortedList<int, dg.a>>> pair in this.b)
        {
            foreach (KeyValuePair<int, MySortedList<int, dg.a>> pair2 in pair.Value)
            {
                foreach (KeyValuePair<int, dg.a> pair3 in pair2.Value)
                {
                    pair3.Value.a = pair3.Value.b;
                }
            }
        }
    }

    public void g()
    {
        foreach (KeyValuePair<int, MySortedList<int, MySortedList<int, dg.a>>> pair in this.b)
        {
            foreach (KeyValuePair<int, MySortedList<int, dg.a>> pair2 in pair.Value)
            {
                foreach (KeyValuePair<int, dg.a> pair3 in pair2.Value)
                {
                    pair3.Value.a = DateTimeOffset.Now;
                }
            }
        }
    }

    protected override void h()
    {
        try
        {
            this.d();
        }
        finally
        {
            base.Finalize();
        }
    }

    public class a
    {
        public DateTimeOffset a;
        public DateTimeOffset b;

        public a(DateTimeOffset A_0)
        {
            this.a = A_0;
            this.b = A_0;
        }
    }

    public class b
    {
        public DateTimeOffset a;
        public int b;
        public int c;

        public b(DateTimeOffset A_0, int A_1, int A_2)
        {
            this.a = A_0;
            this.b = A_1;
            this.c = A_2;
        }
    }
}

