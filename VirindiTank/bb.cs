using System;
using uTank2;
using uTank2.Logic;

internal class bb : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private bool c;

    public bb(int A_0)
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
            return "ReadScroll";
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
                PluginCore.cq.n.a("(ReadScroll) Running", e8.g);
                if (this.f())
                {
                    int num = 0;
                    for (int i = 0; i < this.a.n.h.Keys.Count; i++)
                    {
                        int num3 = this.a.n.h[this.a.n.h.Keys[i]];
                        if (PluginCore.cq.p.b(num3, PluginCore.cq.ax) && this.a.r.a(num3, false))
                        {
                            num = num3;
                            break;
                        }
                    }
                    if (num != 0)
                    {
                        this.a.ax.get_Actions().UseItem(num, 0);
                        this.a.n.n.a(ActionLockType.ItemUse, this.a.n.j);
                    }
                }
            }
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            if (!this.a.n.n.b(ActionLockType.ItemUse))
            {
                MyList<int> list = new MyList<int>(0x30);
                for (int i = 0; i < this.a.n.h.Keys.Count; i++)
                {
                    if (this.a.aw.get_CharacterFilter().IsSpellKnown(this.a.n.h.Keys[i]))
                    {
                        list.Add(this.a.n.h.Keys[i]);
                    }
                }
                for (int j = 0; j < list.Count; j++)
                {
                    this.a.n.h.Remove(list[j]);
                }
                if (this.a.n.h.Count > 0)
                {
                    for (int k = 0; k < this.a.n.h.Keys.Count; k++)
                    {
                        int num4 = this.a.n.h[this.a.n.h.Keys[k]];
                        if (PluginCore.cq.p.b(num4, PluginCore.cq.ax) && this.a.r.a(num4, false))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}

