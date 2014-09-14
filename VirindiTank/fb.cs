using System;
using System.Drawing;
using uTank2;
using VirindiViewService.Controls;

internal class fb : ew, fl
{
    private int a;
    private HudStaticText b;

    private int a()
    {
        return (PluginCore.cq.p.d(PluginCore.cq.p.f()).b(PluginCore.cq.ax.get_Actions()).d() & -65536);
    }

    public override void a(k A_0)
    {
        this.a = k.e(A_0);
    }

    public override void a(object A_0)
    {
        HudFixedLayout layout = A_0 as HudFixedLayout;
        if (layout != null)
        {
            this.b = new HudStaticText();
            layout.AddControl(this.b, new Rectangle(4, 4, 0x124, 0x10));
            this.b.set_Text(this.k());
            HudButton button = new HudButton();
            layout.AddControl(button, new Rectangle(4, 0x18, 200, 0x10));
            button.set_Text("Set Current");
            button.add_Hit(new EventHandler(this.a));
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        this.a = this.a();
        this.b.set_Text(this.k());
        base.l();
    }

    public override k b()
    {
        return k.a(this.a);
    }

    public c3 c()
    {
        return c3.r;
    }

    public bool d()
    {
        return (this.a() == this.a);
    }

    public override string e()
    {
        return ("Landblock == " + this.a.ToString("X8"));
    }

    public override string f()
    {
        return "Landblock ==";
    }
}

