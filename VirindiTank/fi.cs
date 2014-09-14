using System;
using uTank2;
using uTank2.Logic;

internal class fi : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private string c;
    private string d;
    private string e;
    private bool f;
    private bool g;

    public fi(int A_0, string A_1, string A_2, string A_3)
    {
        this.b = A_0;
        this.c = A_1;
        this.d = A_2;
        this.e = A_3;
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
            return "RechargeSelf";
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
                PluginCore.cq.n.a("(RechargeSelf) Running (errorstate " + this.g.ToString() + ")", e8.g);
                if (!this.g)
                {
                    switch (PluginCore.cq.ax.get_Actions().get_CombatMode())
                    {
                        case 1:
                        case 2:
                        case 4:
                            if (!ao.c(this.c))
                            {
                                if (ao.b(this.d))
                                {
                                    if (!PluginCore.cq.n.a(4) && !PluginCore.cq.n.a(8, 0, true))
                                    {
                                        this.a.n.n.a(ActionLockType.RechargeLevelBoost_Stam, TimeSpan.FromSeconds(er.h("RechargeBoostTimeSeconds")));
                                        return;
                                    }
                                }
                                else if ((ao.a(this.e) && !PluginCore.cq.n.a(6)) && !PluginCore.cq.n.a(8, 0, true))
                                {
                                    this.a.n.n.a(ActionLockType.RechargeLevelBoost_Mana, TimeSpan.FromSeconds(er.h("RechargeBoostTimeSeconds")));
                                }
                                return;
                            }
                            if (!PluginCore.cq.n.a(2) && !PluginCore.cq.n.a(8, 0, true))
                            {
                                this.a.n.n.a(ActionLockType.RechargeLevelBoost_HP, TimeSpan.FromSeconds(er.h("RechargeBoostTimeSeconds")));
                            }
                            return;

                        case 3:
                            return;

                        case 8:
                        {
                            MySpell spell = this.a.h.b("Adja's Intervention");
                            if (!ao.c(this.c) || (spell == null))
                            {
                                spell = this.a.h.b("Robustification");
                                if (ao.b(this.d) && (spell != null))
                                {
                                    this.a.g.a(spell, this.a.aw.get_CharacterFilter().get_Id());
                                    if (er.j("ClearLevelBoostFlagOnCast"))
                                    {
                                        this.a.n.n.a(ActionLockType.RechargeLevelBoost_Stam);
                                    }
                                    return;
                                }
                                spell = this.a.h.b("Meditative Trance");
                                if (ao.a(this.e) && (spell != null))
                                {
                                    this.a.g.a(spell, this.a.aw.get_CharacterFilter().get_Id());
                                    if (er.j("ClearLevelBoostFlagOnCast"))
                                    {
                                        this.a.n.n.a(ActionLockType.RechargeLevelBoost_Mana);
                                    }
                                }
                                return;
                            }
                            this.a.g.a(spell, this.a.aw.get_CharacterFilter().get_Id());
                            if (er.j("ClearLevelBoostFlagOnCast"))
                            {
                                this.a.n.n.a(ActionLockType.RechargeLevelBoost_HP);
                            }
                            return;
                        }
                    }
                }
            }
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            this.g = false;
            if (!this.a.n.n.b(ActionLockType.ItemUse))
            {
                try
                {
                    if ((ao.c(this.c) || ao.b(this.d)) || ao.a(this.e))
                    {
                        return true;
                    }
                }
                catch (Exception)
                {
                    this.g = true;
                    return true;
                }
            }
            return false;
        }
    }
}

