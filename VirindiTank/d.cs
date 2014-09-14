using Decal.Adapter.Wrappers;
using MetaViewWrappers;
using MyClasses;
using System;
using System.Text;

internal class d : MyDialog<bool>
{
    private string[] a;
    private string b;
    private string c;
    private int d;
    private IButton[] e;
    private IStaticText f;

    public d(PluginHost A_0, string[] A_1, string A_2, string A_3, int A_4, string A_5, IView A_6) : base(A_5, A_6)
    {
        this.a = A_1;
        this.b = A_2;
        this.c = A_3;
        this.d = A_4;
        if (base.a(A_0))
        {
            this.e = new IButton[this.a.Length];
            for (int i = 0; i < this.a.Length; i++)
            {
                this.e[i] = (IButton) base.a["btn" + i.ToString()];
                this.e[i].Hit += new EventHandler(this.a);
            }
            this.f = (IStaticText) base.a["Label1"];
            this.f.Text = this.c;
        }
    }

    protected override string a()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append("<?xml version=\"1.0\"?>");
        builder.Append(string.Concat(new object[] { "<view icon=\"", this.d, "\" title=\"", this.b, "\" width=\"296\" height=\"116\">" }));
        builder.Append("<control progid=\"DecalControls.FixedLayout\" clipped=\"\">");
        builder.Append("<control progid=\"DecalControls.StaticText\" name=\"Label1\" left=\"18\" top=\"8\" width=\"260\" height=\"16\" text=\"Label1\"/>");
        for (int i = 0; i < this.a.Length; i++)
        {
            string[] strArray = new string[] { "<control progid=\"DecalControls.PushButton\" name=\"btn", i.ToString(), "\" left=\"", (0xe0 - (i * 0x48)).ToString(), "\" top=\"52\" width=\"64\" height=\"24\" text=\"", this.a[i], "\"/>" };
            builder.Append(string.Concat(strArray));
        }
        builder.Append("</control>");
        builder.Append("</view>");
        return builder.ToString();
    }

    private void a(object A_0, EventArgs A_1)
    {
        IButton button = (IButton) A_0;
        int.Parse(button.Name.Substring(3));
        base.a(button.Text, true);
    }
}

