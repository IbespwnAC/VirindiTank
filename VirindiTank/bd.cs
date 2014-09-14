using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using uTank2;

internal class bd : IDisposable
{
    private Dictionary<int, bool> a = new Dictionary<int, bool>();
    private bool b;
    private bool c;
    private int d;
    private int e;
    private int f;
    private int g;
    private int h;

    public void a()
    {
        if (!this.b)
        {
            this.b = true;
            GC.SuppressFinalize(this);
        }
    }

    protected override void b()
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

    public void c()
    {
        if ((this.f == this.d) && (this.g == this.e))
        {
            this.h++;
            if (this.h > 80)
            {
                this.a[this.d] = true;
                this.a[this.e] = true;
                PluginCore.e(string.Format("Abandoned trying to stack/cram items {0}, {1} (Bugged item and/or pack)", this.d, this.e));
                return;
            }
        }
        else
        {
            this.f = this.d;
            this.g = this.e;
            this.h = 0;
        }
        if (this.c)
        {
            PluginCore.cq.ax.get_Actions().MoveItem(this.d, this.e);
        }
        else
        {
            PluginCore.cq.ax.get_Actions().MoveItem(this.d, this.e, 0, true);
        }
    }

    public bool d()
    {
        bool flag = false;
        int num = 0;
        int k = 0;
        if (er.j("AutoStack"))
        {
            MySortedDictionary<bd.a, int> dictionary = new MySortedDictionary<bd.a, int>(0x66);
            foreach (cv cv in PluginCore.cq.p.d())
            {
                if (!this.a.ContainsKey(cv.k))
                {
                    int num3 = cv.a(dt.cu, 0);
                    int num4 = cv.a(dt.ct, 0);
                    if (((num3 != 0) && (num4 != 0)) && (num4 < num3))
                    {
                        bd.a key = new bd.a {
                            a = cv.g(),
                            b = cv.a(dt.co, 0)
                        };
                        if (dictionary.ContainsKey(key))
                        {
                            if (dictionary[key] == cv.k)
                            {
                                continue;
                            }
                            num = dictionary[key];
                            k = cv.k;
                            flag = true;
                            break;
                        }
                        dictionary.Add(key, cv.k);
                    }
                }
            }
        }
        if (er.j("AutoCram") && !flag)
        {
            ReadOnlyCollection<cv> onlys2 = PluginCore.cq.p.e(PluginCore.cg);
            int num5 = 0;
            bool flag2 = false;
            foreach (cv cv2 in onlys2)
            {
                if ((!this.a.ContainsKey(cv2.k) && (cv2.c() != ObjectClass.Container)) && ((cv2.c() != ObjectClass.Foci) && (cv2.a(dt.d, -9999) == -9999)))
                {
                    num5 = cv2.k;
                    flag2 = true;
                    break;
                }
            }
            if (flag2)
            {
                ReadOnlyCollection<cv> onlys3 = PluginCore.cq.p.a(ObjectClass.Container);
                bool flag3 = false;
                int num6 = 0;
                foreach (cv cv3 in onlys3)
                {
                    if (!this.a.ContainsKey(cv3.k) && (PluginCore.cq.p.f(cv3.k) == PluginCore.cg))
                    {
                        int num7 = cv3.a(dt.cr, 0);
                        if ((num7 != 0) && (PluginCore.cq.p.e(cv3.k).Count < num7))
                        {
                            flag3 = true;
                            num6 = cv3.k;
                            break;
                        }
                    }
                }
                if (flag3)
                {
                    this.c = false;
                    this.d = num5;
                    this.e = num6;
                    return true;
                }
            }
        }
        if (flag)
        {
            this.c = true;
            this.d = num;
            this.e = k;
            return true;
        }
        return false;
    }

    private class a : IComparable<bd.a>
    {
        public string a;
        public int b;

        public int a(bd.a A_0)
        {
            int num = this.a.CompareTo(A_0.a);
            if (num != 0)
            {
                return num;
            }
            return this.b.CompareTo(A_0.b);
        }
    }
}

