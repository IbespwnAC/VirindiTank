using System;
using System.Collections.Generic;
using System.Drawing;
using VirindiViewService.Controls;

internal abstract class dw : ew
{
    private List<HudTextBox> a = new List<HudTextBox>();

    protected dw()
    {
    }

    protected abstract string a(int A_0);
    public override void a(object A_0)
    {
        HudFixedLayout layout = A_0 as HudFixedLayout;
        if (layout != null)
        {
            int num = this.f();
            this.a.Clear();
            int y = 4;
            for (int i = 0; i < num; i++)
            {
                HudStaticText text = new HudStaticText();
                layout.AddControl(text, new Rectangle(4, y, 0x124, 0x10));
                y += 20;
                text.set_Text(this.a(i));
                HudTextBox item = new HudTextBox();
                layout.AddControl(item, new Rectangle(4, y, 0x124, 0x10));
                y += 20;
                item.set_Text(this.b(i));
                item.add_Change(new EventHandler(this.a));
                this.a.Add(item);
            }
        }
    }

    protected abstract void a(int A_0, string A_1);
    private void a(object A_0, EventArgs A_1)
    {
        for (int i = 0; i < this.a.Count; i++)
        {
            this.a(i, this.a[i].get_Text());
        }
        base.l();
    }

    protected abstract string b(int A_0);
    protected abstract int f();
}

