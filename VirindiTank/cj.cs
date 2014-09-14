using Decal.Adapter;
using Decal.Adapter.Wrappers;
using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.CompilerServices;

[DefaultMember("Item")]
internal class cj : IDisposable
{
    private cj.c a;
    private cj.c b;
    private cj.c c;
    private cj.c d;
    private cj.c e;
    private cj.c f;
    private cj.b g;
    private cj.d h;
    public Dictionary<int, cv> i = new Dictionary<int, cv>();
    public Dictionary<string, List<cv>> j = new Dictionary<string, List<cv>>();
    public Dictionary<ObjectClass, List<cv>> k = new Dictionary<ObjectClass, List<cv>>();
    public Dictionary<int, List<cv>> l = new Dictionary<int, List<cv>>();
    private List<cv> m = new List<cv>();
    private cv n;
    private int o;
    private bool p;
    private cj.a q;
    private e3 r;
    private HooksWrapper s;
    private EventHandler t;
    public o u;
    private bool v;

    public cj(cj.a A_0, HooksWrapper A_1)
    {
        this.q = A_0;
        CoreManager.get_Current().get_EchoFilter().add_ServerDispatch(new EventHandler<NetworkMessageEventArgs>(this.b));
        CoreManager.get_Current().add_ItemDestroyed(new EventHandler<ItemDestroyedEventArgs>(this.a));
        CoreManager.get_Current().get_EchoFilter().add_ClientDispatch(new EventHandler<NetworkMessageEventArgs>(this.a));
        this.s = A_1;
        this.r = new e3();
        this.r.a(new EventHandler(this.a));
        this.r.a(0x17f3);
        this.r.a(true);
    }

