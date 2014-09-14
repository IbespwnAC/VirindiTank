using Decal.Adapter;
using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using uTank2;

internal class el : IDisposable
{
    private bool a;
    private Regex b = new Regex("^You cast (?'spellname'.*) on .*$", RegexOptions.Compiled);
    private Regex c = new Regex(@"^(Critical hit\!)?[ ]*You .* for .* point(s)? of .*\!$", RegexOptions.Compiled);
    private e3 d = new e3();
    private int e;
    private string f = "";
    private DateTimeOffset g = DateTimeOffset.MinValue;
    private string h = "!!!! MeleeAttack timer";
    private int i;
    private bool j;
    private bool k;
    private List<DateTimeOffset> l = new List<DateTimeOffset>();
    private float m = 1f;
    private MySpell n;

    public el(CoreManager A_0)
    {
        this.d.a(new EventHandler(this.a));
        this.d.a(0x107);
        A_0.get_EchoFilter().add_ClientDispatch(new EventHandler<NetworkMessageEventArgs>(this.a));
        A_0.add_ChatBoxMessage(new EventHandler<ChatTextInterceptEventArgs>(this.a));
        A_0.add_WindowMessage(new EventHandler<WindowMessageEventArgs>(this.a));
    }

    private void a()
    {
        if (this.j && !PluginCore.cq.n.n.b(ActionLockType.MeleeAttackShot))
        {
            c6 c = (c6) er.i("DefaultMeleeAttackHeight");
            if (er.j("AutoAttackPower"))
            {
                dh.a(this.m);
            }
            bool flag = true;
            if (!dh.i((int) c))
            {
                flag = false;
            }
            if (!dh.a((int) c, (float) -1f))
            {
                flag = false;
            }
            if (!flag && !dh.i())
            {
                u u = this.a(c);
                PluginCore.cq.m.a(u, true);
                PluginCore.cq.m.a(u, false);
                this.l.Add(DateTimeOffset.Now);
            }
            this.k = true;
            PluginCore.cq.n.n.a(ActionLockType.MeleeAttackShot, TimeSpan.FromSeconds(0.75));
        }
    }

    private u a(c6 A_0)
    {
        switch (A_0)
        {
            case c6.c:
                return u.n;

            case c6.b:
                return u.l;

            case c6.a:
                return u.m;
        }
        return u.l;
    }

