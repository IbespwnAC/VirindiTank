using System;
using uTank2;

internal class c
{
    public cv a = new cv();
    public int b = 0;
    public string c = "";
    public int d = -1;
    public double e = 999999.0;
    public double f = double.MaxValue;
    public int g = 0;
    public bool h = false;
    public bool i = false;
    public bool j = false;
    public bool k = false;
    public bool l = true;
    public bool m = false;
    private MyQuad<int, eDamageElement, ePrismaticDamageBehavior, int> n;

    public MyQuad<int, eDamageElement, ePrismaticDamageBehavior, int> a()
    {
        if (this.n == null)
        {
            this.n = PluginCore.cq.n.d(this.a);
        }
        return this.n;
    }

    public eFillDiagnosticPoint a(cv A_0, double A_1, double A_2, bool A_3)
    {
        ev cq = PluginCore.cq;
        this.a = A_0;
        this.b = A_0.k;
        this.c = A_0.g();
        if (!cq.n.f.ContainsKey(this.b))
        {
            this.m = false;
            return eFillDiagnosticPoint.CreatureInfoMissing;
        }
        cf cf = cq.n.f[this.b];
        if (cf.a())
        {
            this.m = false;
            return eFillDiagnosticPoint.CIInvalid;
        }
        this.d = cq.d.a(A_0).a;
        if (this.d < 0)
        {
            this.m = false;
            return eFillDiagnosticPoint.NegativePriority;
        }
        this.e = dh.a(this.b, PluginCore.cq.aw.get_CharacterFilter().get_Id(), true);
        if (this.e > A_1)
        {
            this.m = false;
            return eFillDiagnosticPoint.DistanceTooFar;
        }
        if (this.e < A_2)
        {
            this.m = false;
            return eFillDiagnosticPoint.DistanceTooNear;
        }
        this.h = PluginCore.cq.o.b(this.b, this);
        if (!PluginCore.cq.o.a(this.b, this.h))
        {
            this.m = false;
            return eFillDiagnosticPoint.DebuffPassWithNoAttack;
        }
        this.f = dh.b(cq.ax.get_Actions().get_Heading(), dh.b(dh.a(cq.aw.get_CharacterFilter().get_Id(), cq.ax.get_Actions()), dh.a(this.b, PluginCore.cq.ax.get_Actions())));
        this.g = PluginCore.cq.o.a(this.b, this);
        this.k = this.b == PluginCore.cq.n.d;
        this.j = this.b == PluginCore.cq.n.c;
        this.i = (this.b == PluginCore.cq.ax.get_Actions().get_CurrentSelection()) && A_3;
        this.l = PluginCore.cq.n.e.Contains(this.b);
        this.m = true;
        return eFillDiagnosticPoint.AttackValid;
    }

    public aj.c b()
    {
        return PluginCore.cq.d.a(this.a);
    }

    public enum eFillDiagnosticPoint
    {
        CreatureInfoMissing,
        CIInvalid,
        NegativePriority,
        DistanceTooFar,
        DistanceTooNear,
        DebuffPassWithNoAttack,
        AttackValid
    }
}

