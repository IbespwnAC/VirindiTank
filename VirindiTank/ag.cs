using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System;
using System.Runtime.InteropServices;
using uTank2;

internal class ag : IDisposable
{
    private bool a;

    public void a()
    {
        if (!this.a)
        {
            this.a = true;
            GC.SuppressFinalize(this);
        }
    }

    public b a(b A_0)
    {
        return new b(new ag.a(A_0));
    }

    public float a(int A_0)
    {
        CoreManager aw = PluginCore.cq.aw;
        if (!aw.get_WorldFilter().get_Item(A_0).get_HasIdData())
        {
            return -1f;
        }
        if (aw.get_WorldFilter().get_Item(A_0).get_ObjectClass() != 1)
        {
            return -1f;
        }
        int num = aw.get_WorldFilter().get_Item(A_0).Values(160, 0);
        CharFilterSkillType type = (CharFilterSkillType) aw.get_WorldFilter().get_Item(A_0).Values(0xd000020);
        ag.a a = new ag.a(aw.get_WorldFilter().get_Item(A_0).Values(0xa00000b, 1.0), aw.get_WorldFilter().get_Item(A_0).Values(0xd000022, 1));
        new b(a);
        int num2 = 10 - aw.get_WorldFilter().get_Item(A_0).Values(0xab, 0);
        if (num2 == 10)
        {
            num2 = 9;
        }
        double num3 = this.a(new ag.a(this.a(type, num)), 9, 0);
        return (float) Math.Round((double) ((this.a(a, num2, A_0) / num3) * 100.0), 2);
    }

    public b a(b A_0, int A_1)
    {
        ag.a a = new ag.a(A_0);
        MySpell spell = PluginCore.cq.e.a("Major Blood Thirst");
        MySpell spell2 = PluginCore.cq.e.a("Minor Blood Thirst");
        bool flag = false;
        bool flag2 = false;
        for (int i = 0; i < PluginCore.cq.aw.get_WorldFilter().get_Item(A_1).get_SpellCount(); i++)
        {
            if (PluginCore.cq.aw.get_WorldFilter().get_Item(A_1).Spell(i) == spell.Id)
            {
                flag = true;
            }
            if (PluginCore.cq.aw.get_WorldFilter().get_Item(A_1).Spell(i) == spell2.Id)
            {
                flag2 = true;
            }
        }
        if (flag && flag2)
        {
            flag2 = false;
        }
        if (flag)
        {
            a.b += 4.0;
        }
        if (flag2)
        {
            a.b += 2.0;
        }
        return new b(a);
    }

