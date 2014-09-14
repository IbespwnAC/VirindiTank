using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using uTank2;

internal class s : IDisposable
{
    private s.a a;
    private s.c b;
    private MyList<int> c = new MyList<int>(60);
    private bool d;
    private DateTimeOffset e;
    private int f;
    private int g;
    private int h;
    private MySpell i;
    private e3 j = new e3();
    private TimeSpan k = TimeSpan.FromSeconds(6.0);
    private e3 l = new e3();
    private TimeSpan m = TimeSpan.FromSeconds(3.5);
    private bool n;
    private s.b o;
    private Regex p = new Regex("^You cast (.*) on (.*)$");
    private Regex q = new Regex("You cast (.*) on (.*), .*");

    public s(CoreManager A_0)
    {
        PluginCore.PC.a(new uTank2.PluginCore.a(this.a));
        CoreManager.get_Current().add_ChatBoxMessage(new EventHandler<ChatTextInterceptEventArgs>(this.a));
        CoreManager.get_Current().get_WorldFilter().add_ReleaseObject(new EventHandler<ReleaseObjectEventArgs>(this.a));
        this.j.a(new EventHandler(this.b));
        this.l.a(new EventHandler(this.a));
        this.j.a(250);
        this.l.a(250);
    }

    private s.b a()
    {
        return this.o;
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void a(s.a A_0)
    {
        this.a = (s.a) Delegate.Combine(this.a, A_0);
    }

    private void a(s.b A_0)
    {
        this.e = DateTimeOffset.Now;
        this.o = A_0;
        switch (A_0)
        {
            case s.b.a:
                PluginCore.cq.b.d();
                PluginCore.cq.n.n.a(ActionLockType.ItemUse);
                PluginCore.cq.n.k = false;
                this.j.f();
                this.l.f();
                break;

            case s.b.d:
                PluginCore.cq.b.d();
                PluginCore.cq.n.n.a(ActionLockType.ItemUse, (this.k + this.m) + TimeSpan.FromSeconds(2.0));
                PluginCore.cq.n.k = true;
                this.j.d();
                this.l.f();
                this.b(null, null);
                break;

            case s.b.e:
                PluginCore.cq.n.n.a(ActionLockType.ItemUse, this.m + TimeSpan.FromSeconds(2.0));
                PluginCore.cq.n.k = true;
                this.j.f();
                this.l.d();
                this.a(null, (EventArgs) null);
                if ((this.b() && !er.j("JumpOutWandCasting")) && !this.i.IsInstantCast)
                {
                    PluginCore.cq.b.c();
                }
                break;
        }
        if (this.b != null)
        {
            this.b(A_0);
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void a(s.c A_0)
    {
        this.b = (s.c) Delegate.Remove(this.b, A_0);
    }

    public bool a(int A_0)
    {
        if (this.c.Contains(A_0) && (PluginCore.cq.n.e() == 0))
        {
            PluginCore.cq.n.a("Wandcaster mana test failed (" + A_0.ToString() + ")", e8.j);
            return false;
        }
        if (!fn.a(A_0))
        {
            PluginCore.cq.n.a("Wandcaster activate test failed (" + A_0.ToString() + ")", e8.j);
            return false;
        }
        return true;
    }

    private void a(int A_0, bool A_1)
    {
        if (A_1 && (A_0 == this.g))
        {
            try
            {
                this.i = PluginCore.cq.e.b(PluginCore.cq.aw.get_WorldFilter().get_Item(A_0).Values(0xd000008, 0));
                int num = PluginCore.cq.aw.get_WorldFilter().get_Item(A_0).Values(0x6a, 0);
                if (this.i.Duration > 0.0)
                {
                    PluginCore.PC.b(this.i.Id, this.h, num);
                }
                PluginCore.cq.i.b(this.i.Id, this.h, num);
            }
            catch (Exception)
            {
            }
        }
    }

    public void a(int A_0, int A_1)
    {
        if (((PluginCore.cq.ax.get_Actions().get_CombatMode() == 8) && (this.a() == s.b.a)) && !PluginCore.cq.g.e())
        {
            if (this.c.Contains(A_0))
            {
                if (PluginCore.cq.n.e() == 0)
                {
                    return;
                }
                this.f = 2;
            }
            else
            {
                this.f = 0;
            }
            this.d = false;
            this.g = A_0;
            this.h = A_1;
            this.i = null;
            if (dh.b(A_0))
            {
                if (PluginCore.cq.aw.get_WorldFilter().get_Item(A_0).get_HasIdData())
                {
                    this.a(A_0, true);
                }
                else
                {
                    PluginCore.cq.u.b(A_0, new b0.b(this.a));
                }
            }
            PluginCore.cq.n.a("WandCaster: Begin", e8.i);
            this.a(s.b.d);
        }
    }

    private void a(object A_0, ChatTextInterceptEventArgs A_1)
    {
        try
        {
            string str;
            string str2;
            if ((this.a() == s.b.d) || (this.a() == s.b.e))
            {
                if (A_1.get_Color() != 7)
                {
                    goto Label_0152;
                }
                Match match = this.q.Match(A_1.get_Text());
                Match match2 = this.p.Match(A_1.get_Text());
                str = "";
                str2 = "";
                if (match.Success)
                {
                    str = match.Groups[1].Value;
                    str2 = match.Groups[2].Value;
                    goto Label_00B2;
                }
                if (match2.Success)
                {
                    str = match2.Groups[1].Value;
                    str2 = match2.Groups[2].Value;
                    goto Label_00B2;
                }
            }
            return;
        Label_00B2:
            if (str == this.i.Name)
            {
                WorldObject obj2 = CoreManager.get_Current().get_WorldFilter().get_Item(this.h);
                if ((obj2 == null) || (str2 == obj2.get_Name()))
                {
                    PluginCore.cq.n.a("WandCaster: Spell success reset (" + A_1.get_Text() + ")", e8.i);
                    this.a(s.b.a);
                    if (this.a != null)
                    {
                        this.a(this.i, this.h, false, false);
                    }
                }
            }
            return;
        Label_0152:
            if (A_1.get_Color() == 0)
            {
                for (int i = 0; i < PluginCore.cq.f.c.Count; i++)
                {
                    if (PluginCore.cq.f.c[i].Match(A_1.get_Text()).Success)
                    {
                        PluginCore.cq.n.a("WandCaster: Spell success reset (" + A_1.get_Text() + ")", e8.i);
                        this.a(s.b.a);
                        if (this.a != null)
                        {
                            this.a(this.i, this.h, true, !this.i.HitsMultipleTargets);
                        }
                        return;
                    }
                }
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    private void a(object A_0, NetworkMessageEventArgs A_1)
    {
        if (this.a() == s.b.d)
        {
            if (A_1.get_Message().get_Type() == 0xf7b0)
            {
                if ((A_1.get_Message().Value<int>("event") == 650) && (A_1.get_Message().Value<int>("type") == 0x4c8))
                {
                    this.f++;
                }
            }
            else if ((((((((((A_1.get_Message().get_Type() == 0xf74c) && (A_1.get_Message().Value<int>("object") == PluginCore.cq.aw.get_CharacterFilter().get_Id())) && (A_1.get_Message().Value<short>("activity") == 0)) && (A_1.get_Message().Value<byte>("animation_type") == 0)) && (A_1.get_Message().Value<byte>("type_flags") == 0)) && (A_1.get_Message().Value<short>("stance") == 0x49)) && ((A_1.get_Message().Value<int>("flags") & 0xf80) <= 0)) && ((A_1.get_Message().Value<int>("flags") & -68) <= 0)) && (A_1.get_Message().Value<short>("stance2") == 0x49)) && (A_1.get_Message().Value<short>("animation_1") == 0xe1))
            {
                this.a(s.b.e);
                this.f = 0;
                this.d = false;
            }
        }
    }

    private void a(object A_0, ReleaseObjectEventArgs A_1)
    {
        try
        {
            if ((this.a() != s.b.a) && (A_1.get_Released().get_Id() == this.h))
            {
                PluginCore.cq.n.a("WandCaster: Reset due to target deletion", e8.i);
                this.a(s.b.a);
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
            if ((DateTimeOffset.Now - this.e) > this.m)
            {
                PluginCore.cq.n.a("WandCaster: WandCasting timeout", e8.i);
                this.a(s.b.a);
            }
            if (!this.d && ((DateTimeOffset.Now - this.e) > TimeSpan.FromMilliseconds(200.0)))
            {
                if (er.j("JumpOutWandCasting") && !ff.a(PluginCore.cq.ax))
                {
                    PluginCore.cq.m.a(u.b, true);
                    PluginCore.cq.m.a(u.b, false);
                }
                this.d = true;
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    private bool b()
    {
        return er.j("DoJiggle");
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void b(s.a A_0)
    {
        this.a = (s.a) Delegate.Remove(this.a, A_0);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void b(s.c A_0)
    {
        this.b = (s.c) Delegate.Combine(this.b, A_0);
    }

    private void b(object A_0, EventArgs A_1)
    {
        try
        {
            if ((DateTimeOffset.Now - this.e) > this.k)
            {
                PluginCore.cq.n.a("WandCaster: WandAttempting timeout", e8.i);
                this.a(s.b.a);
            }
            if (this.f >= 3)
            {
                int num = PluginCore.cq.n.e();
                if (num == 0)
                {
                    if (!this.c.Contains(this.g))
                    {
                        this.c.Add(this.g);
                    }
                }
                else
                {
                    this.f = 0;
                    PluginCore.cq.n.n.a(ActionLockType.ManaStoneUse, TimeSpan.FromSeconds(3.0));
                    int num2 = PluginCore.cq.ax.get_Actions().get_CurrentSelection();
                    PluginCore.cq.ax.get_Actions().SelectItem(this.g);
                    PluginCore.cq.ax.get_Actions().UseItem(num, 1);
                    PluginCore.cq.ax.get_Actions().SelectItem(num2);
                }
            }
            else if (PluginCore.cq.n.a(8, this.g, false))
            {
                PluginCore.cq.ax.get_Actions().SelectItem(this.h);
                PluginCore.cq.ax.get_Actions().UseItem(this.g, 1, this.h);
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    public void c()
    {
        if (!this.n)
        {
            this.n = true;
            GC.SuppressFinalize(this);
            CoreManager.get_Current().remove_ChatBoxMessage(new EventHandler<ChatTextInterceptEventArgs>(this.a));
            CoreManager.get_Current().get_WorldFilter().remove_ReleaseObject(new EventHandler<ReleaseObjectEventArgs>(this.a));
            this.j.b(new EventHandler(this.b));
            this.l.b(new EventHandler(this.a));
            if (this.j != null)
            {
                this.j.e();
            }
            if (this.l != null)
            {
                this.l.e();
            }
        }
    }

    public bool d()
    {
        return (this.a() != s.b.a);
    }

    protected override void e()
    {
        try
        {
            this.c();
        }
        finally
        {
            base.Finalize();
        }
    }

    public delegate void a(MySpell A_0, int A_1, bool A_2, bool A_3);

    public enum b
    {
        a,
        b,
        c,
        d,
        e
    }

    public delegate void c(s.b A_0);
}

