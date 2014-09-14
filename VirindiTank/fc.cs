using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using uTank2;
using uTank2.LootPlugins;

internal class fc : IDisposable
{
    private bool a;
    private MyList<int> b = new MyList<int>(0x1a);
    private Dictionary<int, fc.a> c = new Dictionary<int, fc.a>();
    private bool d;
    private int e;
    private List<int> f = new List<int>();
    private Regex g = new Regex(@"Salvage(d?).* \([0-9]{1,2}\)");
    private MyDictionary<int, int> h = new MyDictionary<int, int>(0x3e8);
    private MyList<int> i = new MyList<int>(0x1b);

    public fc(CoreManager A_0, PluginCore A_1)
    {
        CoreManager.get_Current().get_WorldFilter().add_ReleaseObject(new EventHandler<ReleaseObjectEventArgs>(this.a));
        CoreManager.get_Current().add_ItemDestroyed(new EventHandler<ItemDestroyedEventArgs>(this.a));
    }

    private void a()
    {
        foreach (int num in this.f)
        {
            if (this.h.ContainsKey(num))
            {
                Dictionary<int, int> dictionary;
                int num3;
                (dictionary = this.h)[num3 = num] = dictionary[num3] + 1;
                if (this.h[num] <= 40)
                {
                    continue;
                }
                this.a(num);
                return;
            }
            this.h[num] = 1;
        }
        foreach (int num2 in this.f)
        {
            PluginCore.cq.ax.get_Actions().SalvagePanelAdd(num2);
        }
        PluginCore.cq.ax.get_Actions().SalvagePanelSalvage();
    }

    private void a(int A_0)
    {
        string str = "<UNKNOWN>";
        try
        {
            str = PluginCore.cq.p.d(A_0).e();
        }
        catch
        {
        }
        PluginCore.e("Abandoned trying to combine item " + str + " (Bugged unsalvageable salvage bag)");
        this.i.Add(A_0);
        if (this.h.ContainsKey(A_0))
        {
            this.h.Remove(A_0);
        }
    }

    private void a(object A_0, ItemDestroyedEventArgs A_1)
    {
        this.b(A_1.get_ItemGuid());
    }

    private void a(object A_0, ReleaseObjectEventArgs A_1)
    {
        this.b(A_1.get_Released().get_Id());
    }

    private bool a(double A_0, double A_1, int A_2)
    {
        if (PluginCore.cq.ag.a(typeof(ILootPluginCapability_SalvageCombineDecision)))
        {
            ILootPluginCapability_SalvageCombineDecision decision = PluginCore.cq.ag.i() as ILootPluginCapability_SalvageCombineDecision;
            return ((decision != null) && decision.CanCombineBags(A_0, A_1, A_2));
        }
        return (PluginCore.cq.l.a(A_2) || (((A_0 < 7.0) && (A_1 < 7.0)) || ((((A_0 >= 7.0) && (A_0 < 9.0)) && ((A_1 >= 7.0) && (A_1 < 9.0))) || ((((A_0 >= 9.0) && (A_0 < 10.0)) && ((A_1 >= 9.0) && (A_1 < 10.0))) || ((A_0 == 10.0) && (A_1 == 10.0))))));
    }

    private bool b()
    {
        ReadOnlyCollection<cv> onlys = PluginCore.cq.p.d();
        MyList<cv> list = new MyList<cv>(0x1d);
        foreach (cv cv in onlys)
        {
            if ((PluginCore.cq.p.b(cv.k, PluginCore.cq.ax) && this.g.IsMatch(cv.g())) && !this.i.Contains(cv.k))
            {
                list.Add(cv);
            }
        }
        int num = 0;
        int item = 0;
        double num3 = 0.0;
        list.Sort(new fc.b());
        foreach (cv cv2 in list)
        {
            int num4 = cv2.a(dt.aq, 0);
            double num5 = cv2.a(fx.t, 0.0);
            if ((num4 == num) && this.a(num3, num5, num4))
            {
                this.f.Clear();
                this.f.Add(item);
                this.f.Add(cv2.k);
                return true;
            }
            num3 = num5;
            num = num4;
            item = cv2.k;
        }
        return false;
    }

    private void b(int A_0)
    {
        if (this.b.Contains(A_0))
        {
            this.b.Remove(A_0);
        }
        if (this.c.ContainsKey(A_0))
        {
            this.c.Remove(A_0);
        }
        if (this.h.ContainsKey(A_0))
        {
            this.h.Remove(A_0);
        }
        if (this.i.Contains(A_0))
        {
            this.i.Remove(A_0);
        }
    }

