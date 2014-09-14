using System;
using uTank2;
using uTank2.Logic;

internal class dc : ILogicRule
{
    private int a;

    public dc(int A_0)
    {
        this.a = A_0;
    }

    public void b()
    {
    }

    public string uTank2.Logic.ILogicRule.FriendlyName
    {
        get
        {
            return "FellowshipManager";
        }
    }

    public int uTank2.Logic.ILogicRule.Priority
    {
        get
        {
            return this.a;
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
                PluginCore.cq.aj.f();
            }
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            return PluginCore.cq.aj.h();
        }
    }
}

