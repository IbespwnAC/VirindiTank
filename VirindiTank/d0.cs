using Decal.Adapter;
using Decal.Adapter.Wrappers;
using System;
using System.Text.RegularExpressions;
using uTank2;

internal class d0 : IDisposable
{
    private bool a;
    private Regex b = new Regex(".*The Mana Stone gives [0-9,]* points of mana to the following items:.*");
    private MyDictionary<int, DateTimeOffset> c = new MyDictionary<int, DateTimeOffset>(0x3d);
    private Random d = new Random();
    private int e;
    private int f;

    public d0(CoreManager A_0)
    {
        A_0.add_ChatBoxMessage(new EventHandler<ChatTextInterceptEventArgs>(this.a));
    }

    private void a()
    {
        foreach (int num in PluginCore.cq.av.g)
        {
            if ((PluginCore.cq.av.g() != num) && dh.b(num))
            {
                bool flag = false;
                if (!PluginCore.cq.aw.get_WorldFilter().get_Item(num).get_HasIdData())
                {
                    flag = true;
                }
                if (!this.c.ContainsKey(num))
                {
                    flag = true;
                }
                else if (this.c[num] <= DateTimeOffset.Now)
                {
                    flag = true;
                }
                if (flag && !PluginCore.cq.u.b(num))
                {
                    PluginCore.cq.u.b(num, new b0.b(this.a));
                }
            }
        }
    }

    private void a(int A_0, bool A_1)
    {
        if (A_1)
        {
            this.c[A_0] = DateTimeOffset.Now + TimeSpan.FromMilliseconds((double) this.d.Next(0x1d4c0, 0x57e40));
        }
    }

    private void a(object A_0, ChatTextInterceptEventArgs A_1)
    {
        try
        {
            if ((A_1.get_Color() == 0) && this.b.IsMatch(A_1.get_Text()))
            {
                this.c.Clear();
                PluginCore.cq.n.a("Mana Stone use detected.", e8.e);
            }
        }
        catch (Exception exception)
        {
            ad.a(exception);
        }
    }

    public void b()
    {
        if (!this.a)
        {
            this.a = true;
            GC.SuppressFinalize(this);
            PluginCore.cq.aw.remove_ChatBoxMessage(new EventHandler<ChatTextInterceptEventArgs>(this.a));
        }
    }

    public void c()
    {
        int num = PluginCore.cq.ax.get_Actions().get_CurrentSelection();
        PluginCore.cq.ax.get_Actions().SelectItem(PluginCore.cg);
        PluginCore.cq.ax.get_Actions().UseItem(this.f, 1);
        PluginCore.cq.ax.get_Actions().SelectItem(num);
    }

    protected override void d()
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

    public bool e()
    {
        if (!er.j("RefillWornMana"))
        {
            return false;
        }
        this.a();
        int num = er.i("RefillWornMana-Item-ManaPercent");
        if (num > 0x63)
        {
            num = 0x63;
        }
        this.e = 0;
        bool flag = false;
        foreach (int num2 in PluginCore.cq.av.g)
        {
            if (((PluginCore.cq.av.g() != num2) && this.c.ContainsKey(num2)) && dh.b(num2))
            {
                WorldObject obj2 = PluginCore.cq.aw.get_WorldFilter().get_Item(num2);
                if (obj2.Exists(0x6b) && obj2.Exists(0x6c))
                {
                    int num3 = obj2.Values(0x6b);
                    int num4 = obj2.Values(0x6c);
                    if (num4 != 0)
                    {
                        if (((100 * num3) / num4) < num)
                        {
                            string[] strArray = new string[] { "Item ", obj2.get_Name(), " low on mana, ", ((100 * num3) / num4).ToString(), "%, ", num3.ToString(), "/", num4.ToString() };
                            PluginCore.cq.n.a(string.Concat(strArray), e8.e);
                            flag = true;
                        }
                        this.e += num4 - num3;
                    }
                }
            }
        }
        if (flag)
        {
            this.f = PluginCore.cq.n.e();
        }
        return (flag && (this.f != 0));
    }
}

