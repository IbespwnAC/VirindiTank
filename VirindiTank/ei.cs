using Decal.Adapter;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using uTank2;

internal class ei : IDisposable
{
    private int a;
    private int b = -1;
    private int c;
    private DateTimeOffset d = DateTimeOffset.MinValue;
    private DateTimeOffset e = DateTimeOffset.MaxValue;
    private DateTimeOffset f = DateTimeOffset.MaxValue;
    private PluginCore.EmptyDelegate g;
    private PluginCore.EmptyDelegate h;
    private e3 i;
    private bool j;
    private static List<ei.a> k = new List<ei.a>();

    static ei()
    {
        k.Add(new ei.a(7, "(?:You .* for )([0-9]+)(?: points with .*)"));
    }

    public ei(dv A_0, cj A_1)
    {
        A_0.b(new dv.c(this.a));
        PluginCore.PC.a(new uTank2.PluginCore.a(this.a));
        this.i = new e3();
        this.i.a(0xdac);
        this.i.a(new EventHandler(this.a));
        this.i.d();
    }

    private void a()
    {
        if (this.a != 0)
        {
            if (!dh.a(this.a))
            {
                this.b(0);
            }
            else if (PluginCore.cq.n.b)
            {
                TimeSpan span = (TimeSpan) (DateTimeOffset.Now - this.d);
                if (span.TotalSeconds >= 3.0)
                {
                    this.i();
                }
            }
        }
    }

    private void a(int A_0)
    {
        if (this.b != A_0)
        {
            this.b = A_0;
            if (this.h != null)
            {
                this.h();
            }
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void a(PluginCore.EmptyDelegate A_0)
    {
        this.h = (PluginCore.EmptyDelegate) Delegate.Combine(this.h, A_0);
    }

    private void a(object A_0, NetworkMessageEventArgs A_1)
    {
        if ((PluginCore.cq.n.b && ((A_1.get_Message().get_Type() == 0xf7b0) && (A_1.get_Message().Value<int>("event") == 0x1c0))) && (this.a != 0))
        {
            if (!dh.a(this.a))
            {
                this.b(0);
            }
            else
            {
                int num = A_1.get_Message().Value<int>("object");
                float num2 = A_1.get_Message().Value<float>("health");
                if (num == this.a)
                {
                    string str = PluginCore.cq.p.d(this.a).g();
                    v v = PluginCore.cq.x.c["SpeciesMembers"].a(0, k.a(str));
                    if (v == null)
                    {
                        if (PluginCore.cq.p.d(num) != null)
                        {
                            PluginCore.cq.x.b(num);
                        }
                    }
                    else
                    {
                        this.f = DateTimeOffset.Now;
                        this.a((int) Math.Round((double) (num2 * k.e(v[2]))));
                    }
                }
            }
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        this.a();
    }

    private void a(MySpell A_0, int A_1, bool A_2, bool A_3, ChatTextInterceptEventArgs A_4)
    {
        if ((A_1 == this.a) && (A_1 != 0))
        {
            this.i();
            if (!A_0.HitsMultipleTargets)
            {
                if (A_2)
                {
                    this.b(0);
                }
                else
                {
                    foreach (ei.a a in k)
                    {
                        if (A_4.get_Color() == a.b)
                        {
                            int num;
                            Match match = a.a.Match(A_4.get_Text());
                            if (match.Success && int.TryParse(match.Groups[1].Value, out num))
                            {
                                this.a((int) (this.b - num));
                                this.c = num;
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    public int b()
    {
        if (this.a == 0)
        {
            return 0;
        }
        if (!dh.a(this.a))
        {
            return 0;
        }
        if (this.b != -1)
        {
            return this.b;
        }
        string str = PluginCore.cq.p.d(this.a).g();
        v v = PluginCore.cq.x.c["SpeciesMembers"].a(0, k.a(str));
        if (v == null)
        {
            return 0;
        }
        return k.e(v[2]);
    }

    public void b(int A_0)
    {
        if (A_0 != this.a)
        {
            this.a = A_0;
            this.b = -1;
            this.c = 0;
            this.e = DateTimeOffset.Now;
            this.f = DateTimeOffset.MinValue;
            this.i();
            if (this.g != null)
            {
                this.g();
            }
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void b(PluginCore.EmptyDelegate A_0)
    {
        this.g = (PluginCore.EmptyDelegate) Delegate.Remove(this.g, A_0);
    }

    protected override void c()
    {
        try
        {
            this.j();
        }
        finally
        {
            base.Finalize();
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void c(PluginCore.EmptyDelegate A_0)
    {
        this.h = (PluginCore.EmptyDelegate) Delegate.Remove(this.h, A_0);
    }

    public int d()
    {
        return this.c;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void d(PluginCore.EmptyDelegate A_0)
    {
        this.g = (PluginCore.EmptyDelegate) Delegate.Combine(this.g, A_0);
    }

    public DateTimeOffset e()
    {
        return this.f;
    }

    public int f()
    {
        return this.b;
    }

    public DateTimeOffset g()
    {
        return this.e;
    }

    public int h()
    {
        return this.a;
    }

    public void i()
    {
        if ((this.a != 0) && dh.a(this.a))
        {
            this.d = DateTimeOffset.Now;
            dh.j(this.a);
        }
    }

    public void j()
    {
        if (!this.j)
        {
            this.j = true;
            GC.SuppressFinalize(this);
            this.i.e();
            PluginCore.PC.b(new uTank2.PluginCore.a(this.a));
        }
    }

    private class a
    {
        public Regex a;
        public int b;

        public a(int A_0, string A_1)
        {
            this.a = new Regex(A_1);
            this.b = A_0;
        }
    }
}

