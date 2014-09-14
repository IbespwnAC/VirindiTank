using System;
using System.Collections.Generic;
using uTank2;
using uTank2.Logic;

internal class ee : ILogicRule
{
    private ev a;
    private int b;
    private Dictionary<fz, bool> c;
    private bool d;
    private bool e;
    private MyPair<int, int> f;
    private string g;

    public ee(int A_0)
    {
        this.a = PluginCore.cq;
        this.b = A_0;
    }

    public ee(int A_0, fz[] A_1, bool A_2)
    {
        this.a = PluginCore.cq;
        this.b = A_0;
        this.d = A_2;
        this.c = new Dictionary<fz, bool>();
        foreach (fz fz in A_1)
        {
            this.c[fz] = false;
        }
    }

    public void a()
    {
        if (!this.e)
        {
            this.e = true;
            GC.SuppressFinalize(this);
            this.a = null;
        }
    }

    private int a(fz A_0)
    {
        if (!this.d)
        {
            return 1;
        }
        switch (A_0)
        {
            case fz.a:
                return er.i("IdleCraftCount_HealthKits");

            case fz.b:
                return er.i("IdleCraftCount_HealthFood");

            case fz.c:
                return er.i("IdleCraftCount_StamKits");

            case fz.d:
                return er.i("IdleCraftCount_StamFood");

            case fz.e:
                return er.i("IdleCraftCount_ManaKits");

            case fz.f:
                return er.i("IdleCraftCount_ManaFood");
        }
        return 0;
    }

    protected override void e()
    {
        try
        {
            this.a();
        }
        finally
        {
            base.Finalize();
        }
    }

    public string uTank2.Logic.ILogicRule.FriendlyName
    {
        get
        {
            return "CraftFood";
        }
    }

    public int uTank2.Logic.ILogicRule.Priority
    {
        get
        {
            return this.b;
        }
    }

    public bool uTank2.Logic.ILogicRule.Running
    {
        get
        {
            return (PluginCore.cq.y.c() != dr.b.a);
        }
        set
        {
            if (value)
            {
                PluginCore.cq.n.a("(CraftFood) Running", e8.g);
                if (dh.d() != 1)
                {
                    dh.a(1);
                }
                else
                {
                    PluginCore.cq.y.a(this.f.a, this.f.b, this.g);
                }
            }
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            if (!PluginCore.cq.n.n.b(ActionLockType.ItemUse))
            {
                if (PluginCore.cq.y.c() != dr.b.a)
                {
                    return false;
                }
                if (!er.j("AutoCraftItems"))
                {
                    return false;
                }
                foreach (KeyValuePair<string, fz> pair in PluginCore.cq.l.h)
                {
                    if (((((fz) pair.Value) != fz.h) && (((fz) pair.Value) != fz.j)) && ((this.c == null) || this.c.ContainsKey(pair.Value)))
                    {
                        this.f = PluginCore.cq.y.a(pair.Key, this.a(pair.Value));
                        this.g = pair.Key;
                        if (this.f != null)
                        {
                            return true;
                        }
                    }
                }
                if (this.c == null)
                {
                    foreach (KeyValuePair<string, MySpell> pair2 in PluginCore.cq.l.g)
                    {
                        this.f = PluginCore.cq.y.a(pair2.Key, 1);
                        this.g = pair2.Key;
                        if (this.f != null)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}

