using System;
using System.IO;
using uTank2;

internal class n : eq
{
    public string a;
    private DateTimeOffset b;

    public n(sCoord A_0) : base(PluginCore.cq)
    {
        this.a = "";
        this.b = DateTimeOffset.MinValue;
    }

    public n(sCoord A_0, string A_1) : base(PluginCore.cq)
    {
        this.a = "";
        this.b = DateTimeOffset.MinValue;
        this.a = A_1;
    }

    public override void a(TextReader A_0)
    {
        this.a = A_0.ReadLine();
    }

    public override void a(TextWriter A_0)
    {
        A_0.WriteLine(this.a);
    }

    protected override bool e()
    {
        if ((this.b <= DateTimeOffset.Now) && (PluginCore.cq.ax.get_Actions().get_BusyState() == 0))
        {
            PluginCore.e("Executing chat command \"" + this.a + "\"");
            dh.h(this.a);
            return false;
        }
        return true;
    }

    protected override void f()
    {
        this.b = DateTimeOffset.Now + TimeSpan.FromMilliseconds(200.0);
    }

    public override string g()
    {
        return ("Chat command: " + this.a);
    }

    public override bool h()
    {
        return false;
    }

    public override eWaypointType i()
    {
        return eWaypointType.ChatCommand;
    }

    public override int j()
    {
        return 0;
    }
}

