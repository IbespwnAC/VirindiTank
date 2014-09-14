using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using uTank2;

internal class b5 : IDisposable
{
    private WorldFilter a;
    private PluginCore b;
    private bool c;
    private e3 d = new e3();
    internal MyDictionary<int, b5.a> e = new MyDictionary<int, b5.a>(0x2b);
    private Regex f = new Regex(@"(?:Killed by )([a-zA-Z\ \-\']*)(?:\..*)");
    private Regex g = new Regex(@"(?:Killed by )([a-zA-Z\ \-\']*)(?:\..*)([gG]enerated)(?:.*)");
    private Regex h = new Regex(@"([a-zA-Z\ \-\']*)\'s ([^\']*)");
    public int i;
    public int j;
    private Regex k = new Regex(@"The (Corpse)|(Treasure) of ([a-zA-Z\ \-\']*) is already in use by someone else!");
    private Regex l = new Regex("You do not yet have the right to loot the (Corpse)|(Treasure) of .*");
    public int m;

    public b5(CoreManager A_0, PluginCore A_1)
    {
        this.b = A_1;
        this.a = A_0.get_WorldFilter();
        this.a.add_CreateObject(new EventHandler<CreateObjectEventArgs>(this.a));
        this.a.add_ChangeObject(new EventHandler<ChangeObjectEventArgs>(this.a));
        this.a.add_ReleaseObject(new EventHandler<ReleaseObjectEventArgs>(this.a));
        this.d.a(0x7879);
        this.d.a(new EventHandler(this.a));
        this.b.a(new uTank2.PluginCore.a(this.a));
        this.b.b(new PluginCore.EmptyDelegate(this.a));
    }

    private void a()
    {
        this.d.d();
    }

    public bool a(double A_0)
    {
        this.i = 0;
        double maxValue = double.MaxValue;
        bool flag = false;
        foreach (KeyValuePair<int, b5.a> pair in this.e)
        {
            b5.a a = pair.Value;
            int key = pair.Key;
            if (a.b || a.a)
            {
                continue;
            }
            TimeSpan span = (TimeSpan) (DateTimeOffset.Now - a.g);
            if (span.TotalSeconds < 10.0)
            {
                continue;
            }
            TimeSpan span2 = (TimeSpan) (DateTimeOffset.Now - a.k);
            if (span2.TotalSeconds < er.i("BlacklistCorpseOpenTimeoutSeconds"))
            {
                continue;
            }
            double num3 = dh.a(key, PluginCore.cq.aw.get_CharacterFilter().get_Id(), true);
            if (((num3 > A_0) || !a.i) || (!a.e && er.j("LootOnlyRareCorpses")))
            {
                continue;
            }
            if (a.f != PluginCore.cq.aw.get_CharacterFilter().get_Name())
            {
                if (a.e)
                {
                    continue;
                }
                bool flag2 = false;
                bool j = false;
                foreach (KeyValuePair<int, ar.a> pair2 in PluginCore.cq.ai.a)
                {
                    if (a.f == pair2.Value.b)
                    {
                        flag2 = true;
                        j = pair2.Value.j;
                        break;
                    }
                }
                if (flag2)
                {
                    if (er.j("LootFellowCorpses") && (j || ((DateTimeOffset.Now - a.c) >= TimeSpan.FromSeconds(100.0))))
                    {
                        goto Label_01F6;
                    }
                    continue;
                }
                if (((DateTimeOffset.Now - a.c) < TimeSpan.FromSeconds(100.0)) || !er.j("LootAllCorpses"))
                {
                    continue;
                }
            }
        Label_01F6:
            if (a.e && !flag)
            {
                flag = true;
                maxValue = num3;
                this.i = key;
            }
            else if (a.e || !flag)
            {
                double num4 = num3;
                if (num4 < maxValue)
                {
                    maxValue = num4;
                    this.i = key;
                }
            }
        }
        if (this.i == 0)
        {
            return false;
        }
        return true;
    }

