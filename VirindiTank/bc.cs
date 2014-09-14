using System;
using uTank2;

internal abstract class bc : IRechargeHandler
{
    protected bc()
    {
    }

    protected abstract string a();
    public string a(eRechargeVital_Single A_0)
    {
        return this.d();
    }

    protected abstract eRechargeVital_Single b();
    public bool b(eRechargeVital_Single A_0)
    {
        if (A_0 != this.b())
        {
            return false;
        }
        if (this.b() != eRechargeVital_Single.Health)
        {
            switch (this.c())
            {
                case eRechargeVital_Single.Health:
                    if (!ao.c("Recharge-Norm-HitP"))
                    {
                        break;
                    }
                    return false;

                case eRechargeVital_Single.Stamina:
                    if (!ao.b("Recharge-Norm-Stam"))
                    {
                        break;
                    }
                    return false;

                case eRechargeVital_Single.Mana:
                    if (!ao.a("Recharge-Norm-Mana"))
                    {
                        break;
                    }
                    return false;
            }
        }
        MySpell spell = PluginCore.cq.h.b(this.a());
        MySpell spell2 = PluginCore.cq.e.a(this.a());
        MySpell spell3 = null;
        int num = 0;
        bool flag = false;
        a8.a(spell2, out spell3, out num);
        if ((spell3 != null) && ((spell == null) || (spell.Quality < spell3.Quality)))
        {
            flag = true;
            spell = spell3;
        }
        if (spell == null)
        {
            return false;
        }
        if (this.b() == eRechargeVital_Single.Health)
        {
            double num2 = 1.0;
            if (this.c() == eRechargeVital_Single.Stamina)
            {
                num2 = er.h("StaminaToHealthMultiplier");
            }
            if (this.c() == eRechargeVital_Single.Mana)
            {
                num2 = er.h("ManaToHealthMultiplier");
            }
            int num3 = a8.a();
            int num4 = a8.a(spell, this.c());
            int num5 = PluginCore.cq.ax.get_Actions().get_Vital().get_Item(1) - PluginCore.cq.ax.get_Actions().get_Vital().get_Item(2);
            if (num3 > num5)
            {
                return false;
            }
            if (num4 > num5)
            {
                num4 = num5;
            }
            if ((num3 * num2) >= num5)
            {
                return false;
            }
            if ((num3 * num2) >= num4)
            {
                return false;
            }
        }
        if (flag)
        {
            a8.a(A_0, num);
        }
        else
        {
            a8.a(A_0, spell);
        }
        return true;
    }

    protected abstract eRechargeVital_Single c();
    protected abstract string d();

    public string uTank2.IRechargeHandler.FriendlyName
    {
        get
        {
            return this.d();
        }
    }

    public eRechargeVital_Multiple uTank2.IRechargeHandler.ValidVitals
    {
        get
        {
            return cRechargeManager.eRechargeVital_SingleToMultiple(this.b());
        }
    }
}

