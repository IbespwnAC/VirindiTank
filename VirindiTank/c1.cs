using System;
using uTank2;
using uTank2.Logic;

internal class c1 : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private bool c;

    public c1(int A_0)
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
            return "StackCram";
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
                PluginCore.cq.n.a("(StackCram) Running", e8.g);
                PluginCore.cq.w.c();
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
            return PluginCore.cq.w.d();
        }
    }
}

