using System;
using uTank2;
using uTank2.Logic;

internal class bg : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private string c;
    private bool d;
    private bool e;
    private bool f;

    public bg(int A_0, string A_1, bool A_2)
    {
        this.b = A_0;
        this.c = A_1;
        this.d = A_2;
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
            return "BuffSelf";
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
                PluginCore.cq.n.a("(BuffSelf) Running", e8.g);
                if (this.e || PluginCore.cq.n.a(8, 0, true))
                {
                    this.a.n.n.a(ActionLockType.BuffCastRecast, TimeSpan.FromSeconds((double) er.i("BuffCastRecastReset_Seconds")));
                    this.a.j.f();
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
            if (!er.j("EnableBuffing"))
            {
                return false;
            }
            int num = er.i(this.c);
            if (this.a.n.n.b(ActionLockType.BuffCastRecast))
            {
                num += er.i("BuffCastRecast_Seconds");
            }
            if (num < 10)
            {
                num = 10;
            }
            return this.a.j.a(num, this.d, out this.e);
        }
    }
}

