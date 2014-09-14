using System;
using uTank2;
using uTank2.Logic;

internal class fy : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private bool c;
    private int d;

    public fy(int A_0)
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
            return "UseDispelItem";
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
                PluginCore.cq.n.a("(UseDispelItem) Running", e8.g);
                this.a.ax.get_Actions().UseItem(this.d, 0);
                this.a.n.n.a(ActionLockType.ItemUse, this.a.n.j);
            }
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            this.d = 0;
            if (er.j("UseDispelItems"))
            {
                if (this.a.n.n.b(ActionLockType.ItemUse))
                {
                    return false;
                }
                if (d2.a(400))
                {
                    this.d = dh.e("Rune of Dispel");
                    if (this.d != 0)
                    {
                        return true;
                    }
                    this.d = dh.e("Black Market Gem of Dispelling");
                    if (this.d != 0)
                    {
                        return true;
                    }
                }
                if (d2.a(350))
                {
                    this.d = dh.e("Chocolate Gromnie");
                    if (this.d != 0)
                    {
                        return true;
                    }
                    this.d = dh.e("Condensed Dispel Potion");
                    if (this.d != 0)
                    {
                        return true;
                    }
                    this.d = dh.e("Gem of Stillness");
                    if (this.d != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

