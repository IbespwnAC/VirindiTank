using MyClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using uTank2;
using VirindiViewService;
using VirindiViewService.Controls;

internal class du : IDisposable
{
    public const int a = 300;
    public const int b = 350;
    public const int c = 4;
    private bool d;
    private bool e;
    private HudView f;
    private d8 g;
    private HudFixedLayout h;
    private HudFixedLayout i;
    private HudFixedLayout j;
    private HudCombo k;
    private HudCombo l;
    private HudCombo m;
    private List<c3> n = new List<c3>();
    private List<ep> o = new List<ep>();

    private void a()
    {
        this.d = true;
        this.k.Clear();
        this.k.AddItem("Default", null);
        this.k.set_Current(0);
        foreach (KeyValuePair<string, int> pair in PluginCore.cq.@as.g())
        {
            if (!string.Equals(pair.Key, "Default"))
            {
                this.k.AddItem(pair.Key, null);
                if (string.Equals(this.g.c, pair.Key))
                {
                    this.k.set_Current(this.k.get_Count() - 1);
                }
            }
        }
        this.d = false;
    }

    private void a(d8 A_0)
    {
        fl a = A_0.a;
        b3 b = A_0.b;
        this.g = A_0;
        this.e = true;
        this.f = new HudView("Virindi Tank Edit Meta Rule", 0x264, 0x1a2, new ACImage());
        this.f.set_UserMinimizable(false);
        this.f.set_UserGhostable(false);
        this.f.LoadUserSettings();
        this.h = new HudFixedLayout();
        this.f.get_Controls().set_HeadControl(this.h);
        HudButton button = new HudButton();
        this.h.AddControl(button, new Rectangle(4, 0x18e, 0x40, 0x10));
        button.set_Text("Close");
        this.l = new HudCombo(this.f.get_Controls());
        this.m = new HudCombo(this.f.get_Controls());
        this.h.AddControl(this.l, new Rectangle(4, 4, 300, 0x10));
        this.h.AddControl(this.m, new Rectangle(0x134, 4, 300, 0x10));
        this.b();
        this.k = new HudCombo(this.f.get_Controls());
        this.h.AddControl(this.k, new Rectangle(4, 0x18, 0x94, 0x10));
        this.k.add_Change(new EventHandler(this.e));
        this.a();
        HudButton button2 = new HudButton();
        this.h.AddControl(button2, new Rectangle(0x9c, 0x18, 0x94, 0x10));
        button2.set_Text("New State...");
        button2.add_Hit(new EventHandler(this.d));
        this.h.AddControl(this.d(), new Rectangle(3, 0x2b, 1, 0x161));
        this.h.AddControl(this.c(), new Rectangle(4, 0x2b, 0x12d, 1));
        this.h.AddControl(this.c(), new Rectangle(4, 0x18b, 0x12d, 1));
        this.h.AddControl(this.d(), new Rectangle(0x131, 0x2b, 1, 0x161));
        this.h.AddControl(this.d(), new Rectangle(0x261, 0x2b, 1, 0x161));
        this.h.AddControl(this.d(), new Rectangle(0x133, 0x2b, 1, 0x161));
        this.h.AddControl(this.c(), new Rectangle(0x134, 0x2b, 0x12d, 1));
        this.h.AddControl(this.c(), new Rectangle(0x134, 0x18b, 0x12d, 1));
        this.i = new HudFixedLayout();
        this.j = new HudFixedLayout();
        this.h.AddControl(this.i, new Rectangle(4, 0x2c, 300, 350));
        this.h.AddControl(this.j, new Rectangle(0x134, 0x2c, 300, 350));
        a.j(this.i);
        b.j(this.j);
        button.add_Hit(new EventHandler(this.a));
        this.l.add_Change(new EventHandler(this.c));
        this.m.add_Change(new EventHandler(this.b));
        this.f.set_Visible(true);
    }

    private static string[] a(string A_0)
    {
        if (A_0 == "")
        {
            return new string[] { "Cancel" };
        }
        return new string[] { "Cancel", "Okay" };
    }

    private void a(object A_0, EventArgs A_1)
    {
        this.g();
    }

    private void a(string A_0, string A_1)
    {
        if (this.e && string.Equals(A_0, "Okay"))
        {
            PluginCore.cq.@as.a(this.g, A_1);
            this.a();
            PluginCore.cq.@as.d();
        }
    }

    private void b()
    {
        this.d = true;
        int num = 0;
        int num2 = 0;
        this.n.Clear();
        foreach (KeyValuePair<c3, fl> pair in cl.a)
        {
            fl fl = pair.Value;
            this.l.AddItem(fl.g(), fl.f());
            this.n.Add(fl.f());
            if (fl.f() == this.g.a.f())
            {
                num2 = num;
            }
            num++;
        }
        this.l.set_Current(num2);
        num = 0;
        this.o.Clear();
        foreach (KeyValuePair<ep, b3> pair2 in cl.b)
        {
            b3 b = pair2.Value;
            this.m.AddItem(b.g(), b.d());
            this.o.Add(b.d());
            if (b.d() == this.g.b.d())
            {
                num2 = num;
            }
            num++;
        }
        this.m.set_Current(num2);
        this.d = false;
    }

    public void b(d8 A_0)
    {
        if (ff.a(PluginCore.cq.ax, new Version(1, 0, 0, 0x2d)))
        {
            this.a(A_0);
        }
    }

    private void b(object A_0, EventArgs A_1)
    {
        if ((this.m.get_Current() >= 0) && (this.m.get_Current() < this.o.Count))
        {
            this.j.Dispose();
            this.g.b = cl.a(this.o[this.m.get_Current()]);
            this.j = new HudFixedLayout();
            this.h.AddControl(this.j, new Rectangle(0x134, 0x2c, 300, 350));
            this.g.b.j(this.j);
            PluginCore.cq.@as.d();
        }
    }

    private HudThemeElement c()
    {
        HudThemeElement element = new HudThemeElement();
        element.set_FillElement("ButtonHighlight");
        return element;
    }

    private void c(object A_0, EventArgs A_1)
    {
        if ((this.l.get_Current() >= 0) && (this.l.get_Current() < this.n.Count))
        {
            this.i.Dispose();
            this.g.a = cl.a(this.n[this.l.get_Current()]);
            this.i = new HudFixedLayout();
            this.h.AddControl(this.i, new Rectangle(4, 0x2c, 300, 350));
            this.g.a.j(this.i);
            PluginCore.cq.@as.d();
        }
    }

    private HudThemeElement d()
    {
        HudThemeElement element = new HudThemeElement();
        element.set_FillElement("ButtonShadow");
        return element;
    }

    private void d(object A_0, EventArgs A_1)
    {
        new ec(PluginCore.cq.ax, new string[] { "Cancel", "Okay" }, "Virindi Tank: New Meta State", "Meta state name:", 0x1ff6, new ec.a(du.a), "", "newmetastate", null).b(new MyDialog<string>.delDialogReturned(this.a));
    }

    private void e()
    {
        if (this.f != null)
        {
            this.f.Dispose();
            this.f = null;
        }
        this.e = false;
        this.g = null;
        this.j = null;
        this.i = null;
    }

    private void e(object A_0, EventArgs A_1)
    {
        if (!this.d)
        {
            string str = ((HudStaticText) this.k.get_Item(this.k.get_Current())).get_Text();
            PluginCore.cq.@as.a(this.g, str);
            this.a();
            PluginCore.cq.@as.d();
        }
    }

    public void f()
    {
        if (this.e)
        {
            this.e();
        }
    }

    public void g()
    {
        if (this.e)
        {
            this.e();
        }
    }
}

