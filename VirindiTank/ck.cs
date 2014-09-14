using System;
using System.Collections.Generic;
using uTank2;
using uTank2.Logic;

internal class ck : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private bool c;
    private int d;
    private int e;

    public ck(int A_0)
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
            return "DispelAllies";
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
                PluginCore.cq.n.a("(DispelAllies) Running", e8.g);
                if (PluginCore.cq.n.a(8, this.d, false))
                {
                    PluginCore.cq.z.a(this.d, this.e);
                }
            }
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            if (!er.j("UseDispelDrum"))
            {
                return false;
            }
            if (this.a.n.n.b(ActionLockType.ItemUse))
            {
                return false;
            }
            this.d = 0;
            foreach (int num in PluginCore.PC.c1)
            {
                if (((dh.b(num) && (dh.c(num) == PluginCore.cq.aw.get_CharacterFilter().get_Id())) && ((PluginCore.cq.aw.get_WorldFilter().get_Item(num).get_Name() == "Awakener") || (PluginCore.cq.aw.get_WorldFilter().get_Item(num).get_Name() == "Attenuated Awakener"))) && PluginCore.cq.z.a(num))
                {
                    this.d = num;
                    break;
                }
            }
            if (this.d == 0)
            {
                return false;
            }
            if (PluginCore.cq.aw.get_WorldFilter().get_Item(this.d).get_Name() == "Awakener")
            {
                if (PluginCore.cq.aw.get_CharacterFilter().get_Skills().get_Item(0x1f).get_Training() != 3)
                {
                    return false;
                }
                if (PluginCore.cq.aw.get_CharacterFilter().get_Skills().get_Item(14).get_Buffed() < 110)
                {
                    return false;
                }
            }
            else if (PluginCore.cq.aw.get_WorldFilter().get_Item(this.d).get_Name() == "Attenuated Awakener")
            {
                if ((PluginCore.cq.aw.get_CharacterFilter().get_Skills().get_Item(0x1f).get_Training() != 3) && (PluginCore.cq.aw.get_CharacterFilter().get_Skills().get_Item(0x1f).get_Training() != 2))
                {
                    return false;
                }
                if (PluginCore.cq.aw.get_CharacterFilter().get_Skills().get_Item(14).get_Buffed() < 110)
                {
                    return false;
                }
            }
            int num2 = 0;
            this.e = 0;
            foreach (KeyValuePair<int, eo.b> pair in PluginCore.cq.k.j)
            {
                if ((((pair.Key != PluginCore.cq.aw.get_CharacterFilter().get_Id()) && (PluginCore.cq.i.a(pair.Key, PluginCore.cq.e.b(0xc6b)) <= TimeSpan.Zero)) && (dh.b(pair.Key) && PluginCore.cq.i.b.ContainsKey(pair.Key))) && (dh.a(PluginCore.cq.aw.get_CharacterFilter().get_Id(), pair.Key, true) <= 0.20833333333333334))
                {
                    int num3 = 0;
                    for (int i = 0; i <= 6; i++)
                    {
                        int quality = 0;
                        MySpell spell = PluginCore.cq.h.a((eDamageElement) i, eCombatSpellType.Vuln);
                        if (PluginCore.cq.i.b[pair.Key].ContainsKey(spell.RealFamily))
                        {
                            foreach (KeyValuePair<int, dg.a> pair2 in PluginCore.cq.i.b[pair.Key][spell.RealFamily])
                            {
                                MySpell spell2 = PluginCore.cq.e.b(pair2.Key);
                                if (((spell2.Difficulty <= 350) && !spell2.isUntargetted) && ((pair2.Value.b > DateTimeOffset.Now) && (PluginCore.cq.e.b(pair2.Key).Quality > quality)))
                                {
                                    quality = PluginCore.cq.e.b(pair2.Key).Quality;
                                }
                            }
                            if (quality > 250)
                            {
                                num3 += quality;
                            }
                        }
                    }
                    if (num3 > num2)
                    {
                        num2 = num3;
                        this.e = pair.Key;
                    }
                }
            }
            if (this.e == 0)
            {
                return false;
            }
            return true;
        }
    }
}

