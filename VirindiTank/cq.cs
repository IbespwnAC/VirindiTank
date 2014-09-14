using System;
using uTank2;
using uTank2.Logic;

internal class cq : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private bool c;
    private bool d;

    public cq(int A_0)
    {
        this.b = A_0;
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
            return "Attack";
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
            return true;
        }
        set
        {
            if (value)
            {
                if ((!this.a.g.e() && !this.a.z.d()) && this.c)
                {
                    PluginCore.cq.n.a("(Attack) Running", e8.g);
                    this.a.o.b();
                }
            }
            else
            {
                this.a.aq.b();
                this.a.v.d();
                if (this.a.n.c != 0)
                {
                    this.a.n.c = 0;
                    PluginCore.PC.e(0);
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
            if (!er.j("EnableCombat"))
            {
                return false;
            }
            this.c = this.a.o.c();
            l.a(this.c);
            return this.c;
        }
    }
}

