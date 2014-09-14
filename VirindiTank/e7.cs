using System;
using uTank2;
using uTank2.Logic;

internal class e7 : ILogicRule
{
    private int a;
    private int b;

    public e7(int A_0)
    {
        this.b = A_0;
    }

    public void b()
    {
    }

    public string uTank2.Logic.ILogicRule.FriendlyName
    {
        get
        {
            return "SummonPet";
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
                PluginCore.cq.ax.get_Actions().UseItem(this.a, 0);
            }
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            if (!er.j("EnableCombat"))
            {
                return false;
            }
            if (!er.j("SummonPets"))
            {
                return false;
            }
            if (!dh.b(eGameSkillID.Summoning))
            {
                return false;
            }
            if (cx.a(-32555))
            {
                return false;
            }
            this.a = PluginCore.cq.n.d();
            if (this.a == 0)
            {
                return false;
            }
            return true;
        }
    }
}

