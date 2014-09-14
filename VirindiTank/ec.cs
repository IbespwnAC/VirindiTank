using Decal.Adapter.Wrappers;
using MetaViewWrappers;
using MetaViewWrappers.VirindiViewServiceHudControls;
using MyClasses;
using System;
using System.Runtime.CompilerServices;
using System.Text;
using VirindiViewService;
using VirindiViewService.Controls;

internal class ec : MyDialog<string>
{
    private string[] a;
    private string b;
    private string c;
    private int d;
    private ec.a e;
    private string f;
    private IButton[] g;
    private ITextBox h;
    private IStaticText i;

    public ec(PluginHost A_0, string[] A_1, string A_2, string A_3, int A_4, ec.a A_5, string A_6, string A_7, IView A_8) : base(A_7, A_8)
    {
        this.a = A_1;
        this.b = A_2;
        this.c = A_3;
        this.d = A_4;
        this.e = A_5;
        this.f = A_6;
        if (base.a(A_0))
        {
            this.g = new IButton[this.a.Length];
            for (int i = 0; i < this.a.Length; i++)
            {
                this.g[i] = (IButton) base.a["btn" + i.ToString()];
                this.g[i].Hit += new EventHandler(this.a);
            }
            this.h = (ITextBox) base.a["Textbox1"];
            this.h.Text = this.f;
            this.i = (IStaticText) base.a["Label1"];
            this.i.Text = this.c;
            if (base.a is View)
            {
                this.b();
            }
        }
    }

    protected override string a()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<?xml version=\"1.0\"?>");
        builder.Append(string.Concat(new object[] { "<view icon=\"", this.d, "\" title=\"", this.b, "\" width=\"296\" height=\"116\">" }));
        builder.Append("<control progid=\"DecalControls.FixedLayout\" clipped=\"\">");
        builder.Append("<control progid=\"DecalControls.StaticText\" name=\"Label1\" left=\"18\" top=\"8\" width=\"260\" height=\"16\" text=\"Label1\"/>");
        builder.Append("<control progid=\"DecalControls.Edit\" name=\"Textbox1\" left=\"18\" top=\"24\" width=\"260\" height=\"16\" imageportalsrc=\"4726\" text=\"\"/>");
        for (int i = 0; i < this.a.Length; i++)
        {
            string[] strArray = new string[] { "<control progid=\"DecalControls.PushButton\" name=\"btn", i.ToString(), "\" left=\"", (0xe0 - (i * 0x48)).ToString(), "\" top=\"52\" width=\"64\" height=\"24\" text=\"", this.a[i], "\"/>" };
            builder.Append(string.Concat(strArray));
        }
        builder.Append("</control>");
        builder.Append("</view>");
        return builder.ToString();
    }

    private bool a(int A_0)
    {
        if (this.e == null)
        {
            return true;
        }
        foreach (string str in this.e(this.h.Text))
        {
            if (str == this.a[A_0])
            {
                return true;
            }
        }
        return false;
    }

    private void a(object A_0, EventArgs A_1)
    {
        IButton button = (IButton) A_0;
        int num = int.Parse(button.Name.Substring(3));
        if (this.a(num))
        {
            base.a(button.Text, this.h.Text);
        }
    }

    private void b()
    {
        HudTextBox box = ((View) base.a).Underlying.get_Controls().get_Item("Textbox1");
        HudView.set_FocusControl(box);
    }

    public delegate string[] a(string A_0);
}

