using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using uTank2;

internal static class bq
{
    private const int a = 800;
    private const int b = 0x19;
    private const int c = 0x7d0;
    private static List<e> d = new List<e>();

    private static f a(f A_0, int A_1)
    {
        bq.f f = A_0;
        bq.f f2 = null;
        double minValue = double.MinValue;
        bool flag = false;
        foreach (bq.e e in d)
        {
            if (((f.b.b != f.b.c) || (!(e is bq.d) && !(e is bq.b))) && (!(e is bq.d) || (f.b.a >= 0x19)))
            {
                bq.f f3 = f.a(e);
                if (f3.b.b >= A_1)
                {
                    flag = true;
                    if (f2 == null)
                    {
                        f2 = f3;
                        minValue = 0.0;
                    }
                    else if (!f2.c())
                    {
                        if (f3.c())
                        {
                            f2 = f3;
                        }
                        else
                        {
                            double num2 = 0.0;
                            double num3 = 0.0;
                            if (e is bq.a)
                            {
                                num2 = 3200.0;
                                num3 = 180.0;
                            }
                            double num4 = ((num3 + f.b.a) - f3.b.a) / ((num2 + f3.b.d) - f.b.d);
                            if (num4 > minValue)
                            {
                                minValue = num4;
                                f2 = f3;
                            }
                        }
                    }
                    else if (f3.c() && f2.c())
                    {
                        double num5 = f3.b.d - f.b.d;
                        double num6 = f2.b.d - f.b.d;
                        if (num5 < num6)
                        {
                            f2 = f3;
                        }
                    }
                }
            }
        }
        if (!flag)
        {
            foreach (bq.e e2 in d)
            {
                if (((f.b.b != f.b.c) || (!(e2 is bq.d) && !(e2 is bq.b))) && (!(e2 is bq.d) || (f.b.a >= 0x19)))
                {
                    bq.f f4 = f.a(e2);
                    if (f2 == null)
                    {
                        f2 = f4;
                        minValue = 0.0;
                    }
                    else if (!f2.c())
                    {
                        if (f4.c())
                        {
                            f2 = f4;
                        }
                        else
                        {
                            double num7 = 0.0;
                            double num8 = 0.0;
                            if (e2 is bq.a)
                            {
                                num7 = 3200.0;
                                num8 = 180.0;
                            }
                            double num9 = ((num8 + f.b.a) - f4.b.a) / ((num7 + f4.b.d) - f.b.d);
                            if (num9 > minValue)
                            {
                                minValue = num9;
                                f2 = f4;
                            }
                        }
                    }
                    else if (f4.c() && f2.c())
                    {
                        double num10 = f4.b.d - f.b.d;
                        double num11 = f2.b.d - f.b.d;
                        if (num10 < num11)
                        {
                            f2 = f4;
                        }
                    }
                }
            }
        }
        if (f2 == null)
        {
            f2 = f.a(bq.b.a());
        }
        return f2;
    }

    public static MySpell a(int A_0, int A_1, int A_2, int A_3, bool A_4, bool A_5)
    {
        d.Clear();
        if (A_4)
        {
            foreach (v v in PluginCore.cq.x.c["DrainSpellOptions"].d())
            {
                MySpell spell = PluginCore.cq.e.b(k.e(v[0]));
                if (PluginCore.cq.h.c(spell))
                {
                    d.Add(new bq.d(spell, k.e(v[1]), k.f(v[2]), k.f(v[4]), k.e(v[3])));
                }
            }
        }
        foreach (v v2 in PluginCore.cq.x.c["MartyrSpellOptions"].d())
        {
            if ((A_5 && (k.e(v2[0]) == 0xeea)) || (!A_5 && (k.e(v2[0]) != 0xeea)))
            {
                MySpell spell2 = PluginCore.cq.e.b(k.e(v2[0]));
                if (PluginCore.cq.h.c(spell2))
                {
                    d.Add(new bq.a(spell2, k.e(v2[1]), k.f(v2[2]), k.f(v2[3])));
                }
            }
        }
        d.Add(bq.b.a());
        bq.f f = new bq.f {
            b = new bq.c(A_0, A_1, A_3)
        };
        bq.f f2 = b(f, A_2);
        if ((f2 == null) || (f2.a.Count <= 0))
        {
            return null;
        }
        if (f2.a[0] is bq.b)
        {
            return null;
        }
        return f2.a[0].b;
    }

