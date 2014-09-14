using System;
using System.Globalization;
using uTank2;
using uTank2.Logic;

internal class aw : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private ft c;
    private bool d;

    public aw(int A_0, string A_1, string A_2, ef A_3)
    {
        this.b = A_0;
        this.c = new ft(PluginCore.cq, A_1, A_2);
        this.c.a(A_3);
    }

    public ft a()
    {
        return this.c;
    }

    public void b()
    {
        if (!this.d)
        {
            this.d = true;
            GC.SuppressFinalize(this);
            this.c.m();
            this.a = null;
            this.c = null;
        }
    }

    protected override void f()
    {
        try
        {
            this.b();
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
            return "Navigate";
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
            return this.c.n();
        }
        set
        {
            try
            {
                if (value)
                {
                    PluginCore.cq.n.a("(Navigate) Running [targ range " + this.c.h().f().ToString(CultureInfo.CurrentCulture) + ", targ loc " + this.c.h().e().ToString() + " ]", e8.g);
                }
            }
            catch
            {
            }
            this.c.c(value);
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            if (this.a.u.c(b0.a.c) && er.j("EnableLooting"))
            {
                return false;
            }
            if (!er.j("EnableNav"))
            {
                return false;
            }
            if (PluginCore.cq.n.n.b(ActionLockType.Navigation))
            {
                return false;
            }
            if (PluginCore.cq.n.n.b(ActionLockType.SpreadLockTargetRequested))
            {
                return false;
            }
            if (PluginCore.cq.n.n.b(ActionLockType.DoorOpening))
            {
                return false;
            }
            return this.c.e();
        }
    }

    public enum a
    {
        a,
        b,
        c
    }
}