    private void a(object A_0, NetworkMessageEventArgs A_1)
    {
        try
        {
            if ((PluginCore.cg != 0) && (A_1.get_Message().get_Type() == 0xf7b0))
            {
                if (A_1.get_Message().Value<int>("event") == 0x52)
                {
                    PluginCore.cq.r.b();
                    this.j = 0;
                }
                else if (A_1.get_Message().Value<int>("event") == 0x196)
                {
                    int num = A_1.get_Message().Value<int>("container");
                    if (dh.b(num))
                    {
                        if (PluginCore.cq.aw.get_WorldFilter().get_Item(num).get_Container() == 0)
                        {
                            this.j = num;
                            PluginCore.cq.r.a(A_1.get_Message().Value<int>("itemCount"));
                        }
                    }
                    else
                    {
                        PluginCore.cq.r.b();
                        this.j = 0;
                    }
                }
                else if (A_1.get_Message().Value<int>("event") == 0x22)
                {
                    if (A_1.get_Message().Value<int>("item") == this.j)
                    {
                        PluginCore.cq.r.b();
                        this.j = 0;
                    }
                }
                else if (((A_1.get_Message().Value<int>("event") == 0x2eb) && (this.k.IsMatch(A_1.get_Message().Value<string>("text")) || this.l.IsMatch(A_1.get_Message().Value<string>("text")))) && this.e.ContainsKey(this.i))
                {
                    this.e[this.i].g = DateTimeOffset.Now;
                }
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    private void a(object A_0, ChangeObjectEventArgs A_1)
    {
        try
        {
            if ((PluginCore.cq.aw.get_WorldFilter().get_Item(A_1.get_Changed().get_Id()) != null) && ((A_1.get_Change() == 2) && this.e.ContainsKey(A_1.get_Changed().get_Id())))
            {
                string input = A_1.get_Changed().Values(0x10, "");
                Match match = this.f.Match(input);
                if (match.Success && (match.Groups[0].Index == 0))
                {
                    this.e[A_1.get_Changed().get_Id()].f = match.Groups[1].Value;
                    if (this.g.Match(input).Success)
                    {
                        this.e[A_1.get_Changed().get_Id()].e = true;
                    }
                    this.e[A_1.get_Changed().get_Id()].i = true;
                    Match match2 = this.h.Match(this.e[A_1.get_Changed().get_Id()].f);
                    if (match2.Success)
                    {
                        string b = match2.Groups[1].Value;
                        if (string.Equals(PluginCore.cq.aw.get_CharacterFilter().get_Name(), b, StringComparison.OrdinalIgnoreCase))
                        {
                            this.e[A_1.get_Changed().get_Id()].f = PluginCore.cq.aw.get_CharacterFilter().get_Name();
                        }
                        else if (PluginCore.cq.ai.c())
                        {
                            foreach (KeyValuePair<int, ar.a> pair in PluginCore.cq.ai.a)
                            {
                                if (string.Equals(pair.Value.b, b, StringComparison.OrdinalIgnoreCase))
                                {
                                    this.e[A_1.get_Changed().get_Id()].f = pair.Value.b;
                                    return;
                                }
                            }
                        }
                    }
                }
                else
                {
                    this.e[A_1.get_Changed().get_Id()].f = "";
                    this.e[A_1.get_Changed().get_Id()].e = true;
                    this.e[A_1.get_Changed().get_Id()].i = true;
                }
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    private void a(object A_0, CreateObjectEventArgs A_1)
    {
        try
        {
            if (A_1.get_New().get_ObjectClass() == 0x1b)
            {
                CoordsObject obj2 = A_1.get_New().Coordinates();
                dz dz = dz.a(obj2.get_EastWest(), obj2.get_NorthSouth(), 0.0);
                if (this.e.ContainsKey(A_1.get_New().get_Id()) && (dz.a(this.e[A_1.get_New().get_Id()].l, false) > 0.004167))
                {
                    this.e.Remove(A_1.get_New().get_Id());
                }
                if (!this.e.ContainsKey(A_1.get_New().get_Id()))
                {
                    b5.a a = new b5.a {
                        l = dz,
                        h = A_1.get_New().get_Name() == ("Corpse of " + CoreManager.get_Current().get_CharacterFilter().get_Name())
                    };
                    this.e.Add(A_1.get_New().get_Id(), a);
                    PluginCore.cq.u.a(A_1.get_New().get_Id(), b0.a.c);
                }
                else
                {
                    this.e[A_1.get_New().get_Id()].d = DateTimeOffset.Now;
                    this.e[A_1.get_New().get_Id()].a = false;
                }
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    private void a(object A_0, ReleaseObjectEventArgs A_1)
    {
        try
        {
            if (this.e.ContainsKey(A_1.get_Released().get_Id()))
            {
                this.e[A_1.get_Released().get_Id()].a = true;
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        try
        {
            MyList<int> list = new MyList<int>(0x2d);
            double num = er.h("CorpseCacheTimeoutMinutes");
            foreach (int num2 in this.e.Keys)
            {
                TimeSpan span = (TimeSpan) (DateTimeOffset.Now - this.e[num2].d);
                if ((span.TotalMinutes >= num) && this.e[num2].a)
                {
                    list.Add(num2);
                }
            }
            foreach (int num3 in list)
            {
                this.e.Remove(num3);
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    public void b()
    {
        if (!this.c)
        {
            this.c = true;
            GC.SuppressFinalize(this);
            this.b.b(new uTank2.PluginCore.a(this.a));
            this.d.b(new EventHandler(this.a));
            this.a.remove_CreateObject(new EventHandler<CreateObjectEventArgs>(this.a));
            this.a.remove_ChangeObject(new EventHandler<ChangeObjectEventArgs>(this.a));
            this.a.remove_ReleaseObject(new EventHandler<ReleaseObjectEventArgs>(this.a));
            if (this.d != null)
            {
                this.d.e();
            }
            this.b = null;
            this.a = null;
        }
    }

    public void c()
    {
        if (this.e())
        {
            if (this.e.ContainsKey(this.j))
            {
                this.e[this.j].b = true;
            }
            PluginCore.cq.ax.get_Actions().UseItem(this.j, 0);
        }
    }

    public void d()
    {
        if ((this.i != 0) && (this.j != this.i))
        {
            this.m = this.i;
            PluginCore.cq.ax.get_Actions().UseItem(this.i, 0);
            if (this.e.ContainsKey(this.i))
            {
                b5.a a = this.e[this.i];
                a.j++;
                if (a.j >= er.i("BlacklistCorpseOpenAttemptCount"))
                {
                    a.j = 0;
                    a.k = DateTimeOffset.Now;
                    cv cv = PluginCore.cq.p.d(this.i);
                    string str = "???";
                    if (cv != null)
                    {
                        str = cv.e();
                    }
                    PluginCore.e("Blacklisting unopenable corpse \"" + str + "\" for " + er.i("BlacklistCorpseOpenTimeoutSeconds").ToString() + " seconds.");
                }
            }
        }
    }

    public bool e()
    {
        this.g();
        return (this.j != 0);
    }

    protected override void f()
    {
        try
        {
            this.b();
        }
        finally
        {
            base.Finalize();
        }
    }

    public void g()
    {
        if ((PluginCore.cq.ax.get_Actions().get_OpenedContainer() == 0) && (this.j != 0))
        {
            this.j = 0;
            PluginCore.cq.r.b();
        }
    }

    public class a
    {
        public bool a = false;
        public bool b = false;
        public DateTimeOffset c = DateTimeOffset.Now;
        public DateTimeOffset d = DateTimeOffset.Now;
        public bool e = false;
        public string f;
        public DateTimeOffset g = DateTimeOffset.MinValue;
        public bool h = false;
        public bool i = false;
        public int j = 0;
        public DateTimeOffset k = DateTimeOffset.MinValue;
        public dz l;
    }
}

