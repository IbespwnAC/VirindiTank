using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using uTank2;
using VirindiViewService.Controls;

internal class ct : fl
{
    private Regex a = new Regex("");
    private HudTextBox b;
    private b1 c;

    private void a()
    {
        this.a = new Regex(this.b.get_Text(), RegexOptions.Compiled);
        PluginCore.cq.@as.d();
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
        this.a = new Regex(k.b(A_0), RegexOptions.Compiled);
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
            this.b.add_LostFocus(new EventHandler(this.b));
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        try
        {
            this.a();
        }
        catch
        {
        }
    }

    public void b()
    {
        if (this.c != null)
        {
            this.c.c();
        }
    }

    private void b(object A_0, EventArgs A_1)
    {
        try
        {
            this.a();
        }
        catch
        {
            a5.a(eChatType.Warnings, "Warning: Invalid regex specified in Meta condition. This condition won't do anything until the regex is fixed!");
        }
    }

    public k c()
    {
        return k.a(this.a.ToString());
    }

    public List<string> d()
    {
        return null;
    }

    public c3 e()
    {
        return c3.e;
    }

    public b1 f()
    {
        return this.c;
    }

    public bool h()
    {
        foreach (a2.a a in a2.a())
        {
            if (this.a.IsMatch(a.a))
            {
                return true;
            }
        }
        return false;
    }

    public string j()
    {
        return ("Chat: \"" + this.a.ToString() + "\"");
    }

    public string l()
    {
        return "Chat Message";
    }
}