    public void a()
    {
        if (!this.v)
        {
            this.v = true;
            GC.SuppressFinalize(this);
            CoreManager.get_Current().get_EchoFilter().remove_ServerDispatch(new EventHandler<NetworkMessageEventArgs>(this.b));
            CoreManager.get_Current().remove_ItemDestroyed(new EventHandler<ItemDestroyedEventArgs>(this.a));
            CoreManager.get_Current().get_EchoFilter().remove_ClientDispatch(new EventHandler<NetworkMessageEventArgs>(this.a));
            this.i.Clear();
            this.j.Clear();
            this.m.Clear();
            this.r.e();
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void a(cj.b A_0)
    {
        this.g = (cj.b) Delegate.Remove(this.g, A_0);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void a(cj.c A_0)
    {
        this.d = (cj.c) Delegate.Remove(this.d, A_0);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void a(cj.d A_0)
    {
        this.h = (cj.d) Delegate.Remove(this.h, A_0);
    }

    private void a(cv A_0)
    {
        int key = A_0.f();
        if (!this.l.ContainsKey(key))
        {
            this.l.Add(key, new List<cv>());
        }
        if (!this.l[key].Contains(A_0))
        {
            this.l[key].Add(A_0);
        }
    }

    private void a(NetworkMessageEventArgs A_0)
    {
        int num = A_0.get_Message().Value<int>("flags");
        int key = A_0.get_Message().Value<int>("object");
        if (this.i.ContainsKey(key))
        {
            cv cv = this.i[key];
            cv.j = true;
            cv.p = DateTimeOffset.Now;
            if ((num & 1) > 0)
            {
                short num3 = A_0.get_Message().Value<short>("dwordCount");
                for (int i = 0; i < num3; i++)
                {
                    int num5 = A_0.get_Message().Struct("dwords").Struct(i).Value<int>("key");
                    int num6 = A_0.get_Message().Struct("dwords").Struct(i).Value<int>("value");
                    cv.a[num5] = num6;
                }
            }
            if ((num & 2) > 0)
            {
                short num7 = A_0.get_Message().Value<short>("booleanCount");
                for (int j = 0; j < num7; j++)
                {
                    int num9 = A_0.get_Message().Struct("booleans").Struct(j).Value<int>("key");
                    bool flag = A_0.get_Message().Struct("booleans").Struct(j).Value<int>("value") != 0;
                    cv.c[num9] = flag;
                }
            }
            if ((num & 4) > 0)
            {
                short num10 = A_0.get_Message().Value<short>("doubleCount");
                for (int k = 0; k < num10; k++)
                {
                    int num12 = A_0.get_Message().Struct("doubles").Struct(k).Value<int>("key");
                    double num13 = A_0.get_Message().Struct("doubles").Struct(k).Value<double>("value");
                    cv.d[num12] = num13;
                }
            }
            if ((num & 8) > 0)
            {
                short num14 = A_0.get_Message().Value<short>("stringCount");
                for (int m = 0; m < num14; m++)
                {
                    int num16 = A_0.get_Message().Struct("strings").Struct(m).Value<int>("key");
                    string str = A_0.get_Message().Struct("strings").Struct(m).Value<string>("value");
                    cv.b[num16] = str;
                }
            }
            if ((num & 0x1000) > 0)
            {
                short num17 = A_0.get_Message().Value<short>("resourceCount");
                for (int n = 0; n < num17; n++)
                {
                    int num19 = A_0.get_Message().Struct("resources").Struct(n).Value<int>("key");
                    int num20 = A_0.get_Message().Struct("resources").Struct(n).Value<int>("value");
                    switch (num19)
                    {
                        case 8:
                        {
                            cv.a[0xd000001] = num20;
                        }
                    }
                    cv.g[num19] = num20;
                }
            }
            if ((num & 0x2000) > 0)
            {
                short num21 = A_0.get_Message().Value<short>("qwordCount");
                for (int num22 = 0; num22 < num21; num22++)
                {
                    int num23 = A_0.get_Message().Struct("qwords").Struct(num22).Value<int>("key");
                    long num24 = A_0.get_Message().Struct("qwords").Struct(num22).Value<long>("value");
                    cv.e[num23] = num24;
                }
            }
            cv.h.Clear();
            if ((num & 0x10) > 0)
            {
                short num25 = A_0.get_Message().Value<short>("spellCount");
                for (int num26 = 0; num26 < num25; num26++)
                {
                    int item = (ushort) A_0.get_Message().Struct("spells").Struct(num26).Value<short>("spell");
                    cv.h.Add(item);
                }
            }
            if ((num & 0x80) > 0)
            {
                cv.d[0xa000000] = (double) A_0.get_Message().Value<float>("protSlashing");
                cv.d[0xa000001] = (double) A_0.get_Message().Value<float>("protPiercing");
                cv.d[0xa000002] = (double) A_0.get_Message().Value<float>("protBludgeoning");
                cv.d[0xa000006] = (double) A_0.get_Message().Value<float>("protCold");
                cv.d[0xa000005] = (double) A_0.get_Message().Value<float>("protFire");
                cv.d[0xa000003] = (double) A_0.get_Message().Value<float>("protAcid");
                cv.d[0xa000004] = (double) A_0.get_Message().Value<float>("protLightning");
            }
            if ((num & 0x100) > 0)
            {
                int num28 = A_0.get_Message().Value<int>("flags1");
                cv.a[0xd800000] = num28;
                cv.a[0xd800001] = A_0.get_Message().Value<int>("health");
                cv.a[0xd800002] = A_0.get_Message().Value<int>("healthMax");
                if ((num28 & 8) > 0)
                {
                    cv.a[0xd800003] = A_0.get_Message().Value<int>("strength");
                    cv.a[0xd800004] = A_0.get_Message().Value<int>("endurance");
                    cv.a[0xd800005] = A_0.get_Message().Value<int>("quickness");
                    cv.a[0xd800006] = A_0.get_Message().Value<int>("coordination");
                    cv.a[0xd800007] = A_0.get_Message().Value<int>("focus");
                    cv.a[0xd800008] = A_0.get_Message().Value<int>("self");
                    cv.a[0xd800009] = A_0.get_Message().Value<int>("stamina");
                    cv.a[0xd80000a] = A_0.get_Message().Value<int>("mana");
                    cv.a[0xd80000b] = A_0.get_Message().Value<int>("staminaMax");
                    cv.a[0xd80000c] = A_0.get_Message().Value<int>("manaMax");
                }
                if ((num28 & 1) > 0)
                {
                    cv.a[0xd80000d] = A_0.get_Message().Value<short>("attrHighlight");
                    cv.a[0xd80000e] = A_0.get_Message().Value<short>("attrColor");
                }
            }
            if ((num & 0x20) > 0)
            {
                cv.a[0xd000021] = A_0.get_Message().Value<int>("weapType");
                cv.a[0xd00001f] = A_0.get_Message().Value<int>("weapSpeed");
                cv.a[0xd000020] = A_0.get_Message().Value<int>("weapSkill");
                cv.a[0xd000022] = A_0.get_Message().Value<int>("weapDamage");
                cv.d[0xa00000b] = A_0.get_Message().Value<double>("weapVariance");
                cv.d[0xa00000e] = A_0.get_Message().Value<double>("weapModifier");
                cv.d[0xa00000d] = A_0.get_Message().Value<double>("weapPower");
                cv.d[0xa00000c] = A_0.get_Message().Value<double>("weapAttack");
            }
            if (this.a != null)
            {
                this.a(cv);
            }
        }
    }

    public ReadOnlyCollection<cv> a(ObjectClass A_0)
    {
        if (this.k.ContainsKey(A_0))
        {
            return this.k[A_0].AsReadOnly();
        }
        return new List<cv>().AsReadOnly();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void a(EventHandler A_0)
    {
        this.t = (EventHandler) Delegate.Combine(this.t, A_0);
    }

    private void a(int A_0)
    {
        if ((A_0 != this.o) && this.i.ContainsKey(A_0))
        {
            cv cv = this.i[A_0];
            cv.n--;
            if (cv.n == 0)
            {
                this.d(cv);
                if (this.m.Contains(cv))
                {
                    this.m.Remove(cv);
                }
                if (this.d != null)
                {
                    this.d(cv);
                }
            }
        }
    }

    public ReadOnlyCollection<cv> a(string A_0)
    {
        List<cv> list = new List<cv>();
        foreach (cv cv in this.m)
        {
            if (cv.g() == A_0)
            {
                list.Add(cv);
            }
        }
        return list.AsReadOnly();
    }

    private void a(cv A_0, MessageStruct A_1)
    {
        int num = A_1.Value<int>("landcell");
        float num2 = A_1.Value<float>("x");
        float num3 = A_1.Value<float>("y");
        float num4 = A_1.Value<float>("z");
        A_0.w = dz.a(num2, num3, num4 / 240f, num);
    }

    private void a(cv A_0, List<cv> A_1)
    {
        if (this.f(A_0.k) == this.o)
        {
            if (!this.m.Contains(A_0))
            {
                this.m.Add(A_0);
            }
        }
        else if (this.m.Contains(A_0))
        {
            this.m.Remove(A_0);
        }
        A_1.Add(A_0);
        if (this.l.ContainsKey(A_0.k))
        {
            foreach (cv cv in this.l[A_0.k])
            {
                if (!A_1.Contains(cv))
                {
                    this.a(cv, A_1);
                }
            }
        }
    }

    public bool a(int A_0, PluginHost A_1)
    {
        if (!A_1.get_Actions().IsValidObject(A_0))
        {
            return false;
        }
        if (!this.i.ContainsKey(A_0))
        {
            return false;
        }
        return true;
    }

    private void a(object A_0, ItemDestroyedEventArgs A_1)
    {
        try
        {
            this.a(A_1.get_ItemGuid());
        }
        catch (Exception exception)
        {
            this.q(exception, null);
        }
    }

    private void a(object A_0, NetworkMessageEventArgs A_1)
    {
        try
        {
            if ((A_1.get_Message().get_Type() == 0xf7b1) && (A_1.get_Message().Value<int>("action") == 0xa1))
            {
                this.p = true;
            }
        }
        catch (Exception exception)
        {
            this.q(exception, A_1);
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        if (this.p)
        {
            List<int> list = new List<int>();
            foreach (KeyValuePair<int, cv> pair in this.i)
            {
                if (!this.s.IsValidObject(pair.Key))
                {
                    list.Add(pair.Key);
                }
            }
            foreach (int num in list)
            {
                this.b(num);
            }
        }
    }

    public ReadOnlyCollection<cv> a(string A_0, ObjectClass A_1)
    {
        if (!this.j.ContainsKey(A_0))
        {
            return new List<cv>().AsReadOnly();
        }
        List<cv> list = new List<cv>();
        foreach (cv cv in this.j[A_0])
        {
            if (cv.c() == A_1)
            {
                list.Add(cv);
            }
        }
        return list.AsReadOnly();
    }

    private void a(int A_0, int A_1, int A_2)
    {
        if (this.i.ContainsKey(A_0))
        {
            this.i[A_0].f[A_1] = A_2;
            switch (A_1)
            {
                case 0x18:
                    this.i[A_0].a[0xd00002d] = A_2;
                    break;

                case 0x19:
                    this.i[A_0].a[0xd00002e] = A_2;
                    break;

                case 0x1a:
                    this.i[A_0].a[0xd00000c] = A_2;
                    break;

                case 0x20:
                    this.i[A_0].a[0xd00002e] = A_2;
                    break;

                case 2:
                    this.b(this.i[A_0]);
                    this.i[A_0].a[0xd000002] = A_2;
                    this.c(this.i[A_0]);
                    this.a(this.i[A_0]);
                    if (this.c != null)
                    {
                        this.c(this.i[A_0]);
                    }
                    break;

                case 3:
                    this.b(this.i[A_0]);
                    this.i[A_0].a[0xd00002b] = A_2;
                    this.c(this.i[A_0]);
                    this.a(this.i[A_0]);
                    if (this.c != null)
                    {
                        this.c(this.i[A_0]);
                    }
                    break;

                case 11:
                    this.i[A_0].a[0xd00002c] = A_2;
                    break;
            }
            if (this.e != null)
            {
                this.e(this.i[A_0]);
            }
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

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void b(cj.b A_0)
    {
        this.g = (cj.b) Delegate.Combine(this.g, A_0);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void b(cj.c A_0)
    {
        this.b = (cj.c) Delegate.Remove(this.b, A_0);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void b(cj.d A_0)
    {
        this.h = (cj.d) Delegate.Combine(this.h, A_0);
    }

    private void b(cv A_0)
    {
        int key = A_0.f();
        if (this.l.ContainsKey(key) && this.l[key].Contains(A_0))
        {
            this.l[key].Remove(A_0);
            if (this.l[key].Count == 0)
            {
                this.l.Remove(key);
            }
        }
    }

    private void b(NetworkMessageEventArgs A_0)
    {
        this.u = new o();
        this.u.c = A_0.get_Message().Value<int>("merchant");
        this.u.d = A_0.get_Message().Value<int>("buyCategories");
        this.u.e = A_0.get_Message().Value<int>("unknown1");
        this.u.f = A_0.get_Message().Value<int>("buyValue");
        this.u.g = A_0.get_Message().Value<int>("unknown2");
        this.u.h = A_0.get_Message().Value<float>("buyRate");
        this.u.i = A_0.get_Message().Value<float>("sellRate");
        int num = A_0.get_Message().Value<int>("itemCount");
        for (int i = 0; i < num; i++)
        {
            cv cv = new cv();
            MessageStruct struct2 = A_0.get_Message().Struct("items").Struct(i);
            cv.u = struct2.Value<int>("count");
            cv.k = struct2.Value<int>("object");
            this.e(cv, struct2.Struct("game"));
            cv.v = true;
            this.u.a(cv);
        }
        if (this.t != null)
        {
            this.t(this, null);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void b(EventHandler A_0)
    {
        this.t = (EventHandler) Delegate.Remove(this.t, A_0);
    }

    private void b(int A_0)
    {
        if ((A_0 != this.o) && this.i.ContainsKey(A_0))
        {
            cv cv = this.i[A_0];
            this.d(cv);
            if (this.m.Contains(cv))
            {
                this.m.Remove(cv);
            }
            if (this.d != null)
            {
                this.d(cv);
            }
        }
    }

    public cv b(string A_0)
    {
        cv cv = null;
        int num = 0x7fffffff;
        foreach (cv cv2 in this.m)
        {
            if ((cv2.g() == A_0) && (cv2.a(dt.ct, 0) < num))
            {
                cv = cv2;
            }
        }
        return cv;
    }

    private void b(cv A_0, MessageStruct A_1)
    {
        int num = A_1.Value<int>("landcell");
        float num2 = A_1.Value<float>("x");
        float num3 = A_1.Value<float>("y");
        float num4 = A_1.Value<float>("z");
        A_0.w = dz.a(num2, num3, num4 / 240f, num);
    }

    public bool b(int A_0, PluginHost A_1)
    {
        if (!A_1.get_Actions().IsValidObject(A_0))
        {
            return false;
        }
        if (!this.i.ContainsKey(A_0))
        {
            return false;
        }
        if (!this.m.Contains(this.i[A_0]))
        {
            return false;
        }
        return true;
    }

    private void b(object A_0, NetworkMessageEventArgs A_1)
    {
        try
        {
            switch (A_1.get_Message().get_Type())
            {
                case 0x2cd:
                    this.p(A_1);
                    return;

                case 0x2ce:
                    this.n(A_1);
                    return;

                case 0x2cf:
                    this.o(A_1);
                    return;

                case 720:
                case 0x2d1:
                case 0x2d3:
                case 0x2d4:
                case 0x2d5:
                case 0x2d7:
                    return;

                case 0x2d2:
                    this.m(A_1);
                    return;

                case 0x2d6:
                    this.l(A_1);
                    return;

                case 0x2d8:
                    this.k(A_1);
                    return;

                case 0x2d9:
                    this.j(A_1);
                    return;

                case 730:
                    this.i(A_1);
                    return;

                case 0xf625:
                    this.h(A_1);
                    return;

                case 0x24:
                    this.r(A_1);
                    return;

                case 0x197:
                    this.q(A_1);
                    return;

                case 0xf745:
                    this.f(A_1);
                    return;

                case 0xf748:
                    this.e(A_1);
                    return;

                case 0xf74c:
                    this.g(A_1);
                    return;

                case 0xf7b0:
                    switch (A_1.get_Message().Value<int>("event"))
                    {
                        case 0x62:
                            goto Label_01BF;

                        case 0xc9:
                            goto Label_01C8;

                        case 0x22:
                            goto Label_01B6;
                    }
                    return;

                case 0xf7db:
                    this.f(A_1);
                    return;

                default:
                    return;
            }
            this.d(A_1);
            return;
        Label_01B6:
            this.c(A_1);
            return;
        Label_01BF:
            this.b(A_1);
            return;
        Label_01C8:
            this.a(A_1);
        }
        catch (Exception exception)
        {
            this.q(exception, A_1);
        }
    }

    private void b(int A_0, int A_1, int A_2)
    {
        if (this.i.ContainsKey(A_0))
        {
            if (A_1 == 8)
            {
                this.i[A_0].a[0xd000001] = A_2;
            }
            if (this.e != null)
            {
                this.e(this.i[A_0]);
            }
        }
    }

    public bool c()
    {
        return this.p;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void c(cj.c A_0)
    {
        this.f = (cj.c) Delegate.Combine(this.f, A_0);
    }

    private void c(cv A_0)
    {
        this.a(A_0, new List<cv>());
    }

    private void c(NetworkMessageEventArgs A_0)
    {
        int key = A_0.get_Message().Value<int>("item");
        int num2 = A_0.get_Message().Value<int>("container");
        if (this.i.ContainsKey(key))
        {
            this.b(this.i[key]);
            this.i[key].a[0xd000002] = num2;
            this.c(this.i[key]);
            this.a(this.i[key]);
            if (this.c != null)
            {
                this.c(this.i[key]);
            }
        }
    }

    public bool c(int A_0)
    {
        if (!this.i.ContainsKey(A_0))
        {
            return false;
        }
        return this.m.Contains(this.i[A_0]);
    }

    public ReadOnlyCollection<cv> c(string A_0)
    {
        if (this.j.ContainsKey(A_0))
        {
            return this.j[A_0].AsReadOnly();
        }
        return new List<cv>().AsReadOnly();
    }

    private void c(cv A_0, MessageStruct A_1)
    {
        int num = A_1.Value<int>("flags");
        A_0.a[0xd000027] = num;
        if ((num & 0x8000) > 0)
        {
            this.b(A_0, A_1.Struct("position"));
        }
    }

    public ReadOnlyCollection<cv> d()
    {
        return this.m.AsReadOnly();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void d(cj.c A_0)
    {
        this.c = (cj.c) Delegate.Combine(this.c, A_0);
    }

    private void d(cv A_0)
    {
        A_0.m = false;
        if (this.i.ContainsKey(A_0.k))
        {
            this.i.Remove(A_0.k);
        }
        if (this.j.ContainsKey(A_0.g()) && this.j[A_0.g()].Contains(A_0))
        {
            this.j[A_0.g()].Remove(A_0);
            if (this.j[A_0.g()].Count == 0)
            {
                this.j.Remove(A_0.g());
            }
        }
        ObjectClass key = A_0.c();
        if (this.k.ContainsKey(key) && this.k[key].Contains(A_0))
        {
            this.k[key].Remove(A_0);
            if (this.k[key].Count == 0)
            {
                this.k.Remove(key);
            }
        }
        if (this.m.Contains(A_0))
        {
            this.m.Remove(A_0);
        }
        this.b(A_0);
    }

    private void d(NetworkMessageEventArgs A_0)
    {
        cv n;
        this.o = A_0.get_Message().Value<int>("character");
        foreach (KeyValuePair<int, cv> pair in this.i)
        {
            this.c(pair.Value);
        }
        if (this.i.ContainsKey(this.o))
        {
            n = this.i[this.o];
        }
        else
        {
            this.n = new cv();
            n = this.n;
            n.k = this.o;
        }
        MessageStruct struct2 = A_0.get_Message().Struct("properties");
        int num = struct2.Value<int>("flags");
        if ((num & 1) > 0)
        {
            short num2 = struct2.Value<short>("dwordCount");
            for (int i = 0; i < num2; i++)
            {
                int num4 = struct2.Struct("dwords").Struct(i).Value<int>("key");
                int num5 = struct2.Struct("dwords").Struct(i).Value<int>("value");
                n.a[num4] = num5;
            }
        }
        if ((num & 0x80) > 0)
        {
            short num6 = struct2.Value<short>("qwordCount");
            for (int j = 0; j < num6; j++)
            {
                int num8 = struct2.Struct("qwords").Struct(j).Value<int>("key");
                long num9 = struct2.Struct("qwords").Struct(j).Value<long>("value");
                n.e[num8] = num9;
            }
        }
        if ((num & 2) > 0)
        {
            short num10 = struct2.Value<short>("booleanCount");
            for (int k = 0; k < num10; k++)
            {
                int num12 = struct2.Struct("booleans").Struct(k).Value<int>("key");
                bool flag = struct2.Struct("booleans").Struct(k).Value<int>("value") != 0;
                n.c[num12] = flag;
            }
        }
        if ((num & 4) > 0)
        {
            short num13 = struct2.Value<short>("doubleCount");
            for (int m = 0; m < num13; m++)
            {
                int num15 = struct2.Struct("doubles").Struct(m).Value<int>("key");
                double num16 = struct2.Struct("doubles").Struct(m).Value<double>("value");
                n.d[num15] = num16;
            }
        }
        if ((num & 0x10) > 0)
        {
            short num17 = struct2.Value<short>("stringCount");
            for (int num18 = 0; num18 < num17; num18++)
            {
                int num19 = struct2.Struct("strings").Struct(num18).Value<int>("key");
                string str = struct2.Struct("strings").Struct(num18).Value<string>("value");
                n.b[num19] = str;
            }
        }
        if ((num & 0x40) > 0)
        {
            short num20 = struct2.Value<short>("resourceCount");
            for (int num21 = 0; num21 < num20; num21++)
            {
                int num22 = struct2.Struct("resources").Struct(num21).Value<int>("key");
                int num23 = struct2.Struct("resources").Struct(num21).Value<int>("value");
                switch (num22)
                {
                    case 8:
                    {
                        n.a[0xd000001] = num23;
                    }
                }
                n.g[num22] = num23;
            }
        }
        if (this.e != null)
        {
            this.e(n);
        }
    }

    public cv d(int A_0)
    {
        if (this.i.ContainsKey(A_0))
        {
            return this.i[A_0];
        }
        return null;
    }

    public int d(string A_0)
    {
        int num = 0;
        foreach (cv cv in this.m)
        {
            if (!(cv.g() != A_0))
            {
                num += cv.a(dt.ct, 1);
            }
        }
        return num;
    }

    private void d(cv A_0, MessageStruct A_1)
    {
        A_0.q = true;
        A_0.t.Clear();
        byte num = A_1.Value<byte>("paletteCount");
        if (num == 0xff)
        {
            A_0.r = true;
            A_0.s = A_1.Value<int>("palette");
        }
        else
        {
            A_0.r = false;
            MessageStruct struct2 = A_1.Struct("palettes");
            for (int i = 0; i < num; i++)
            {
                bo item = new bo {
                    a = struct2.Struct(i).Value<int>("palette"),
                    b = struct2.Struct(i).Value<byte>("offset"),
                    c = struct2.Struct(i).Value<byte>("length")
                };
                A_0.t.Add(item);
            }
        }
    }

    public int e()
    {
        int num = 0x66;
        foreach (cv cv in this.e(this.o))
        {
            if (((cv.c() != ObjectClass.Container) && (cv.c() != ObjectClass.Foci)) && (cv.a(dt.d, 0) <= 0))
            {
                num--;
            }
        }
        return num;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void e(cj.c A_0)
    {
        this.c = (cj.c) Delegate.Remove(this.c, A_0);
    }

    private void e(cv A_0)
    {
        A_0.m = true;
        if (this.i.ContainsKey(A_0.k))
        {
            A_0.n = 1 + this.i[A_0.k].n;
            if (this.d != null)
            {
                this.d(this.i[A_0.k]);
            }
            this.d(this.i[A_0.k]);
        }
        this.i[A_0.k] = A_0;
        if (!this.j.ContainsKey(A_0.g()))
        {
            this.j[A_0.g()] = new List<cv>();
        }
        this.j[A_0.g()].Add(A_0);
        if (!this.k.ContainsKey(A_0.c()))
        {
            this.k[A_0.c()] = new List<cv>();
        }
        this.k[A_0.c()].Add(A_0);
        this.a(A_0);
    }

    private void e(NetworkMessageEventArgs A_0)
    {
        int key = A_0.get_Message().Value<int>("object");
        if (this.i.ContainsKey(key))
        {
            cv cv = this.i[key];
            MessageStruct struct2 = A_0.get_Message().Struct("position");
            this.a(cv, struct2);
        }
    }

    public ReadOnlyCollection<cv> e(int A_0)
    {
        if (this.l.ContainsKey(A_0))
        {
            return this.l[A_0].AsReadOnly();
        }
        return new List<cv>().AsReadOnly();
    }

    private void e(cv A_0, MessageStruct A_1)
    {
        A_0.a[0xd000018] = A_1.Value<int>("flags1");
        A_0.b[1] = A_1.Value<string>("name");
        A_0.a[0xd000000] = A_1.Value<int>("type");
        A_0.a[0xd000001] = A_1.Value<int>("icon");
        A_0.a[0xd00001a] = A_1.Value<int>("category");
        A_0.a[0xd00001b] = A_1.Value<int>("behavior");
        int num = 0;
        if ((A_1.Value<int>("behavior") & 0x4000000) > 0)
        {
            num = A_1.Value<int>("flags2");
            A_0.a[0xd000019] = num;
        }
        if ((A_1.Value<int>("flags1") & 1) > 0)
        {
            A_0.b[0xb000000] = A_1.Value<string>("namePlural");
        }
        if ((A_1.Value<int>("flags1") & 2) > 0)
        {
            A_0.a[0xd000004] = A_1.Value<byte>("itemSlots");
        }
        if ((A_1.Value<int>("flags1") & 4) > 0)
        {
            A_0.a[0xd000005] = A_1.Value<byte>("packSlots");
        }
        if ((A_1.Value<int>("flags1") & 0x100) > 0)
        {
            A_0.a[0xd000011] = A_1.Value<short>("ammunition");
        }
        if ((A_1.Value<int>("flags1") & 8) > 0)
        {
            A_0.a[0x13] = A_1.Value<int>("value");
        }
        if ((A_1.Value<int>("flags1") & 0x10) > 0)
        {
            A_0.a[0xd000023] = A_1.Value<int>("unknown10");
        }
        if ((A_1.Value<int>("flags1") & 0x20) > 0)
        {
            A_0.d[0xa000008] = (double) A_1.Value<float>("approachDistance");
        }
        if ((A_1.Value<int>("flags1") & 0x80000) > 0)
        {
            A_0.a[0xd000012] = A_1.Value<int>("usableOn");
        }
        if ((A_1.Value<int>("flags1") & 0x80) > 0)
        {
            A_0.a[0xd000010] = A_1.Value<int>("iconHighlight");
        }
        if ((A_1.Value<int>("flags1") & 0x200) > 0)
        {
            A_0.a[0xd00000f] = A_1.Value<byte>("wieldType");
        }
        if ((A_1.Value<int>("flags1") & 0x400) > 0)
        {
            A_0.a[0x5c] = A_1.Value<short>("uses");
        }
        if ((A_1.Value<int>("flags1") & 0x800) > 0)
        {
            A_0.a[0x5b] = A_1.Value<short>("usesLimit");
        }
        if ((A_1.Value<int>("flags1") & 0x1000) > 0)
        {
            A_0.a[0xd000006] = A_1.Value<short>("stack");
        }
        if ((A_1.Value<int>("flags1") & 0x2000) > 0)
        {
            A_0.a[0xd000007] = A_1.Value<short>("stackLimit");
        }
        if ((A_1.Value<int>("flags1") & 0x4000) > 0)
        {
            A_0.a[0xd000002] = A_1.Value<int>("container");
        }
        if ((A_1.Value<int>("flags1") & 0x8000) > 0)
        {
            A_0.a[0xd000002] = A_1.Value<int>("equipper");
            A_0.a[0xd000009] = -1;
        }
        if ((A_1.Value<int>("flags1") & 0x10000) > 0)
        {
            A_0.a[0xd00000e] = A_1.Value<int>("equipPossible");
        }
        if ((A_1.Value<int>("flags1") & 0x20000) > 0)
        {
            A_0.a[10] = A_1.Value<int>("equipActual");
        }
        if ((A_1.Value<int>("flags1") & 0x40000) > 0)
        {
            A_0.a[0xd00000d] = A_1.Value<int>("coverage");
        }
        if ((A_1.Value<int>("flags1") & 0x100000) > 0)
        {
            A_0.a[0x5f] = A_1.Value<byte>("unknown100000");
        }
        if ((A_1.Value<int>("flags1") & 0x800000) > 0)
        {
            A_0.a[0x85] = A_1.Value<byte>("unknown800000");
        }
        if ((A_1.Value<int>("flags1") & 0x8000000) > 0)
        {
            A_0.a[0xd000026] = A_1.Value<short>("unknown8000000");
        }
        if ((A_1.Value<int>("flags1") & 0x1000000) > 0)
        {
            A_0.d[0xa000009] = (double) A_1.Value<float>("workmanship");
        }
        if ((A_1.Value<int>("flags1") & 0x200000) > 0)
        {
            A_0.a[5] = A_1.Value<short>("burden");
        }
        if ((A_1.Value<int>("flags1") & 0x400000) > 0)
        {
            A_0.i = (ushort) A_1.Value<short>("spell");
        }
        if ((A_1.Value<int>("flags1") & 0x2000000) > 0)
        {
            A_0.a[0xd00002e] = A_1.Value<int>("owner");
        }
        if ((A_1.Value<int>("flags1") & 0x40) > 0)
        {
            A_0.a[0xd00000c] = A_1.Value<int>("monarch");
        }
        if ((A_1.Value<int>("flags1") & 0x10000000) > 0)
        {
            A_0.a[0xd000014] = A_1.Value<short>("hookableOn");
        }
        if ((A_1.Value<int>("flags1") & 0x40000000) > 0)
        {
            A_0.a[0xd000029] = A_1.Value<int>("iconOverlay");
        }
        if ((((long) A_1.Value<int>("flags1")) & 0x80000000L) > 0L)
        {
            A_0.a[0x83] = A_1.Value<int>("material");
        }
        if ((A_1.Value<int>("flags2") & 1) > 0)
        {
            A_0.a[0xd00002a] = A_1.Value<int>("iconUnderlay");
        }
        if ((A_1.Value<int>("flags2") & 2) > 0)
        {
            A_0.a[280] = A_1.Value<int>("cooldownId");
        }
    }

    public int f()
    {
        return this.o;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void f(cj.c A_0)
    {
        this.b = (cj.c) Delegate.Combine(this.b, A_0);
    }

    public bool f(cv A_0)
    {
        if (A_0 == null)
        {
            return false;
        }
        return this.m.Contains(A_0);
    }

    private void f(NetworkMessageEventArgs A_0)
    {
        int num = A_0.get_Message().Value<int>("object");
        cv n = new cv();
        if ((num == this.o) && (this.n != null))
        {
            n = this.n;
            this.n = null;
        }
        MessageStruct struct2 = A_0.get_Message().Struct("game");
        MessageStruct struct3 = A_0.get_Message().Struct("model");
        MessageStruct struct4 = A_0.get_Message().Struct("physics");
        n.k = num;
        this.e(n, struct2);
        this.d(n, struct3);
        this.c(n, struct4);
        if ((struct2.Value<int>("behavior") & 0x1000) != 0)
        {
            n.l = (struct4.Value<int>("unknown") & 4) > 0;
        }
        this.e(n);
        this.c(n);
        if (this.b != null)
        {
            this.b(n);
        }
    }

    public int f(int A_0)
    {
        try
        {
            if (!this.i.ContainsKey(A_0))
            {
                return 0;
            }
            cv cv = this.i[A_0];
            if (cv.f() == 0)
            {
                return 0;
            }
            int key = cv.f();
            int num2 = A_0;
            int num3 = 0;
            while (key != 0)
            {
                if (key == this.o)
                {
                    return this.o;
                }
                num3++;
                if ((num3 > 20) || (num2 == key))
                {
                    return num2;
                }
                num2 = key;
                if (this.i.ContainsKey(key))
                {
                    key = this.i[key].f();
                }
                else
                {
                    key = 0;
                }
            }
            return num2;
        }
        catch (Exception)
        {
            return 0;
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void g(cj.c A_0)
    {
        this.d = (cj.c) Delegate.Combine(this.d, A_0);
    }

    private void g(NetworkMessageEventArgs A_0)
    {
        int key = A_0.get_Message().Value<int>("object");
        if (((((this.i.ContainsKey(key) && (this.i[key].c() == ObjectClass.Door)) && (A_0.get_Message().Value<short>("activity") == 0)) && (A_0.get_Message().Value<byte>("animation_type") == 0)) && (A_0.get_Message().Value<short>("stance") == 0x3d)) && (A_0.get_Message().Value<int>("flags") == 2))
        {
            this.i[key].l = !this.i[key].l;
            if (this.e != null)
            {
                this.e(this.i[key]);
            }
            if (this.f != null)
            {
                this.f(this.i[key]);
            }
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void h(cj.c A_0)
    {
        this.f = (cj.c) Delegate.Remove(this.f, A_0);
    }

    private void h(NetworkMessageEventArgs A_0)
    {
        int key = A_0.get_Message().Value<int>("object");
        if (this.i.ContainsKey(key))
        {
            this.d(this.i[key], A_0.get_Message().Struct("model"));
            if (this.e != null)
            {
                this.e(this.i[key]);
            }
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void i(cj.c A_0)
    {
        this.e = (cj.c) Delegate.Remove(this.e, A_0);
    }

    private void i(NetworkMessageEventArgs A_0)
    {
        int num = A_0.get_Message().Value<int>("object");
        int num2 = A_0.get_Message().Value<int>("key");
        int num3 = A_0.get_Message().Value<int>("value");
        this.a(num, num2, num3);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void j(cj.c A_0)
    {
        this.e = (cj.c) Delegate.Combine(this.e, A_0);
    }

    private void j(NetworkMessageEventArgs A_0)
    {
        int o = this.o;
        int num2 = A_0.get_Message().Value<int>("key");
        int num3 = A_0.get_Message().Value<int>("value");
        this.a(o, num2, num3);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void k(cj.c A_0)
    {
        this.a = (cj.c) Delegate.Remove(this.a, A_0);
    }

    private void k(NetworkMessageEventArgs A_0)
    {
        int num = A_0.get_Message().Value<int>("object");
        int num2 = A_0.get_Message().Value<int>("key");
        int num3 = A_0.get_Message().Value<int>("value");
        this.b(num, num2, num3);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void l(cj.c A_0)
    {
        this.a = (cj.c) Delegate.Combine(this.a, A_0);
    }

    private void l(NetworkMessageEventArgs A_0)
    {
        int key = A_0.get_Message().Value<int>("object");
        int num2 = A_0.get_Message().Value<int>("key");
        string str = A_0.get_Message().Value<string>("value");
        if (this.i.ContainsKey(key))
        {
            this.i[key].b[num2] = str;
            if (this.e != null)
            {
                this.e(this.i[key]);
            }
        }
    }

    private void m(NetworkMessageEventArgs A_0)
    {
        int key = A_0.get_Message().Value<int>("object");
        int num2 = A_0.get_Message().Value<int>("key");
        bool flag = A_0.get_Message().Value<int>("value") != 0;
        if (this.i.ContainsKey(key))
        {
            this.i[key].c[num2] = flag;
            if (this.e != null)
            {
                this.e(this.i[key]);
            }
        }
    }

    private void n(NetworkMessageEventArgs A_0)
    {
        int key = A_0.get_Message().Value<int>("object");
        int num2 = A_0.get_Message().Value<int>("key");
        int num3 = A_0.get_Message().Value<int>("value");
        if (this.i.ContainsKey(key))
        {
            dt dt = (dt) num2;
            if (dt == dt.f)
            {
                this.i[key].a[0xd000010] = num3;
            }
            else
            {
                this.i[key].a[num2] = num3;
            }
            if (this.e != null)
            {
                this.e(this.i[key]);
            }
        }
    }

    private void o(NetworkMessageEventArgs A_0)
    {
        int o = this.o;
        int num2 = A_0.get_Message().Value<int>("key");
        long num3 = A_0.get_Message().Value<long>("value");
        if (this.i.ContainsKey(o))
        {
            this.i[o].e[num2] = num3;
            if (this.e != null)
            {
                this.e(this.i[o]);
            }
            if (this.h != null)
            {
                this.h(this.i[o], (ce) num2);
            }
        }
    }

    private void p(NetworkMessageEventArgs A_0)
    {
        int o = this.o;
        int num2 = A_0.get_Message().Value<int>("key");
        int num3 = A_0.get_Message().Value<int>("value");
        if (this.i.ContainsKey(o))
        {
            int num4 = num2;
            dt dt = (dt) num2;
            if (dt == dt.f)
            {
                this.i[o].a[0xd000010] = num3;
                num4 = 0xd000010;
            }
            else
            {
                this.i[o].a[num2] = num3;
            }
            if (this.e != null)
            {
                this.e(this.i[o]);
            }
            if (this.g != null)
            {
                this.g(this.i[o], (dt) num4);
            }
        }
    }

    private void q(NetworkMessageEventArgs A_0)
    {
        int key = A_0.get_Message().Value<int>("item");
        int num2 = A_0.get_Message().Value<int>("count");
        int num3 = A_0.get_Message().Value<int>("value");
        if (this.i.ContainsKey(key))
        {
            this.i[key].a[0xd000006] = num2;
            this.i[key].a[0x13] = num3;
            if (this.e != null)
            {
                this.e(this.i[key]);
            }
        }
    }

    private void r(NetworkMessageEventArgs A_0)
    {
        try
        {
            this.b(A_0.get_Message().Value<int>("object"));
        }
        catch (Exception exception)
        {
            this.q(exception, null);
        }
    }

    public delegate void a(Exception A_0, NetworkMessageEventArgs A_1);

    public delegate void b(cv A_0, dt A_1);

    public delegate void c(cv A_0);

    public delegate void d(cv A_0, ce A_1);
}