    private static f b(f A_0, int A_1)
    {
        f item = new f {
            b = new bq.c(A_0.b.b, A_0.b.c, A_0.b.a)
        };
        f f2 = null;
        int num = 0;
        int num2 = 0;
        if (A_0.b.a < 300)
        {
            do
            {
                num += 600;
                Stack<f> stack = new Stack<f>();
                stack.Push(item);
                while (stack.Count > 0)
                {
                    f f3 = stack.Pop();
                    num2++;
                    if (num2 >= 0x7d0)
                    {
                        break;
                    }
                    bool flag = false;
                    foreach (bq.e e in d)
                    {
                        if (((f3.b.b != f3.b.c) || (!(e is bq.d) && !(e is bq.b))) && (!(e is bq.d) || (f3.b.a >= 0x19)))
                        {
                            f f4 = f3.a(e);
                            if ((f4.b() <= num) && (f4.b.b >= A_1))
                            {
                                flag = true;
                                if (f4.c())
                                {
                                    if (f2 != null)
                                    {
                                        if (f4.a() < f2.a())
                                        {
                                            f2 = f4;
                                        }
                                    }
                                    else
                                    {
                                        f2 = f4;
                                    }
                                }
                                else
                                {
                                    stack.Push(f4);
                                }
                            }
                        }
                    }
                    if (!flag)
                    {
                        foreach (bq.e e2 in d)
                        {
                            if (((f3.b.b != f3.b.c) || (!(e2 is bq.d) && !(e2 is bq.b))) && (!(e2 is bq.d) || (f3.b.a >= 0x19)))
                            {
                                f f5 = f3.a(e2);
                                if (f5.b() <= num)
                                {
                                    if (f5.c())
                                    {
                                        if (f2 != null)
                                        {
                                            if (f5.a() < f2.a())
                                            {
                                                f2 = f5;
                                            }
                                        }
                                        else
                                        {
                                            f2 = f5;
                                        }
                                    }
                                    else
                                    {
                                        stack.Push(f5);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            while (f2 == null);
        }
        if (f2 != null)
        {
            return f2;
        }
        return a(A_0, A_1);
    }

    private class a : bq.e
    {
        public readonly double a;
        public readonly double b;

        public a(MySpell A_0, int A_1, double A_2, double A_3) : base(A_0, A_1)
        {
            this.a = A_2;
            this.b = A_3;
        }

        public override bq.c a(bq.c A_0)
        {
            bq.c c = A_0;
            int num = (int) Math.Round((double) (c.b * this.a));
            c.b -= num;
            c.a -= (int) Math.Round((double) (num * this.b));
            if (c.a < 0)
            {
                c.a = 0;
            }
            c.d += base.a;
            return c;
        }
    }

    private class b : bq.e
    {
        public b(MySpell A_0) : base(A_0, 0x992)
        {
        }

        public static bq.b a()
        {
            return new bq.b(null);
        }

        public override bq.c a(bq.c A_0)
        {
            bq.c c = A_0;
            c.b += 0x73;
            if (c.b > c.c)
            {
                c.b = c.c;
            }
            c.d += base.a;
            return c;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct c
    {
        public int a;
        public int b;
        public readonly int c;
        public int d;
        public c(int A_0, int A_1, int A_2)
        {
            this.d = 0;
            this.c = A_1;
            this.b = A_0;
            this.a = A_2;
        }

        public int b()
        {
            return (this.c - this.b);
        }

        public bool a()
        {
            return (this.a <= 0);
        }
    }

    private class d : bq.e
    {
        public readonly double a;
        public readonly double b;
        public readonly int c;

        public d(MySpell A_0, int A_1, double A_2, double A_3, int A_4) : base(A_0, A_1)
        {
            this.a = A_2;
            this.b = A_3;
            this.c = A_4;
        }

        public override bq.c a(bq.c A_0)
        {
            bq.c c = A_0;
            int a = (int) Math.Round((double) (A_0.a * this.a));
            if (a > A_0.a)
            {
                a = A_0.a;
            }
            if (a > this.c)
            {
                a = this.c;
            }
            int num2 = (int) Math.Round((double) (a * this.b));
            if (num2 > A_0.b())
            {
                a -= (int) Math.Round((double) ((num2 - A_0.b()) / this.b));
                if (a < 0)
                {
                    a = 0;
                }
                num2 = A_0.b();
            }
            c.b += num2;
            c.a -= a;
            c.d += base.a;
            return c;
        }
    }

    private abstract class e
    {
        public readonly int a;
        public readonly MySpell b;

        protected e(MySpell A_0, int A_1)
        {
            this.b = A_0;
            this.a = A_1 + 800;
        }

        public abstract bq.c a(bq.c A_0);
    }

    private class f
    {
        public List<bq.e> a = new List<bq.e>();
        public bq.c b = new bq.c();

        public int a()
        {
            return (this.a.Count + this.b.d);
        }

        public bq.f a(bq.e A_0)
        {
            bq.f f = new bq.f();
            foreach (bq.e e in this.a)
            {
                f.a.Add(e);
            }
            f.a.Add(A_0);
            f.b = A_0.a(this.b);
            return f;
        }

        public int b()
        {
            return (this.b.d + ((0x3e8 * this.b.a) / 0x6a));
        }

        public bool c()
        {
            return this.b.a();
        }
    }
}

