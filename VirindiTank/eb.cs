using System;
using uTank2;
using uTank2.Logic;

internal class eb : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private bool c;

    public eb(int A_0)
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
            return "DispelSelf";
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
                PluginCore.cq.n.a("(DispelSelf) Running", e8.g);
                if (PluginCore.cq.n.a(8, 0, true))
                {
                    MySpell spell = this.a.h.a(this.a.e.a("Eradicate Life Magic Self"));
                    if (this.a.aw.get_CharacterFilter().get_SpellBook().Contains(spell.Id))
                    {
                        this.a.g.a(spell, this.a.aw.get_CharacterFilter().get_Id());
                    }
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
            if (!er.j("CastDispelSelf"))
            {
                return false;
            }
            if (this.a.p.d("Chorizite") == 0)
            {
                return false;
            }
            MySpell spell = this.a.h.a(this.a.e.a("Eradicate Life Magic Self"));
            if (spell == null)
            {
                return false;
            }
            return d2.a(spell.Difficulty);
        }
    }
}

