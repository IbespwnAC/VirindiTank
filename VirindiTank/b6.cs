using System;
using System.Collections.Generic;
using System.Drawing;
using VirindiViewService;
using VirindiViewService.Controls;

internal class b6 : ew, fl
{
    private fl a = new b4();
    private HudCombo b;
    private List<int> c = new List<int>();
    private HudStaticText d;
    private HudView e;
    private HudFixedLayout f;
    private HudFixedLayout g;

    public b6()
    {
        this.a.a(this);
    }

    public override k a()
    {
        a0 a = new a0(new string[] { "K", "V" });
        v v = new v(a);
        v[0] = k.a((int) this.a.f());
        v[1] = this.a.i();
        a.c(v);
        return new k(a);
    }

    private static string a(b1 A_0)
    {
        if (A_0 == null)
        {
            return "";
        }
        return (a(A_0.b()) + " > " + A_0.g());
    }

    public override void a(k A_0)
    {
        a0 a = A_0.c() as a0;
        if (((a != null) && (a.a() == 2)) && (a.c() == 1))
        {
            v v = a.d()[0];
            this.a = cl.a((c3) k.e(v[0]));
            this.a.h(v[1]);
            this.a.a(this);
        }
    }

    public override void a(object A_0)
    {
        HudFixedLayout layout = A_0 as HudFixedLayout;
        if (layout != null)
        {
            int y = 4;
            this.d = new HudStaticText();
            layout.AddControl(this.d, new Rectangle(4, y, 0x124, 0x10));
            this.d.set_Text(this.a.k());
            y += 20;
            this.c.Clear();
            this.b = new HudCombo(layout.get_Group());
            layout.AddControl(this.b, new Rectangle(4, y, 150, 0x10));
            foreach (int num2 in cl.GetTypeIDs<fl>())
            {
                this.c.Add(num2);
                fl fl = cl.Create<fl>(num2);
                this.b.AddItem(fl.g(), null);
                if (fl.f() == this.a.f())
                {
                    this.b.set_Current(this.b.get_Count() - 1);
                }
            }
            this.b.add_Change(new EventHandler(this.a));
            HudButton button = new HudButton();
            layout.AddControl(button, new Rectangle(0x9e, y, 100, 0x10));
            button.set_Text("Edit");
            button.add_Hit(new EventHandler(this.c));
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        if ((this.b.get_Current() >= 0) && (this.b.get_Current() < this.c.Count))
        {
            int v = this.c[this.b.get_Current()];
            fl fl = cl.Create<fl>(v);
            fl.a(this);
            this.a = fl;
            this.d.set_Text(this.a.k());
            base.l();
        }
    }

    public c3 b()
    {
        return c3.v;
    }

    private void b(object A_0, EventArgs A_1)
    {
        if (this.e != null)
        {
            this.e.Dispose();
            this.e = null;
        }
    }

    public bool c()
    {
        return !this.a.h();
    }

    private void c(object A_0, EventArgs A_1)
    {
        if (this.e != null)
        {
            this.e.Dispose();
        }
        fl a = this.a;
        this.e = new HudView("Edit " + b6.a((b1) a), 300, 0x176, new ACImage(Color.Red));
        this.e.set_UserMinimizable(false);
        this.e.set_UserGhostable(false);
        this.e.LoadUserSettings();
        this.e.set_Visible(true);
        this.f = new HudFixedLayout();
        this.e.get_Controls().set_HeadControl(this.f);
        HudButton button = new HudButton();
        this.f.AddControl(button, new Rectangle(4, 0x162, 150, 0x10));
        button.set_Text("Close");
        button.add_Hit(new EventHandler(this.b));
        this.g = new HudFixedLayout();
        this.f.AddControl(this.g, new Rectangle(0, 0, 300, 350));
        a.j(this.g);
    }

    public override string d()
    {
        return ("NOT " + this.a.k());
    }

    public override string e()
    {
        return "Not";
    }

    public override void h()
    {
        base.h();
        this.d.set_Text(this.a.k());
    }
}

