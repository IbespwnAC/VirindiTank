using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using uTank2;

internal class dv : IDisposable
{
    private dv.c a;
    private dv.b b;
    private dv.a c;
    private string d;
    private int e;
    private MySpell f;
    private Regex g = new Regex("\\\".*\\\"");
    private dv.d h;
    private e3 i = new e3();
    private e3 j = new e3();
    private ev k;
    private bool l;
    private int m;
    private int n;
    private int o;
    private int p;
    private int q;
    private bool r;

    public dv(ev A_0)
    {
        this.k = A_0;
        this.j.a(0xc7);
        this.m = 0x1388 / this.j.h();
        this.i.a(0x38b);
        this.p = 0x1194 / this.i.h();
        this.o = 0x708 / this.i.h();
        this.k.aw.add_ChatBoxMessage(new EventHandler<ChatTextInterceptEventArgs>(this.a));
        this.k.aw.get_WorldFilter().add_ReleaseObject(new EventHandler<ReleaseObjectEventArgs>(this.a));
        this.i.a(new EventHandler(this.a));
        this.j.a(new EventHandler(this.b));
    }

    private void a()
    {
        if (this.f.School.Name == "Void Magic")
        {
            PluginCore.cq.n.n.a(ActionLockType.WarSpellLockedOut, TimeSpan.FromSeconds(5.5));
        }
        else if (this.f.School.Name == "War Magic")
        {
            PluginCore.cq.n.n.a(ActionLockType.VoidSpellLockedOut, TimeSpan.FromSeconds(5.5));
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void a(dv.a A_0)
    {
        this.c = (dv.a) Delegate.Remove(this.c, A_0);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void a(dv.b A_0)
    {
        this.b = (dv.b) Delegate.Combine(this.b, A_0);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void a(dv.c A_0)
    {
        this.a = (dv.c) Delegate.Remove(this.a, A_0);
    }

    private void a(dv.d A_0)
    {
        if ((this.h == dv.d.c) && (A_0 == dv.d.a))
        {
            this.a();
        }
        this.h = A_0;
        switch (A_0)
        {
            case dv.d.a:
                this.k.n.k = false;
                this.i.a(false);
                this.j.a(false);
                PluginCore.cq.b.d();
                break;

            case dv.d.b:
                this.k.n.k = true;
                this.i.a(false);
                this.n = 0;
                this.j.a(true);
                PluginCore.cq.b.d();
                break;

            case dv.d.c:
                PluginCore.cq.al.a(this.e);
                this.k.n.k = true;
                this.q = 0;
                this.i.a(true);
                this.j.a(false);
                PluginCore.cq.aq.b();
                if (this.b() && (!this.f.IsInstantCast || ((this.f.School.Id != 1) && (this.f.School.Id != 5))))
                {
                    PluginCore.cq.b.c();
                }
                break;
        }
        if (this.c != null)
        {
            this.c(A_0);
        }
    }

    private void a(int A_0, int A_1)
    {
        if (this.l)
        {
            dh.b(A_0, A_1);
        }
        else
        {
            PluginCore.cq.ax.get_Actions().CastSpell(A_0, A_1);
        }
    }

    private void a(object A_0, ChatTextInterceptEventArgs A_1)
    {
        try
        {
            int num;
            switch (this.h)
            {
                case dv.d.a:
                    return;

                case dv.d.b:
                    if (((A_1.get_Text().Length >= 9) && (A_1.get_Text().Substring(0, 9).CompareTo("You say, ") == 0)) && (A_1.get_Color() == 0x11))
                    {
                        string str = this.g.Match(A_1.get_Text()).Value.Substring(1);
                        str = str.Substring(0, str.Length - 1).ToLowerInvariant().Replace(" ", "");
                        if (!(this.k.e.b(this.f.Id).Saying == str))
                        {
                            break;
                        }
                        this.a(dv.d.c);
                    }
                    return;

                case dv.d.c:
                    if ((A_1.get_Color() != 0) || !this.f.CanKill)
                    {
                        goto Label_0231;
                    }
                    num = 0;
                    goto Label_0216;

                default:
                    return;
            }
            this.a(dv.d.a);
            return;
        Label_0101:
            if (this.k.f.c[num].Match(A_1.get_Text()).Success)
            {
                A_1.set_Eat(true);
                if (!this.f.HitsMultipleTargets)
                {
                    if (this.a != null)
                    {
                        this.a(this.f, this.e, true, true, A_1);
                    }
                    if (this.b != null)
                    {
                        this.b(this.f, this.e, true, true);
                    }
                }
                else
                {
                    if (this.a != null)
                    {
                        this.a(this.f, this.e, false, true, A_1);
                    }
                    if (this.b != null)
                    {
                        this.b(this.f, this.e, false, true);
                    }
                }
                PluginCore.cq.n.a("SpellCaster: Spell kill reset (" + A_1.get_Text() + ")", e8.i);
                this.a(dv.d.a);
                PluginCore.cq.am.a(this.e);
                return;
            }
            num++;
        Label_0216:
            if (num < this.k.f.c.Count)
            {
                goto Label_0101;
            }
        Label_0231:
            if (A_1.get_Color() == 7)
            {
                for (int i = 0; i < this.k.f.a.Count; i++)
                {
                    if (this.k.f.a[i].Match(A_1.get_Text()).Success)
                    {
                        PluginCore.cq.n.a("SpellCaster: Spell fail reset (" + A_1.get_Text() + ")", e8.i);
                        this.a(dv.d.a);
                        return;
                    }
                }
                for (int j = 0; j < this.k.f.b.Count; j++)
                {
                    Match match = this.k.f.b[j].Match(A_1.get_Text());
                    if (match.Success)
                    {
                        Group group = match.Groups["spellname"];
                        if (!group.Success || this.f.Name.Equals(group.Value, StringComparison.Ordinal))
                        {
                            Group group2 = match.Groups["targetname"];
                            if ((!group2.Success || string.IsNullOrEmpty(this.d)) || this.d.Equals(group2.Value, StringComparison.OrdinalIgnoreCase))
                            {
                                PluginCore.cq.n.a("SpellCaster: Spell success reset (" + A_1.get_Text() + ")", e8.i);
                                if (this.a != null)
                                {
                                    this.a(this.f, this.e, false, false, A_1);
                                }
                                if (this.b != null)
                                {
                                    this.b(this.f, this.e, false, false);
                                }
                                this.a(dv.d.a);
                                PluginCore.cq.am.a(this.e);
                                return;
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

    private void a(object A_0, ReleaseObjectEventArgs A_1)
    {
        try
        {
            if ((this.h != dv.d.a) && (A_1.get_Released().get_Id() == this.e))
            {
                PluginCore.cq.n.a("SpellCaster: Reset due to target deletion", e8.i);
                this.d();
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
            this.q++;
            if (this.q >= this.o)
            {
                PluginCore.cq.b.d();
            }
            if (this.q >= this.p)
            {
                PluginCore.cq.n.a("SpellCaster: Cast result timeout", e8.i);
                this.a(dv.d.a);
                if (!this.f.HitsMultipleTargets)
                {
                    PluginCore.cq.am.b(this.e);
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
        this.a(A_0, A_1, false);
    }

    public void a(MySpell A_0, int A_1, bool A_2)
    {
        if (((PluginCore.cq.ax.get_Actions().get_CombatMode() == 8) && ((A_0.School.Name != "Void Magic") || !PluginCore.cq.n.n.b(ActionLockType.VoidSpellLockedOut))) && ((A_0.School.Name != "War Magic") || !PluginCore.cq.n.n.b(ActionLockType.WarSpellLockedOut)))
        {
            this.l = A_2;
            if ((A_0.isValid && !PluginCore.cq.z.d()) && (this.h == dv.d.a))
            {
                try
                {
                    if (A_0.Duration > 0.0)
                    {
                        PluginCore.PC.b(A_0.Id, A_1, A_0.SkillWithSchool);
                    }
                    this.k.n.a("Casting: " + A_0.Name + " on " + A_1.ToString() + " (" + this.k.aw.get_WorldFilter().get_Item(A_1).get_Name() + ")", e8.d);
                }
                catch (Exception)
                {
                    this.k.n.a("Casting: " + A_0.Name + " on " + A_1.ToString() + " (Target Invalid)", e8.d);
                }
                this.f = A_0;
                this.e = A_1;
                cv cv = PluginCore.cq.p.d(this.e);
                if (cv != null)
                {
                    if (this.f.School.Name.Equals("Item Enchantment"))
                    {
                        this.d = null;
                    }
                    else if (cv.k == PluginCore.cg)
                    {
                        this.d = "yourself";
                    }
                    else
                    {
                        this.d = cv.g();
                    }
                }
                else
                {
                    this.d = null;
                }
                this.a(A_0.Id, A_1);
                if (PluginCore.cq.ax.get_Actions().get_Vital().get_Item(6) < 10)
                {
                    this.j.a(100);
                }
                else
                {
                    this.j.a(200);
                }
                this.m = 0x1388 / this.j.h();
                PluginCore.cq.n.a("SpellCaster: Begin", e8.i);
                this.a(dv.d.b);
            }
        }
    }

    private bool b()
    {
        return er.j("DoJiggle");
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void b(dv.a A_0)
    {
        this.c = (dv.a) Delegate.Combine(this.c, A_0);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void b(dv.b A_0)
    {
        this.b = (dv.b) Delegate.Remove(this.b, A_0);
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void b(dv.c A_0)
    {
        this.a = (dv.c) Delegate.Combine(this.a, A_0);
    }

    private void b(object A_0, EventArgs A_1)
    {
        try
        {
            this.n++;
            if (this.n >= this.m)
            {
                PluginCore.cq.n.a("SpellCaster: Attempt timeout", e8.i);
                this.a(dv.d.a);
            }
            else
            {
                this.a(this.f.Id, this.e);
                PluginCore.cq.al.b(this.e);
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    public void c()
    {
        if (!this.r)
        {
            this.r = true;
            GC.SuppressFinalize(this);
            this.k.aw.get_WorldFilter().remove_ReleaseObject(new EventHandler<ReleaseObjectEventArgs>(this.a));
            this.k.aw.remove_ChatBoxMessage(new EventHandler<ChatTextInterceptEventArgs>(this.a));
            this.i.b(new EventHandler(this.a));
            this.j.b(new EventHandler(this.b));
            if (this.j != null)
            {
                this.j.e();
            }
            if (this.i != null)
            {
                this.i.e();
            }
            this.k = null;
        }
    }

    public void d()
    {
        this.a(dv.d.a);
    }

    public bool e()
    {
        return (this.h == dv.d.c);
    }

    protected override void f()
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

    public delegate void a(dv.d A_0);

    public delegate void b(MySpell A_0, int A_1, bool A_2, bool A_3);

    public delegate void c(MySpell A_0, int A_1, bool A_2, bool A_3, ChatTextInterceptEventArgs A_4);

    public enum d
    {
        a,
        b,
        c
    }
}

