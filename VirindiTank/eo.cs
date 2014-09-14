using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System;
using System.Runtime.InteropServices;
using uTank2;

internal class eo : IDisposable
{
    private bool a;
    public double b = 10.0;
    public double c = 10.0;
    public double d = 5.0;
    private ev e;
    private bool f;
    private bool g;
    private int h;
    public MySortedList<int, eo.b> i = new MySortedList<int, eo.b>(0x5c);
    public MySortedList<int, eo.b> j = new MySortedList<int, eo.b>(0x5d);

    public eo(ev A_0)
    {
        this.e = A_0;
        this.e.aw.get_CharacterFilter().add_ChangeFellowship(new EventHandler<ChangeFellowshipEventArgs>(this.a));
        this.e.aw.get_EchoFilter().add_ServerDispatch(new EventHandler<NetworkMessageEventArgs>(this.a));
        this.e.aw.get_EchoFilter().add_ClientDispatch(new EventHandler<NetworkMessageEventArgs>(this.b));
    }

    private eo.a a()
    {
        eo.a a = new eo.a {
            a = 101f,
            c = 101f,
            e = 101f,
            b = 0,
            d = 0,
            f = 0
        };
        if (this.g && this.a)
        {
            for (int j = 0; j < this.i.Values.Count; j++)
            {
                eo.b b = this.i.Values[j];
                TimeSpan span = (TimeSpan) (DateTimeOffset.Now - b.a);
                if (span.TotalSeconds < this.b)
                {
                    float num2 = 100f;
                    float num3 = 100f;
                    float num4 = 100f;
                    if (b.b != 0)
                    {
                        num2 = (100 * b.e) / b.b;
                    }
                    if (b.c != 0)
                    {
                        num3 = (100 * b.f) / b.c;
                    }
                    if (b.d != 0)
                    {
                        num4 = (100 * b.g) / b.d;
                    }
                    if (dh.b(this.i.Keys[j]))
                    {
                        double num5 = this.e.aw.get_WorldFilter().Distance(this.i.Keys[j], this.e.aw.get_CharacterFilter().get_Id(), true);
                        if ((num5 <= er.h("HelperDistanceHitP")) && (num2 < a.a))
                        {
                            a.a = num2;
                            a.b = this.i.Keys[j];
                            a.g = true;
                        }
                        if ((num5 <= er.h("HelperDistanceStam")) && (num3 < a.c))
                        {
                            a.c = num3;
                            a.d = this.i.Keys[j];
                            a.h = true;
                        }
                        if ((num5 <= er.h("HelperDistanceMana")) && (num4 < a.e))
                        {
                            a.e = num4;
                            a.f = this.i.Keys[j];
                            a.i = true;
                        }
                    }
                }
            }
        }
        MyList<int> list = new MyList<int>(0x5e);
        foreach (int num6 in this.j.Keys)
        {
            TimeSpan span4 = (TimeSpan) (DateTimeOffset.Now - this.j[num6].a);
            if (span4.TotalMinutes > 2.0)
            {
                list.Add(num6);
            }
        }
        foreach (int num7 in list)
        {
            this.j.Remove(num7);
        }
        for (int i = 0; i < this.j.Values.Count; i++)
        {
            if (this.j.Keys[i] != PluginCore.cq.aw.get_CharacterFilter().get_Id())
            {
                eo.b b2 = this.j.Values[i];
                TimeSpan span2 = (TimeSpan) (DateTimeOffset.Now - b2.a);
                TimeSpan span3 = (TimeSpan) (DateTimeOffset.Now - b2.h);
                if (span2.TotalSeconds < this.c)
                {
                    float num9 = 100f;
                    float num10 = 100f;
                    float num11 = 100f;
                    if (b2.b != 0)
                    {
                        num9 = (100 * b2.e) / b2.b;
                    }
                    if (b2.c != 0)
                    {
                        num10 = (100 * b2.f) / b2.c;
                    }
                    if (b2.d != 0)
                    {
                        num11 = (100 * b2.g) / b2.d;
                    }
                    if (dh.b(this.j.Keys[i]))
                    {
                        double num12 = this.e.aw.get_WorldFilter().Distance(this.j.Keys[i], this.e.aw.get_CharacterFilter().get_Id(), true);
                        if (((num12 <= er.h("HelperDistanceHitP")) && (num9 < a.a)) && ((b2.i != 2) || (span3.TotalSeconds >= this.d)))
                        {
                            a.a = num9;
                            a.b = this.j.Keys[i];
                            a.g = false;
                        }
                        if (((num12 <= er.h("HelperDistanceStam")) && (num10 < a.c)) && ((b2.i != 4) || (span3.TotalSeconds >= this.d)))
                        {
                            a.c = num10;
                            a.d = this.j.Keys[i];
                            a.h = false;
                        }
                        if (((num12 <= er.h("HelperDistanceMana")) && (num11 < a.e)) && ((b2.i != 6) || (span3.TotalSeconds >= this.d)))
                        {
                            a.e = num11;
                            a.f = this.j.Keys[i];
                            a.i = false;
                        }
                    }
                }
            }
        }
        return a;
    }

