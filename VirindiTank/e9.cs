using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using uTank2;
using VirindiViewService.Controls;

internal class e9 : ew, b3
{
    private string a = "";
    private string b = "";
    private int c;
    private HudStaticText d;

    public bool a()
    {
        PluginCore.cq.l.n = "";
        if (!string.IsNullOrEmpty(this.b))
        {
            using (StringReader reader = new StringReader(this.b))
            {
                PluginCore.cq.l.k.a(reader);
                PluginCore.cq.n.c();
                goto Label_0072;
            }
        }
        PluginCore.cq.l.k.b();
    Label_0072:
        PluginCore.cq.ay.ak();
        PluginCore.cq.ay.l();
        return true;
    }

    public override void a(k A_0)
    {
        this.a = "";
        this.b = "";
        this.c = 0;
        fa fa = A_0.c() as fa;
        if (fa != null)
        {
            using (StringReader reader = new StringReader(fa.a))
            {
                this.a = reader.ReadLine();
                this.c = Convert.ToInt32(reader.ReadLine(), CultureInfo.InvariantCulture);
                this.b = reader.ReadToEnd();
            }
        }
    }

    public override void a(object A_0)
    {
        HudFixedLayout layout = A_0 as HudFixedLayout;
        if (layout != null)
        {
            this.d = new HudStaticText();
            layout.AddControl(this.d, new Rectangle(4, 4, 0x124, 0x10));
            this.d.set_Text(this.k());
            HudButton button = new HudButton();
            layout.AddControl(button, new Rectangle(4, 0x18, 200, 0x10));
            button.set_Text("Import From Current");
            button.add_Hit(new EventHandler(this.a));
            HudButton button2 = new HudButton();
            layout.AddControl(button2, new Rectangle(4, 0x2c, 200, 0x10));
            button2.set_Text("Export To Current");
            button2.add_Hit(new EventHandler(this.b));
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        if (string.IsNullOrEmpty(PluginCore.cq.l.n))
        {
            this.a = "[None]";
        }
        else
        {
            this.a = PluginCore.cq.l.n;
        }
        this.c = PluginCore.cq.l.k.c();
        using (StringWriter writer = new StringWriter())
        {
            PluginCore.cq.l.k.a(writer);
            this.b = writer.ToString();
        }
        this.d.set_Text(this.k());
        base.l();
    }

    public override k b()
    {
        using (StringWriter writer = new StringWriter())
        {
            writer.WriteLine(this.a);
            writer.WriteLine(Convert.ToString(this.c, CultureInfo.InvariantCulture));
            writer.Write(this.b);
            return new k(new fa { a = writer.ToString() });
        }
    }

    private void b(object A_0, EventArgs A_1)
    {
        this.a();
    }

    public ep c()
    {
        return ep.e;
    }

    public override string d()
    {
        return ("Embedded Nav \"" + this.a + "\" (" + this.c.ToString() + "pts)");
    }

    public override string e()
    {
        return "Load Embedded Nav Route";
    }
}

