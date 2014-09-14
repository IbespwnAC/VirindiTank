using System;
using System.Collections.Generic;
using System.Drawing;
using uTank2;
using VirindiViewService.Controls;

internal class fg : fl
{
    private int a;
    private HudTextBox b;
    private b1 c;

    public void a()
    {
        if (this.c != null)
        {
            this.c.c();
        }
    }

    public void a(b1 A_0)
    {
        this.c = A_0;
    }

    public void a(k A_0)
    {
        this.a = k.e(A_0);
    }

    public void a(object A_0)
    {
        HudFixedLayout layout = A_0 as HudFixedLayout;
        if (layout != null)
        {
            this.b = new HudTextBox();
            layout.AddControl(this.b, new Rectangle(4, 0xb7, 0x124, 0x10));
            this.b.set_Text(this.a.ToString());
            this.b.add_Change(new EventHandler(this.a));
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        int.TryParse(this.b.get_Text(), out this.a);
        PluginCore.cq.@as.d();
        if (this.c != null)
        {
            this.c.c();
        }
    }

    public k b()
    {
        return k.a(this.a);
    }

    public List<string> c()
    {
        return null;
    }

    public c3 d()
    {
        return c3.f;
    }

    public b1 e()
    {
        return this.c;
    }

    public bool f()
    {
        return (PluginCore.cq.p.e() <= this.a);
    }

    public string h()
    {
        return ("Packslots <= " + this.a.ToString());
    }

    public string j()
    {
        return "Pack Slots <=";
    }
}

