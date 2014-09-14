using Decal.Adapter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using uTank2;

internal class b2 : IDisposable, IEnumerable<KeyValuePair<int, ActiveSpellInfo>>
{
    private Dictionary<int, ActiveSpellInfo> a = new Dictionary<int, ActiveSpellInfo>();
    private Dictionary<int, List<ActiveSpellInfo>> b = new Dictionary<int, List<ActiveSpellInfo>>();
    private bool c;
    private b2.a d;
    private b2.a e;

    public b2(PluginCore A_0)
    {
        A_0.a(new uTank2.PluginCore.a(this.a));
    }

    private IEnumerator a()
    {
        return this.a.GetEnumerator();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void a(b2.a A_0)
    {
        this.d = (b2.a) Delegate.Remove(this.d, A_0);
    }

    private void a(MessageStruct A_0)
    {
        ActiveSpellInfo info = ActiveSpellInfo.FromProtocolStruct(A_0);
        if (info.Duration > 0.0)
        {
            this.a[info.Id] = info;
            PluginCore.cq.n.a("ApplySpell (regular): " + info.ToString(), e8.e);
            if (this.d != null)
            {
                this.d(info);
            }
        }
        else
        {
            if (!this.b.ContainsKey(info.Id))
            {
                this.b[info.Id] = new List<ActiveSpellInfo>();
            }
            bool flag = false;
            for (int i = 0; i < this.b[info.Id].Count; i++)
            {
                if (this.b[info.Id][i].Layer == info.Layer)
                {
                    flag = true;
                    this.b[info.Id][i] = info;
                    break;
                }
            }
            if (!flag)
            {
                this.b[info.Id].Add(info);
            }
            PluginCore.cq.n.a("ApplySpell (noduration): " + info.ToString(), e8.e);
        }
    }

    public bool a(int A_0)
    {
        if (!this.a.ContainsKey(A_0))
        {
            return false;
        }
        if (this.a[A_0].ExpireTime < DateTimeOffset.Now)
        {
            return false;
        }
        return true;
    }

    private void a(int A_0, int A_1)
    {
        if (this.a.ContainsKey(A_0))
        {
            ActiveSpellInfo info = this.a[A_0];
            if (info.Layer == A_1)
            {
                this.a.Remove(A_0);
                if (this.e != null)
                {
                    this.e(info);
                }
            }
        }
        if (this.b.ContainsKey(A_0))
        {
            for (int i = this.b[A_0].Count - 1; i >= 0; i--)
            {
                if (this.b[A_0][i].Layer == A_1)
                {
                    this.b[A_0].RemoveAt(i);
                }
            }
        }
        PluginCore.cq.n.a("RemoveSpell: " + A_0.ToString() + ", layer " + A_1.ToString(), e8.e);
    }

    private void a(object A_0, NetworkMessageEventArgs A_1)
    {
        if (A_1.get_Message().get_Type() == 0xf7b0)
        {
            int num23 = A_1.get_Message().Value<int>("event");
            if (num23 != 0x13)
            {
                switch (num23)
                {
                    case 0x2c2:
                        this.a(A_1.get_Message().Struct("enchantment"));
                        return;

                    case 0x2c3:
                    {
                        int num9 = A_1.get_Message().Value<int>("spell");
                        int num10 = A_1.get_Message().Value<short>("layer");
                        this.a(num9, num10);
                        return;
                    }
                    case 0x2c4:
                        return;

                    case 0x2c5:
                    {
                        int num11 = A_1.get_Message().Value<int>("count");
                        for (int i = 0; i < num11; i++)
                        {
                            int num13 = A_1.get_Message().Struct("enchantments").Struct(i).Value<int>("spell");
                            int num14 = A_1.get_Message().Struct("enchantments").Struct(i).Value<short>("layer");
                            this.a(num13, num14);
                        }
                        return;
                    }
                    case 710:
                    {
                        Dictionary<int, ActiveSpellInfo> a = this.a;
                        this.a = new Dictionary<int, ActiveSpellInfo>();
                        foreach (KeyValuePair<int, ActiveSpellInfo> pair in a)
                        {
                            if (pair.Value.IsCoolDown)
                            {
                                this.a[pair.Key] = pair.Value;
                            }
                            else if (this.e != null)
                            {
                                this.e(pair.Value);
                            }
                        }
                        return;
                    }
                    case 0x2c7:
                    {
                        int num15 = A_1.get_Message().Value<int>("spell");
                        int num16 = A_1.get_Message().Value<short>("layer");
                        this.a(num15, num16);
                        return;
                    }
                    case 0x2c8:
                    {
                        int num17 = A_1.get_Message().Value<int>("count");
                        for (int j = 0; j < num17; j++)
                        {
                            int num19 = A_1.get_Message().Struct("enchantments").Struct(j).Value<int>("spell");
                            int num20 = A_1.get_Message().Struct("enchantments").Struct(j).Value<short>("layer");
                            this.a(num19, num20);
                        }
                        return;
                    }
                    case 0x1ac:
                    {
                        List<int> list = new List<int>();
                        foreach (KeyValuePair<int, ActiveSpellInfo> pair2 in this.a)
                        {
                            MySpell spell = PluginCore.cq.e.b(pair2.Key);
                            if ((spell != null) && spell.isOffensive)
                            {
                                list.Add(pair2.Key);
                            }
                        }
                        foreach (int num21 in list)
                        {
                            ActiveSpellInfo info = this.a[num21];
                            this.a.Remove(num21);
                            if (this.e != null)
                            {
                                this.e(info);
                            }
                        }
                        return;
                    }
                }
            }
            else
            {
                MessageStruct struct2 = A_1.get_Message().Struct("vectors");
                if ((struct2.Value<int>("flags") & 0x200) > 0)
                {
                    int num2 = struct2.Value<int>("enchantmentMask");
                    if ((num2 & 1) > 0)
                    {
                        int num3 = struct2.Value<int>("lifeSpellCount");
                        for (int k = 0; k < num3; k++)
                        {
                            this.a(struct2.Struct("lifeSpells").Struct(k).Struct(0));
                        }
                    }
                    if ((num2 & 2) > 0)
                    {
                        int num5 = struct2.Value<int>("creatureSpellCount");
                        for (int m = 0; m < num5; m++)
                        {
                            this.a(struct2.Struct("creatureSpells").Struct(m).Struct(0));
                        }
                    }
                    if ((num2 & 8) > 0)
                    {
                        int num7 = struct2.Value<int>("cooldownCount");
                        for (int n = 0; n < num7; n++)
                        {
                            this.a(struct2.Struct("cooldowns").Struct(n).Struct(0));
                        }
                    }
                }
            }
        }
    }

    public void b()
    {
        if (!this.c)
        {
            this.c = true;
            GC.SuppressFinalize(this);
            PluginCore.PC.b(new uTank2.PluginCore.a(this.a));
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void b(b2.a A_0)
    {
        this.e = (b2.a) Delegate.Combine(this.e, A_0);
    }

    public bool b(int A_0, int A_1)
    {
        if (!this.a.ContainsKey(A_0))
        {
            return false;
        }
        if (this.a[A_0].ExpireTime < (DateTimeOffset.Now + TimeSpan.FromSeconds((double) A_1)))
        {
            return false;
        }
        return true;
    }

    protected override void c()
    {
        try
        {
            this.b();
        }
        finally
        {
            base.Finalize();
        }
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void c(b2.a A_0)
    {
        this.d = (b2.a) Delegate.Combine(this.d, A_0);
    }

    public IEnumerator<KeyValuePair<int, ActiveSpellInfo>> d()
    {
        return this.a.GetEnumerator();
    }

    [MethodImpl(MethodImplOptions.Synchronized)]
    public void d(b2.a A_0)
    {
        this.e = (b2.a) Delegate.Remove(this.e, A_0);
    }

    public delegate void a(ActiveSpellInfo A_0);
}