    private void a(object A_0, ChatTextInterceptEventArgs A_1)
    {
        try
        {
            if (!this.j)
            {
                TimeSpan span = (TimeSpan) (DateTimeOffset.Now - this.g);
                if (span.TotalSeconds > 2.0)
                {
                    return;
                }
            }
            if (!this.j || (PluginCore.cq.ax.get_Actions().get_CurrentSelection() == this.e))
            {
                if ((this.n != null) && (A_1.get_Color() == 7))
                {
                    Match match = this.b.Match(A_1.get_Text());
                    if (!match.Success)
                    {
                        return;
                    }
                    if (match.Groups["spellname"].Value == this.n.Name)
                    {
                        PluginCore.cq.i.a(this.n, this.e);
                    }
                }
                if (A_1.get_Color() == 0)
                {
                    if (A_1.get_Text().Trim().Equals("Your missile attack hit the environment."))
                    {
                        PluginCore.cq.am.b(this.e);
                    }
                }
                else if ((A_1.get_Color() == 0x16) && this.c.IsMatch(A_1.get_Text()))
                {
                    PluginCore.cq.am.a(this.e);
                }
                if (A_1.get_Color() == 0)
                {
                    for (int i = 0; i < PluginCore.cq.f.c.Count; i++)
                    {
                        Match match2 = PluginCore.cq.f.c[i].Match(A_1.get_Text());
                        if (match2.Success)
                        {
                            A_1.set_Eat(true);
                            if (er.j("EnableLooting"))
                            {
                                PluginCore.cq.n.n.a(ActionLockType.Navigation, TimeSpan.FromSeconds(3.0));
                            }
                            l.f();
                            Group group = match2.Groups["targetname"];
                            if ((((((group == null) || !group.Success) || string.Equals(this.f, group.Value, StringComparison.Ordinal)) && (!dh.a(PluginCore.cq.av.d()) || (PluginCore.cq.n.d(PluginCore.cq.av.d()).k <= 1))) && ((!dh.a(PluginCore.cq.av.e()) || (PluginCore.cq.p.d(PluginCore.cq.av.e()).c() != ObjectClass.MeleeWeapon)) || (PluginCore.cq.n.d(PluginCore.cq.av.d()).k <= 1))) && PluginCore.cq.n.f.ContainsKey(this.e))
                            {
                                PluginCore.cq.n.f[this.e].a = true;
                                PluginCore.PC.f(this.e);
                            }
                            return;
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

    private void a(object A_0, NetworkMessageEventArgs A_1)
    {
        try
        {
            if (PluginCore.cq.n.b && ((A_1.get_Message().get_Type() == 0xf7b1) && (A_1.get_Message().Value<int>("action") == 10)))
            {
                this.g = DateTimeOffset.Now;
                if (this.k)
                {
                    this.b();
                }
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    private void a(object A_0, WindowMessageEventArgs A_1)
    {
        try
        {
            if ((A_1.get_Msg() == 0x100) && ((A_1.get_LParam() & 0x40000000) == 0))
            {
                u u = (u) A_1.get_WParam();
                if (((u == this.a(c6.a)) || (u == this.a(c6.b))) || (u == this.a(c6.c)))
                {
                    int num = -1;
                    for (int i = 0; i < this.l.Count; i++)
                    {
                        TimeSpan span = (TimeSpan) (DateTimeOffset.Now - this.l[i]);
                        if (span.TotalSeconds <= 2.0)
                        {
                            break;
                        }
                        num = i;
                    }
                    if (num >= 0)
                    {
                        this.l.RemoveRange(0, num + 1);
                    }
                    if (this.l.Count > 0)
                    {
                        this.l.RemoveAt(0);
                    }
                    else
                    {
                        this.k = false;
                    }
                }
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
            fj.b(this.h);
            if (this.j)
            {
                if (PluginCore.cq.ax.get_Actions().get_CurrentSelection() != this.e)
                {
                    PluginCore.cq.ax.get_Actions().SelectItem(this.e);
                    PluginCore.cq.n.n.a(ActionLockType.MeleeAttackShot);
                }
                else
                {
                    this.a();
                }
            }
            else
            {
                this.b();
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
        finally
        {
            fj.a(this.h, 50.0);
        }
    }

    public void a(int A_0, float A_1, MySpell A_2)
    {
        if (this.e != A_0)
        {
            PluginCore.cq.ax.get_Actions().SelectItem(A_0);
            this.d.f();
            this.d.d();
        }
        cv cv = PluginCore.cq.p.d(A_0);
        if (cv != null)
        {
            this.f = cv.g();
        }
        else
        {
            this.f = "";
        }
        this.e = A_0;
        this.m = A_1;
        this.n = A_2;
        this.j = true;
        this.i = 0;
    }

    private void b()
    {
        if (!this.j && !PluginCore.cq.n.n.b(ActionLockType.MeleeAttackShot))
        {
            this.i++;
            this.e = 0;
            this.f = "";
            dh.c();
            if (dh.a(PluginCore.cq.ax.get_Actions().get_CurrentSelection()) && (PluginCore.cq.p.d(PluginCore.cq.ax.get_Actions().get_CurrentSelection()).c() == ObjectClass.Monster))
            {
                PluginCore.cq.ax.get_Actions().SelectItem(PluginCore.cg);
            }
            if (!dh.i() && ((PluginCore.cq.ax.get_Actions().get_CombatMode() == 2) || (PluginCore.cq.ax.get_Actions().get_CombatMode() == 4)))
            {
                PluginCore.cq.m.a(u.f, true);
                PluginCore.cq.m.a(u.f, false);
                PluginCore.cq.n.n.a(ActionLockType.MeleeAttackShot, TimeSpan.FromSeconds(1.0));
            }
            this.d.f();
        }
    }

    public void c()
    {
        if (!this.a)
        {
            this.a = true;
            GC.SuppressFinalize(this);
            PluginCore.cq.aw.get_EchoFilter().remove_ClientDispatch(new EventHandler<NetworkMessageEventArgs>(this.a));
            PluginCore.cq.aw.remove_ChatBoxMessage(new EventHandler<ChatTextInterceptEventArgs>(this.a));
            PluginCore.cq.aw.remove_WindowMessage(new EventHandler<WindowMessageEventArgs>(this.a));
            this.d.b(new EventHandler(this.a));
            if (this.d != null)
            {
                this.d.e();
            }
            this.d = null;
        }
    }

    public bool d()
    {
        if (this.j)
        {
            this.j = false;
            PluginCore.cq.n.n.a(ActionLockType.MeleeAttackShot);
            this.i = 0;
        }
        if (this.i <= 1)
        {
            this.b();
        }
        return (this.i > 1);
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

    private enum a
    {
        a,
        b
    }
}