    private bool c()
    {
        ReadOnlyCollection<cv> onlys = PluginCore.cq.p.d();
        ILootPluginCapability_SalvageCombineDecision2 decision = PluginCore.cq.ag.i() as ILootPluginCapability_SalvageCombineDecision2;
        Dictionary<int, List<cv>> dictionary = new Dictionary<int, List<cv>>();
        foreach (cv cv in onlys)
        {
            if ((PluginCore.cq.p.b(cv.k, PluginCore.cq.ax) && this.g.IsMatch(cv.g())) && !this.i.Contains(cv.k))
            {
                int key = cv.a(dt.aq, 0);
                if (key != 0)
                {
                    if (!dictionary.ContainsKey(key))
                    {
                        dictionary.Add(key, new List<cv>());
                    }
                    dictionary[key].Add(cv);
                }
            }
        }
        foreach (KeyValuePair<int, List<cv>> pair in dictionary)
        {
            if (pair.Value.Count >= 2)
            {
                pair.Value.Sort(new fc.b());
                List<GameItemInfo> availablebags = new List<GameItemInfo>();
                Dictionary<int, bool> dictionary2 = new Dictionary<int, bool>();
                foreach (cv cv2 in pair.Value)
                {
                    availablebags.Add(new GameItemInfo(cv2));
                    dictionary2[cv2.k] = true;
                }
                List<int> list2 = decision.ChooseBagsToCombine(availablebags);
                if (list2 != null)
                {
                    this.f.Clear();
                    foreach (int num2 in list2)
                    {
                        if (dictionary2.ContainsKey(num2))
                        {
                            this.f.Add(num2);
                        }
                    }
                    if (this.f.Count >= 2)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public void c(int A_0)
    {
        if (!this.b.Contains(A_0))
        {
            this.b.Add(A_0);
        }
        if (!this.c.ContainsKey(A_0))
        {
            this.c.Add(A_0, new fc.a());
        }
    }

    private bool d()
    {
        if (!er.j("CombineSalvage"))
        {
            return false;
        }
        if (!PluginCore.cq.ag.c())
        {
            return false;
        }
        if (PluginCore.cq.ag.a(typeof(ILootPluginCapability_SalvageCombineDecision2)))
        {
            return this.c();
        }
        return this.b();
    }

    private void e()
    {
        if (this.e != 0)
        {
            PluginCore.cq.ax.get_Actions().SalvagePanelAdd(this.e);
            PluginCore.cq.ax.get_Actions().SalvagePanelSalvage();
        }
    }

    private bool f()
    {
        for (int i = this.b.Count - 1; i >= 0; i--)
        {
            int num2 = this.b[i];
            if (!PluginCore.cq.p.b(num2, PluginCore.cq.ax))
            {
                fc.a local1 = this.c[num2];
                local1.b++;
                if (this.c[num2].b > 0x19)
                {
                    this.c.Remove(num2);
                    this.b.RemoveAt(i);
                    PluginCore.e("Cannot salvage item " + num2.ToString() + " because it is no longer in the inventory.");
                }
            }
            else
            {
                fc.a local2 = this.c[num2];
                local2.a++;
                if (this.c[num2].a > 80)
                {
                    this.c.Remove(num2);
                    this.b.RemoveAt(i);
                    PluginCore.e("Cannot salvage item " + num2.ToString() + ", item may be bugged unsalvageable.");
                }
                else
                {
                    this.e = num2;
                    return true;
                }
            }
        }
        this.e = 0;
        return false;
    }

    public void g()
    {
        if (!this.a)
        {
            this.a = true;
            GC.SuppressFinalize(this);
            CoreManager.get_Current().get_WorldFilter().remove_ReleaseObject(new EventHandler<ReleaseObjectEventArgs>(this.a));
            CoreManager.get_Current().remove_ItemDestroyed(new EventHandler<ItemDestroyedEventArgs>(this.a));
        }
    }

    public void h()
    {
        if (this.d)
        {
            this.a();
        }
        else
        {
            this.e();
        }
    }

    protected override void i()
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

    public bool j()
    {
        if (this.d())
        {
            this.d = true;
            return true;
        }
        if (this.f())
        {
            this.d = false;
            return true;
        }
        return false;
    }

    private class a
    {
        public int a;
        public int b;
    }

    public class b : IComparer<cv>
    {
        public int a(cv A_0, cv A_1)
        {
            int num = A_0.a(dt.aq, 0);
            int num2 = A_1.a(dt.aq, 0);
            int num3 = num.CompareTo(num2);
            if (num3 != 0)
            {
                return num3;
            }
            double num4 = A_0.a(fx.t, 0.0);
            double num5 = A_1.a(fx.t, 0.0);
            return num4.CompareTo(num5);
        }
    }
}

