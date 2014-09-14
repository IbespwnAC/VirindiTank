using MyClasses;
using System;
using System.Collections.Generic;
using System.Drawing;
using uTank2;
using VirindiViewService.Controls;

internal class ed : b3
{
    private string a = "Default";
    private HudCombo b;
    private bool c;
    private b1 d;

    private void a()
    {
        this.c = true;
        this.b.Clear();
        this.b.AddItem("Default", null);
        this.b.set_Current(0);
        foreach (KeyValuePair<string, int> pair in PluginCore.cq.@as.g())
        {
            if (!string.Equals(pair.Key, "Default"))
            {
                this.b.AddItem(pair.Key, null);
                if (string.Equals(this.a, pair.Key))
                {
                    this.b.set_Current(this.b.get_Count() - 1);
                }
            }
        }
        this.c = false;
    }

    public void a(b1 A_0)
    {
        this.d = A_0;
    }

    public void a(k A_0)
    {
        this.a = k.b(A_0);
    }

    public void a(object A_0)
    {
        HudFixedLayout layout = A_0 as HudFixedLayout;
        if (layout != null)
        {
            this.b = new HudCombo(layout.get_Group());
            layout.AddControl(this.b, new Rectangle(4, 0xb7, 0x94, 0x10));
            this.a();
            this.b.add_Change(new EventHandler(this.b));
            HudButton button = new HudButton();
            layout.AddControl(button, new Rectangle(0x9c, 0xb7, 0x94, 0x10));
            button.set_Text("New State...");
            button.add_Hit(new EventHandler(this.a));
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
        new ec(PluginCore.cq.ax, new string[] { "Cancel", "Okay" }, "Virindi Tank: New Meta State", "Meta state name:", 0x1ff6, new ec.a(ed.a), "", "newmetastate", null).b(new MyDialog<string>.delDialogReturned(this.a));
    }

    private void a(string A_0, string A_1)
    {
        if (string.Equals(A_0, "Okay"))
        {
            this.a = A_1;
            this.a();
            PluginCore.cq.@as.d();
            if (this.d != null)
            {
                this.d.c();
            }
        }
    }

    public bool b()
    {
        PluginCore.cq.@as.a(this.a);
        return false;
    }

    private void b(object A_0, EventArgs A_1)
    {
        if (!this.c)
        {
            this.a = ((HudStaticText) this.b.get_Item(this.b.get_Current())).get_Text();
            this.a();
            PluginCore.cq.@as.d();
        }
    }

    public void c()
    {
        if (this.d != null)
        {
            this.d.c();
        }
    }

    public k d()
    {
        return k.a(this.a);
    }

    public List<string> e()
    {
        return new List<string> { this.a };
    }

    public b1 f()
    {
        return this.d;
    }

    public ep h()
    {
        return ep.b;
    }

    public string j()
    {
        return ("Set Meta State: " + this.a);
    }

    public string l()
    {
        return "Set Meta State";
    }
}

