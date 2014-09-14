using System;
using uTank2;
using uTank2.Logic;

internal class bn : ILogicRule
{
    private int a;
    private int b;
    private string c;
    private int d;

    public bn(int A_0, string A_1)
    {
        this.d = A_0;
        this.c = A_1;
    }

    public void b()
    {
    }

    public string uTank2.Logic.ILogicRule.FriendlyName
    {
        get
        {
            return "RefillPetCharges";
        }
    }

    public int uTank2.Logic.ILogicRule.Priority
    {
        get
        {
            return this.d;
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
                PluginCore.cq.n.a("(RefillPetCharges) Running", e8.g);
                if (dh.d() != 1)
                {
                    dh.a(1);
                }
                else
                {
                    int num = PluginCore.cq.ax.get_Actions().get_CurrentSelection();
                    PluginCore.cq.ax.get_Actions().SelectItem(this.a);
                    PluginCore.cq.ax.get_Actions().UseItem(this.b, 1);
                    PluginCore.cq.ax.get_Actions().SelectItem(num);
                }
            }
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            if (PluginCore.cq.n.n.b(ActionLockType.ItemUse))
            {
                return false;
            }
            if (!er.j("EnableCombat"))
            {
                return false;
            }
            int num = er.i(this.c);
            this.a = 0;
            foreach (int num2 in PluginCore.PC.c1)
            {
                if (dh.b(num2) && (dh.c(num2) == PluginCore.cq.aw.get_CharacterFilter().get_Id()))
                {
                    cv cv = PluginCore.cq.p.d(num2);
                    if ((cv != null) && fn.e(PluginCore.cq.aw.get_WorldFilter().get_Item(num2)))
                    {
                        int num3 = cv.a(dt.aa, 0x1869f);
                        if ((num3 <= num) && (num3 < cv.a(dt.z, 0)))
                        {
                            this.a = num2;
                            break;
                        }
                    }
                }
            }
            if (this.a == 0)
            {
                return false;
            }
            this.b = dh.b("Encapsulated Spirit");
            if (this.b == 0)
            {
                this.a = 0;
                return false;
            }
            return true;
        }
    }
}

