using System;
using uTank2;
using uTank2.Logic;

internal class de : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private bool c;

    public de(int A_0)
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
            return "CorpseWait";
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
                PluginCore.cq.n.a("(CorpseWait) Running", e8.g);
                if (this.f() && this.a.r.d())
                {
                    this.a.q.c();
                }
            }
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            if (!er.j("EnableLooting"))
            {
                return false;
            }
            if (PluginCore.cq.n.n.b(ActionLockType.ItemUse))
            {
                return false;
            }
            return this.a.q.e();
        }
    }
}

