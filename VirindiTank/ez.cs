using System;
using uTank2;
using uTank2.Logic;

internal class ez : ILogicRule
{
    private ev a;
    private int b;
    private bool c;

    public ez(int A_0)
    {
        this.b = A_0;
        this.a = PluginCore.cq;
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
            return "IdlePeace";
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
                PluginCore.cq.n.a("(IdlePeace) Running", e8.g);
                dh.a(1);
            }
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            if (!er.j("IdlePeaceMode"))
            {
                return false;
            }
            return (this.a.ax.get_Actions().get_CombatMode() != 1);
        }
    }
}

