using System;
using uTank2;

internal class dn : IRechargeHandler
{
    public string a(eRechargeVital_Single A_0)
    {
        switch (A_0)
        {
            case eRechargeVital_Single.Health:
                return "Heal Self";

            case eRechargeVital_Single.Stamina:
                return "Revitalize Self";

            case eRechargeVital_Single.Mana:
                return "Stamina to Mana";
        }
        return "Regular Spell ???";
    }

    public bool b(eRechargeVital_Single A_0)
    {
        string str = "";
        switch (A_0)
        {
            case eRechargeVital_Single.Health:
                str = "Adja's Intervention";
                break;

            case eRechargeVital_Single.Stamina:
                str = "Robustification";
                break;

            case eRechargeVital_Single.Mana:
                str = "Meditative Trance";
                break;
        }
        MySpell spell = PluginCore.cq.e.a(str);
        MySpell spell2 = PluginCore.cq.h.b(str);
        MySpell spell3 = null;
        int num = 0;
        a8.a(spell, out spell3, out num);
        if ((spell3 != null) && ((spell2 == null) || (spell2.Quality < spell3.Quality)))
        {
            a8.a(A_0, num);
            return true;
        }
        if (spell2 == null)
        {
            return false;
        }
        a8.a(A_0, spell2);
        return true;
    }

    public string uTank2.IRechargeHandler.FriendlyName
    {
        get
        {
            return "Regular Spell";
        }
    }

    public eRechargeVital_Multiple uTank2.IRechargeHandler.ValidVitals
    {
        get
        {
            return (eRechargeVital_Multiple.Mana | eRechargeVital_Multiple.Stamina | eRechargeVital_Multiple.Health);
        }
    }
}