    public b a(CharFilterSkillType A_0, int A_1)
    {
        switch (A_0)
        {
            case 1:
                if (A_1 != 0)
                {
                    if (A_1 == 250)
                    {
                        return new b(16.8, 28.0);
                    }
                    if (A_1 == 300)
                    {
                        return new b(19.2, 32.0);
                    }
                    if (A_1 == 0x145)
                    {
                        return new b(21.6, 36.0);
                    }
                    if (A_1 == 350)
                    {
                        return new b(22.8, 38.0);
                    }
                    if (A_1 == 370)
                    {
                        return new b(25.2, 42.0);
                    }
                    if (A_1 != 400)
                    {
                        break;
                    }
                    return new b(27.6, 46.0);
                }
                return new b(11.4, 19.0);

            case 4:
                if (A_1 != 0)
                {
                    if (A_1 == 250)
                    {
                        return new b(9.0, 13.0);
                    }
                    if (A_1 == 300)
                    {
                        return new b(9.0, 15.0);
                    }
                    if (A_1 == 0x145)
                    {
                        return new b(12.6, 18.0);
                    }
                    if (A_1 == 350)
                    {
                        return new b(14.0, 20.0);
                    }
                    if (A_1 == 370)
                    {
                        return new b(16.8, 24.0);
                    }
                    if (A_1 != 400)
                    {
                        break;
                    }
                    return new b(18.2, 26.0);
                }
                return new b(8.4, 12.0);

            case 5:
                if (A_1 != 0)
                {
                    if (A_1 == 250)
                    {
                        return new b(19.5, 26.0);
                    }
                    if (A_1 == 300)
                    {
                        return new b(22.5, 30.0);
                    }
                    if (A_1 == 0x145)
                    {
                        return new b(25.5, 34.0);
                    }
                    if (A_1 == 350)
                    {
                        return new b(27.0, 36.0);
                    }
                    if (A_1 == 370)
                    {
                        return new b(28.5, 38.0);
                    }
                    if (A_1 != 400)
                    {
                        break;
                    }
                    return new b(31.5, 42.0);
                }
                return new b(13.5, 18.0);

            case 9:
                if (A_1 != 0)
                {
                    if (A_1 == 250)
                    {
                        return new b(13.2, 24.0);
                    }
                    if (A_1 == 300)
                    {
                        return new b(14.3, 26.0);
                    }
                    if (A_1 == 0x145)
                    {
                        return new b(15.4, 28.0);
                    }
                    if (A_1 == 350)
                    {
                        return new b(17.6, 32.0);
                    }
                    if (A_1 == 370)
                    {
                        return new b(19.8, 36.0);
                    }
                    if (A_1 != 400)
                    {
                        break;
                    }
                    return new b(22.0, 40.0);
                }
                return new b(9.35, 17.0);

            case 10:
                if (A_1 != 0)
                {
                    if (A_1 == 250)
                    {
                        return new b(9.75, 13.0);
                    }
                    if (A_1 == 300)
                    {
                        return new b(11.25, 15.0);
                    }
                    if (A_1 == 0x145)
                    {
                        return new b(14.75, 18.0);
                    }
                    if (A_1 == 350)
                    {
                        return new b(15.0, 20.0);
                    }
                    if (A_1 == 370)
                    {
                        return new b(18.0, 24.0);
                    }
                    if (A_1 != 400)
                    {
                        break;
                    }
                    return new b(19.5, 26.0);
                }
                return new b(9.0, 12.0);

            case 11:
                if (A_1 != 0)
                {
                    if (A_1 == 250)
                    {
                        return new b(18.0, 30.0);
                    }
                    if (A_1 == 300)
                    {
                        return new b(21.0, 35.0);
                    }
                    if (A_1 == 0x145)
                    {
                        return new b(24.0, 40.0);
                    }
                    if (A_1 == 350)
                    {
                        return new b(27.0, 45.0);
                    }
                    if (A_1 == 370)
                    {
                        return new b(30.0, 50.0);
                    }
                    if (A_1 != 400)
                    {
                        break;
                    }
                    return new b(33.0, 55.0);
                }
                return new b(12.0, 20.0);

            case 13:
                if (A_1 != 0)
                {
                    if (A_1 == 250)
                    {
                        return new b(5.5, 11.0);
                    }
                    if (A_1 == 300)
                    {
                        return new b(6.5, 13.0);
                    }
                    if (A_1 == 0x145)
                    {
                        return new b(8.0, 16.0);
                    }
                    if (A_1 == 350)
                    {
                        return new b(10.0, 20.0);
                    }
                    if (A_1 == 370)
                    {
                        return new b(11.0, 22.0);
                    }
                    if (A_1 == 400)
                    {
                        return new b(13.0, 26.0);
                    }
                    break;
                }
                return new b(4.0, 8.0);
        }
        return new b(0.0, 0.0);
    }

    public double a(ag.a A_0, int A_1, int A_2)
    {
        double num = 0.0;
        for (int i = 0; i <= A_1; i++)
        {
            ag.b b2;
            ag.a a = A_0;
            for (int j = 0; j < i; j++)
            {
                a.a *= 0.8;
            }
            for (int k = 0; k < (A_1 - i); k++)
            {
                a.b++;
            }
            ag.b b = new ag.b(a);
            if (A_2 == 0)
            {
                b2 = this.a(b);
            }
            else
            {
                b2 = this.a(b, A_2);
            }
            double num5 = (b2.b + b2.a) / 2.0;
            if (num5 > num)
            {
                num = num5;
            }
        }
        return num;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct a
    {
        public double a;
        public double b;
        public a(double A_0, int A_1)
        {
            this.a = A_0;
            this.b = A_1;
        }

        public a(ag.b A_0)
        {
            this.b = A_0.b;
            this.a = 1.0 - (A_0.a / A_0.b);
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b
    {
        public double a;
        public double b;
        public b(double A_0, double A_1)
        {
            this.b = A_1;
            this.a = A_0;
        }

        public b(ag.a A_0)
        {
            this.b = A_0.b;
            this.a = this.b * (1.0 - A_0.a);
        }
    }
}

