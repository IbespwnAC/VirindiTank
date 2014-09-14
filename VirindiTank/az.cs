using System;
using uTank2;
using uTank2.Logic;

internal class az : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private string c;
    private string d;
    private string e;
    private bool f;
    private bool g;

    public az(int A_0, string A_1, string A_2, string A_3)
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
            return "RechargeSelf2";
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
                PluginCore.cq.n.a("(RechargeSelf2) Running (errorstate " + this.g.ToString() + ")", e8.g);
                if (!this.g)
                {
                    if (ao.c(this.c))
                    {
                        PluginCore.cq.ak.Recharge(eRechargeVital_Single.Health);
                    }
                    else if (ao.b(this.d))
                    {
                        PluginCore.cq.ak.Recharge(eRechargeVital_Single.Stamina);
                    }
                    else
                    {
                        PluginCore.cq.ak.Recharge(eRechargeVital_Single.Mana);
                    }
                }
            }
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            this.g = false;
            if (!this.a.n.n.b(ActionLockType.ItemUse))
            {
                try
                {
                    if ((ao.c(this.c) || ao.b(this.d)) || ao.a(this.e))
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    this.g = true;
                    return true;
                }
            }
            return false;
        }
    }
}

