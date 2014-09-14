using System;
using uTank2;
using uTank2.Logic;

internal class em : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private bool c;

    public em(int A_0)
    {
        this.b = A_0;
    }

    public void a()
    {
        if (!this.c)
        {
            this.c = true;
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
            return "RefillWieldedMana";
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
                PluginCore.cq.n.a("(RefillWieldedMana) Running", e8.g);
                if (PluginCore.cq.ab.g())
                {
                    PluginCore.cq.ab.d();
                }
                else if (!this.a.n.n.b(ActionLockType.ManaStoneUse))
                {
                    PluginCore.cq.aa.c();
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
            PluginCore.cq.ab.e();
            if (PluginCore.cq.ab.g())
            {
                return true;
            }
            if (this.a.n.n.b(ActionLockType.ManaStoneUse))
            {
                return false;
            }
            return PluginCore.cq.aa.e();
        }
    }
}

