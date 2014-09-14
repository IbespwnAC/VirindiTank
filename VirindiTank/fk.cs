using System;
using System.Collections.Generic;
using System.Drawing;
using uTank2;
using VirindiViewService.Controls;

internal class fk : b3
{
    private string a = "";
    private HudTextBox b;
    private b1 c;

    public bool a()
    {
        if (!string.IsNullOrEmpty(this.a))
        {
            dh.h(this.a);
        }
        return true;
    }

    public void a(b1 A_0)
    {
        this.c = A_0;
    }

    public void a(k A_0)
    {
        this.a = k.b(A_0);
        if (this.a == null)
        {
            this.a = "";
        }
    }

    public void a(object A_0)
    {
        HudFixedLayout layout = A_0 as HudFixedLayout;
        if (layout != null)
        {
            this.b = new HudTextBox();
            layout.AddControl(this.b, new Rectangle(4, 0xb7, 0x124, 0x10));
            this.b.set_Text(this.a);
            this.b.add_Change(new EventHandler(this.a));
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        this.a = this.b.get_Text();
        PluginCore.cq.@as.d();
        if (this.c != null)
        {
            this.c.c();
        }
    }

    public void b()
    {
        if (this.c != null)
        {
            this.c.c();
        }
    }

    public k c()
    {
        return k.a(this.a);
    }

    public List<string> d()
    {
        return null;
    }

    public b1 e()
    {
        return this.c;
    }

    public ep f()
    {
        return ep.c;
    }

    public string h()
    {
        return ("Chat Command: " + this.a);
    }

    public string j()
    {
        return "Chat Command";
    }
}

