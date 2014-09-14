using System;
using System.Drawing;
using uTank2;
using VirindiViewService.Controls;

internal abstract class t : ew
{
    private HudTextBox a;

    protected t()
    {
    }

    protected abstract string a();
    public override void a(object A_0)
    {
        HudFixedLayout layout = A_0 as HudFixedLayout;
        if (layout != null)
        {
            this.a = new HudTextBox();
            layout.AddControl(this.a, new Rectangle(4, 0xb7, 0x124, 0x10));
            this.a.set_Text(this.a());
            this.a.add_Change(new EventHandler(this.a));
        }
    }

    protected abstract void a(string A_0);
    private void a(object A_0, EventArgs A_1)
    {
        this.a(this.a.get_Text());
        PluginCore.cq.@as.d();
        if (base.m() != null)
        {
            base.m().c();
        }
    }
}

