using System;
using uTank2;
using uTank2.Logic;

internal class fp : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private bool c;

    public fp(int A_0)
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
            return "SalvageItems";
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
                PluginCore.cq.n.a("(SalvageItems) Running", e8.g);
                if (this.f() && !PluginCore.cq.n.n.b(ActionLockType.Salvage))
                {
                    this.a.ax.get_Actions().UseItem(dh.e("Ust"), 0);
                    this.a.t.h();
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
            if (PluginCore.cq.n.n.b(ActionLockType.Salvage))
            {
                return true;
            }
            if (dh.e("Ust") == 0)
            {
                ai.a("Warning: No ust found in inventory. Cannot salvage.");
                return false;
            }
            if (this.a.q.e())
            {
                return false;
            }
            return this.a.t.j();
        }
    }
}

