using System;
using uTank2;
using uTank2.Logic;

internal class co : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private double c;
    private bool d;

    public co(int A_0, double A_1)
    {
        this.b = A_0;
        this.c = A_1;
    }

    public void a()
    {
        if (!this.d)
        {
            this.d = true;
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
            return "OpenCorpse";
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
                PluginCore.cq.n.a("(OpenCorpse) Running", e8.g);
                if (!PluginCore.cq.n.n.b(ActionLockType.ItemUse))
                {
                    this.a.q.a(this.c);
                    this.a.q.d();
                    PluginCore.cq.n.n.a(ActionLockType.ItemUse, TimeSpan.FromSeconds(0.75));
                    PluginCore.cq.n.n.a(ActionLockType.Navigation, TimeSpan.FromSeconds(0.75));
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
            return (PluginCore.cq.n.n.b(ActionLockType.ItemUse) || (this.a.q.a(this.c) && !this.a.q.e()));
        }
    }
}