    public int a(float A_0)
    {
        eo.a a = this.a();
        if (a.a < A_0)
        {
            return a.b;
        }
        return 0;
    }

    public bool a(x A_0)
    {
        eo.a a = this.a();
        if (((a.a >= A_0.a) && (a.c >= A_0.b)) && (a.e >= A_0.c))
        {
            return false;
        }
        return true;
    }

    public void a(int A_0, CharFilterVitalType A_1)
    {
        if (this.j.ContainsKey(A_0))
        {
            this.j[A_0].i = A_1;
            this.j[A_0].h = DateTimeOffset.Now;
        }
    }

    private void a(object A_0, NetworkMessageEventArgs A_1)
    {
        try
        {
            if ((A_1.get_Message().get_Type() == 0xf7b0) && (((int) A_1.get_Message().get_Item("event")) == 0x2c0))
            {
                int key = (int) A_1.get_Message().Struct("fellow").get_Item("fellow");
                if (key != this.e.aw.get_CharacterFilter().get_Id())
                {
                    if (!this.i.ContainsKey(key))
                    {
                        this.i.Add(key, new eo.b());
                        if (dh.b(key))
                        {
                            this.i[key].j = PluginCore.cq.aw.get_WorldFilter().get_Item(key).get_Name();
                        }
                    }
                    this.i[key].a = DateTimeOffset.Now;
                    this.i[key].b = (int) A_1.get_Message().Struct("fellow").get_Item("maxHealth");
                    this.i[key].c = (int) A_1.get_Message().Struct("fellow").get_Item("maxStam");
                    this.i[key].d = (int) A_1.get_Message().Struct("fellow").get_Item("maxMana");
                    this.i[key].e = (int) A_1.get_Message().Struct("fellow").get_Item("curHealth");
                    this.i[key].f = (int) A_1.get_Message().Struct("fellow").get_Item("curStam");
                    this.i[key].g = (int) A_1.get_Message().Struct("fellow").get_Item("curMana");
                }
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    private void a(object A_0, ChangeFellowshipEventArgs A_1)
    {
        try
        {
            switch (A_1.get_Type())
            {
                case 0:
                    this.g = true;
                    this.h = A_1.get_Id();
                    if ((A_1.get_Id() != this.e.aw.get_CharacterFilter().get_Id()) && !this.i.ContainsKey(A_1.get_Id()))
                    {
                        this.i.Add(A_1.get_Id(), new eo.b());
                        if (dh.b(A_1.get_Id()))
                        {
                            this.i[A_1.get_Id()].j = PluginCore.cq.aw.get_WorldFilter().get_Item(A_1.get_Id()).get_Name();
                        }
                    }
                    return;

                case 1:
                    if (A_1.get_Id() != this.e.aw.get_CharacterFilter().get_Id())
                    {
                        break;
                    }
                    this.g = false;
                    this.h = 0;
                    this.i.Clear();
                    return;

                case 2:
                    if (A_1.get_Id() != this.e.aw.get_CharacterFilter().get_Id())
                    {
                        goto Label_01B3;
                    }
                    this.g = false;
                    this.h = 0;
                    this.i.Clear();
                    return;

                case 3:
                    if (A_1.get_Id() == this.e.aw.get_CharacterFilter().get_Id())
                    {
                        this.g = true;
                    }
                    return;

                case 4:
                    this.g = false;
                    this.h = 0;
                    this.i.Clear();
                    return;

                default:
                    return;
            }
            if (this.i.ContainsKey(A_1.get_Id()))
            {
                this.i.Remove(A_1.get_Id());
            }
            return;
        Label_01B3:
            if (this.i.ContainsKey(A_1.get_Id()))
            {
                this.i.Remove(A_1.get_Id());
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    private bool a(string A_0, int A_1)
    {
        return this.a(this.e.e.a(A_0), A_1);
    }

    private bool a(MySpell A_0, int A_1)
    {
        MySpell spell = this.e.h.a(A_0);
        if (spell != null)
        {
            this.e.g.a(spell, A_1);
            return true;
        }
        a5.a(eChatType.Errors, "Error: no usable spell detected in the same class as \"" + A_0.Name + "\"");
        return false;
    }

    public void b()
    {
        if (!this.f)
        {
            this.f = true;
            GC.SuppressFinalize(this);
            this.e.aw.get_EchoFilter().remove_ClientDispatch(new EventHandler<NetworkMessageEventArgs>(this.b));
            this.e.aw.get_EchoFilter().remove_ServerDispatch(new EventHandler<NetworkMessageEventArgs>(this.a));
            this.e.aw.get_CharacterFilter().remove_ChangeFellowship(new EventHandler<ChangeFellowshipEventArgs>(this.a));
            this.e = null;
        }
    }

    public void b(x A_0)
    {
        eo.a a = this.a();
        if (a.a < A_0.a)
        {
            this.a("Adja's Gift", a.b);
            if (!a.g)
            {
                this.j[a.b].i = 2;
                this.j[a.b].h = DateTimeOffset.Now;
            }
        }
        else if (a.c < A_0.b)
        {
            this.a("Replenish", a.d);
            if (!a.h)
            {
                this.j[a.d].i = 4;
                this.j[a.d].h = DateTimeOffset.Now;
            }
        }
        else if (a.e < A_0.c)
        {
            this.a("Gift of Essence", a.f);
            if (!a.i)
            {
                this.j[a.f].i = 6;
                this.j[a.f].h = DateTimeOffset.Now;
            }
        }
    }

    private void b(object A_0, NetworkMessageEventArgs A_1)
    {
        try
        {
            byte[] buffer = A_1.get_Message().get_RawData();
            if ((A_1.get_Message().get_Type() == 0xf7b1) && (A_1.get_Message().Value<int>("action") == 0xa6))
            {
                if (buffer[12] == 0)
                {
                    this.a = false;
                }
                else if (buffer[12] == 1)
                {
                    this.a = true;
                }
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
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

    [StructLayout(LayoutKind.Sequential)]
    private struct a
    {
        public float a;
        public int b;
        public float c;
        public int d;
        public float e;
        public int f;
        public bool g;
        public bool h;
        public bool i;
    }

    public class b
    {
        public DateTimeOffset a = DateTimeOffset.MinValue;
        public int b = 1;
        public int c = 1;
        public int d = 1;
        public int e = 1;
        public int f = 1;
        public int g = 1;
        public DateTimeOffset h = DateTimeOffset.MinValue;
        public CharFilterVitalType i;
        public string j;
    }
}

