using System;
using System.Collections.Generic;
using uTank2;

internal static class d2
{
    public static bool a(int A_0)
    {
        ev cq = PluginCore.cq;
        using (IEnumerator<KeyValuePair<int, ActiveSpellInfo>> enumerator = PluginCore.cq.a.d())
        {
            while (enumerator.MoveNext())
            {
                KeyValuePair<int, ActiveSpellInfo> current = enumerator.Current;
                if ((!current.Value.IsCoolDown && (current.Value.Spell.Difficulty <= A_0)) && ((current.Value.Duration != -1.0) && !current.Value.Spell.isUntargetted))
                {
                    MySpell spell = current.Value.Spell;
                    for (int i = 0; i < 7; i++)
                    {
                        if (spell.RealFamily == cq.h.a((eDamageElement) i, eCombatSpellType.Vuln).RealFamily)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }
}

