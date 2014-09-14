using MyClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using uTank2;
using VirindiViewService.Controls;

internal class fm : b3
{
    private string a = "Default";
    private string b = "Default";
    private HudCombo c;
    private HudCombo d;
    private bool e;
    private b1 f;

    private void a()
    {
        this.e = true;
        this.c.Clear();
        this.d.Clear();
        this.c.AddItem("Default", null);
        this.d.AddItem("Default", null);
        this.c.set_Current(0);
        this.d.set_Current(0);
        foreach (KeyValuePair<string, int> pair in PluginCore.cq.@as.g())
        {
            if (!string.Equals(pair.Key, "Default"))
            {
                this.c.AddItem(pair.Key, null);
                this.d.AddItem(pair.Key, null);
                if (string.Equals(this.a, pair.Key))
                {
                    this.c.set_Current(this.c.get_Count() - 1);
                }
                if (string.Equals(this.b, pair.Key))
                {
                    this.d.set_Current(this.d.get_Count() - 1);
                }
            }
        }
        this.e = false;
    }

    public void a(b1 A_0)
    {
        this.f = A_0;
    }

    public void a(k A_0)
    {
        a0 a = A_0.c() as a0;
        this.a = k.b(a.a(0, k.a("st"))[1]);
        this.b = k.b(a.a(0, k.a("ret"))[1]);
    }

    public void a(object A_0)
    {
        HudFixedLayout layout = A_0 as HudFixedLayout;
        if (layout != null)
        {
            this.c = new HudCombo(layout.get_Group());
            layout.AddControl(this.c, new Rectangle(4, 0xb7, 0x94, 0x10));
            this.c.add_Change(new EventHandler(this.d));
            HudButton button = new HudButton();
            layout.AddControl(button, new Rectangle(0x9c, 0xb7, 0x94, 0x10));
            button.set_Text("New State...");
            button.add_Hit(new EventHandler(this.b));
            this.d = new HudCombo(layout.get_Group());
            layout.AddControl(this.d, new Rectangle(4, 0xc7, 0x94, 0x10));
            this.d.add_Change(new EventHandler(this.c));
            button = new HudButton();
            layout.AddControl(button, new Rectangle(0x9c, 0xc7, 0x94, 0x10));
            button.set_Text("New State...");
            button.add_Hit(new EventHandler(this.a));
            this.a();
        }
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
        new ec(PluginCore.cq.ax, new string[] { "Cancel", "Okay" }, "Virindi Tank: New Meta State", "Meta state name:", 0x1ff6, new ec.a(fm.a), "", "newmetastate", null).b(new MyDialog<string>.delDialogReturned(this.a));
    }

    private void a(string A_0, string A_1)
    {
        if (string.Equals(A_0, "Okay"))
        {
            this.b = A_1;
            this.a();
            PluginCore.cq.@as.d();
            if (this.f != null)
            {
                this.f.c();
            }
        }
    }

    public bool b()
    {
        if (PluginCore.cq.@as.i.Count >= 0x2710)
        {
            PluginCore.e("Meta Error: Call stack overflow (recursive call loop?).");
            PluginCore.e("Disabling Meta.");
            er.b("EnableMeta", k.a(false));
            return false;
        }
        PluginCore.cq.@as.i.Push(this.b);
        PluginCore.cq.@as.a(this.a);
        return false;
    }

    private void b(object A_0, EventArgs A_1)
    {
        new ec(PluginCore.cq.ax, new string[] { "Cancel", "Okay" }, "Virindi Tank: New Meta State", "Meta state name:", 0x1ff6, new ec.a(fm.a), "", "newmetastate", null).b(new MyDialog<string>.delDialogReturned(this.b));
    }

    private void b(string A_0, string A_1)
    {
        if (string.Equals(A_0, "Okay"))
        {
            this.a = A_1;
            this.a();
            PluginCore.cq.@as.d();
            if (this.f != null)
            {
                this.f.c();
            }
        }
    }

    public void c()
    {
        if (this.f != null)
        {
            this.f.c();
        }
    }

    private void c(object A_0, EventArgs A_1)
    {
        if (!this.e)
        {
            this.b = ((HudStaticText) this.d.get_Item(this.d.get_Current())).get_Text();
            this.a();
            PluginCore.cq.@as.d();
        }
    }

    public k d()
    {
        a0 a = new a0(new string[] { "k", "v" });
        v v = new v(a);
        v[0] = k.a("st");
        v[1] = k.a(this.a);
        a.c(v);
        v = new v(a);
        v[0] = k.a("ret");
        v[1] = k.a(this.b);
        a.c(v);
        return new k(a);
    }

    private void d(object A_0, EventArgs A_1)
    {
        if (!this.e)
        {
            this.a = ((HudStaticText) this.c.get_Item(this.c.get_Current())).get_Text();
            this.a();
            PluginCore.cq.@as.d();
        }
    }

    public List<string> e()
    {
        return new List<string> { this.a, this.b };
    }

    public b1 f()
    {
        return this.f;
    }

    public ep h()
    {
        return ep.f;
    }

    public string j()
    {
        return ("Call: " + this.a + ", return to: " + this.b);
    }

    public string l()
    {
        return "Call Meta State";
    }
}

