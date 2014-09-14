using Decal.Adapter.Wrappers;
using System;
using uTank2;

internal static class cx
{
    public static bool a(cv A_0)
    {
        if (A_0 == null)
        {
            return false;
        }
        return (c(A_0) != 0);
    }

    public static bool a(int A_0)
    {
        if (A_0 != 0)
        {
            foreach (EnchantmentWrapper wrapper in PluginCore.cq.aw.get_CharacterFilter().get_Enchantments())
            {
                if (!PluginCore.cq.e.c(wrapper.get_SpellId()) && (wrapper.get_SpellId() == A_0))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool b(cv A_0)
    {
        if (A_0 == null)
        {
            return false;
        }
        return a(c(A_0));
    }

    public static int c(cv A_0)
    {
        if (A_0 == null)
        {
            return 0;
        }
        int num = A_0.a(dt.b8, 0);
        if (num == 0)
        {
            return 0;
        }
        num |= 0x8000;
        return (short) num;
    }
}

