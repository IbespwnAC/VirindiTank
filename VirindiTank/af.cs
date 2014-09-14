using MyClasses.MyWorldFilter;
using System;
using System.Globalization;
using System.IO;
using uTank2;

internal class af : eq
{
    private int a;
    private string b;
    private DateTimeOffset c;

    public af(sCoord A_0) : base(PluginCore.cq)
    {
        this.b = "";
        this.c = DateTimeOffset.MinValue;
    }

    public af(sCoord A_0, int A_1, string A_2) : base(PluginCore.cq)
    {
        this.b = "";
        this.c = DateTimeOffset.MinValue;
        this.a = A_1;
        this.b = A_2;
    }

    public override void a(TextReader A_0)
    {
        this.a = Convert.ToInt32(A_0.ReadLine(), CultureInfo.InvariantCulture);
        this.b = A_0.ReadLine();
    }

    public override void a(TextWriter A_0)
    {
        A_0.WriteLine(Convert.ToString(this.a, CultureInfo.InvariantCulture));
        A_0.WriteLine(this.b);
    }

    protected override bool e()
    {
        if (PluginCore.cq.ax.get_Actions().get_VendorId() == this.a)
        {
            return true;
        }
        cv cv = PluginCore.cq.p.d(this.a);
        if (cv == null)
        {
            ai.a("OpenVendor waypoint action ignored, vendor " + this.a.ToString() + " (" + this.b + ") not found.");
            return true;
        }
        if (cv.c() != ObjectClass.Vendor)
        {
            ai.a("OpenVendor waypoint action ignored, vendor " + this.a.ToString() + " (" + this.b + ") is not a vendor.");
            return true;
        }
        TimeSpan span = (TimeSpan) (DateTimeOffset.Now - this.c);
        if (span.TotalSeconds > 2.0)
        {
            this.c = DateTimeOffset.Now;
            PluginCore.cq.ax.get_Actions().UseItem(this.a, 0);
        }
        return false;
    }

    protected override void f()
    {
        this.c = DateTimeOffset.MinValue;
    }

    public override string g()
    {
        if (this.a == 0)
        {
            return "Close Vendor";
        }
        return ("Open Vendor: " + this.b);
    }

    public override bool h()
    {
        return false;
    }

    public override eWaypointType i()
    {
        return eWaypointType.OpenVendor;
    }

    public override int j()
    {
        return this.a;
    }
}

