using System;
using uTank2;
using uTank2.Logic;

internal class d4 : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private string c;
    private bool d;
    private int e;
    private int f;

    public d4(int A_0, string A_1)
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
            return "UseHealersHeart";
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
                PluginCore.cq.n.a("(UseHealersHeart) Running", e8.g);
                if (PluginCore.cq.n.a(8, this.e, false))
                {
                    PluginCore.cq.z.a(this.e, this.f);
                    PluginCore.cq.k.a(this.f, 2);
                }
            }
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            if (!er.j("UseHealersHeart"))
            {
                return false;
            }
            if (this.a.n.n.b(ActionLockType.ItemUse))
            {
                return false;
            }
            this.e = 0;
            int num = 0;
            foreach (int num2 in PluginCore.PC.c1)
            {
                if (dh.b(num2) && (dh.c(num2) == PluginCore.cq.aw.get_CharacterFilter().get_Id()))
                {
                    if (((PluginCore.cq.aw.get_WorldFilter().get_Item(num2).get_Name() == "The Healer's Heart") && PluginCore.cq.z.a(num2)) && (num < 1))
                    {
                        this.e = num2;
                        num = 1;
                    }
                    if (((PluginCore.cq.aw.get_WorldFilter().get_Item(num2).get_Name() == "Legendary Seed of Mornings") && PluginCore.cq.z.a(num2)) && (num < 2))
                    {
                        this.e = num2;
                        num = 2;
                    }
                }
            }
            if (this.e == 0)
            {
                return false;
            }
            if (PluginCore.cq.aw.get_CharacterFilter().get_Skills().get_Item(0x21).get_Buffed() < 0xf5)
            {
                return false;
            }
            if (PluginCore.cq.aw.get_CharacterFilter().get_Skills().get_Item(14).get_Buffed() < 0x69)
            {
                return false;
            }
            this.f = PluginCore.cq.k.a((float) er.i(this.c));
            if (this.f == 0)
            {
                return false;
            }
            return true;
        }
    }
}

