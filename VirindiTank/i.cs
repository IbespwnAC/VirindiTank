using System;
using System.Globalization;
using System.IO;
using uTank2;

internal class i : eq
{
    private int a;
    private DateTimeOffset b;

    public i(sCoord A_0) : base(PluginCore.cq)
    {
        this.b = DateTimeOffset.MinValue;
    }

    public i(sCoord A_0, int A_1) : base(PluginCore.cq)
    {
        this.b = DateTimeOffset.MinValue;
        this.a = A_1;
    }

    public override void a(TextReader A_0)
    {
        this.a = Convert.ToInt32(A_0.ReadLine(), CultureInfo.InvariantCulture);
    }

    public override void a(TextWriter A_0)
    {
        A_0.WriteLine(Convert.ToString(this.a, CultureInfo.InvariantCulture));
    }

    protected override bool e()
    {
        return (this.b > DateTimeOffset.Now);
    }

    protected override void f()
    {
        this.b = DateTimeOffset.Now + TimeSpan.FromMilliseconds((double) this.a);
    }

    public override string g()
    {
        double num = ((double) this.a) / 1000.0;
        return ("Pause: " + num.ToString() + " seconds");
    }

    public override bool h()
    {
        return false;
    }

    public override eWaypointType i()
    {
        return eWaypointType.Pause;
    }

    public override int j()
    {
        return this.a;
    }
}

