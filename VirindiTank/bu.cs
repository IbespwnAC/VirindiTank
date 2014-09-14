using System;
using uTank2;
using uTank2.Logic;

internal class bu : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private string c;
    private string d;
    private string e;
    private bool f;

    public bu(int A_0, string A_1, string A_2, string A_3)
    {
        this.b = A_0;
        this.c = A_1;
        this.d = A_2;
        this.e = A_3;
    }

    public void a()
    {
        if (!this.f)
        {
            this.f = true;
            GC.SuppressFinalize(this);
            this.a = null;
        }
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
            return "RechargeOther";
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
            return false;
        }
        set
        {
            if (value)
            {
                PluginCore.cq.n.a("(RechargeOther) Running", e8.g);
                if (PluginCore.cq.n.a(8, 0, true))
                {
                    x x = new x {
                        a = er.i(this.c),
                        b = er.i(this.d),
                        c = er.i(this.e)
                    };
                    if (x.a > 100f)
                    {
                        x.a = 100f;
                    }
                    if (x.b > 100f)
                    {
                        x.b = 100f;
                    }
                    if (x.c > 100f)
                    {
                        x.c = 100f;
                    }
                    this.a.k.b(x);
                }
            }
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            if (this.a.n.n.b(ActionLockType.ItemUse))
            {
                return false;
            }
            x x = new x {
                a = er.i(this.c),
                b = er.i(this.d),
                c = er.i(this.e)
            };
            return this.a.k.a(x);
        }
    }
}

