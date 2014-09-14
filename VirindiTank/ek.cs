using Decal.Adapter;
using Decal.Adapter.Wrappers;
using MyClasses.MyWorldFilter;
using System;
using uTank2;

internal class ek : IDisposable
{
    private CoreManager a;
    private PluginHost b;
    private int c;
    private int d;
    private int e;
    private int f;
    public MyList<int> g = new MyList<int>(0x60);
    private DateTimeOffset h = DateTimeOffset.MinValue;
    private bool i;
    private int j;
    private bool k;

    public ek(CoreManager A_0, PluginHost A_1, int A_2)
    {
        this.a = A_0;
        this.b = A_1;
        this.c = A_2;
        foreach (cv cv in PluginCore.cq.p.d())
        {
            int num = cv.a(dt.d, 0);
            if (((num == 0x1000000) || (num == 0x100000)) || ((num == 0x400000) || (num == 0x2000000)))
            {
                this.d = cv.k;
            }
            switch (num)
            {
                case 0x800000:
                    this.e = cv.k;
                    break;

                case 0x200000:
                    this.f = cv.k;
                    break;
            }
            if (num > 0)
            {
                this.g.Add(cv.k);
            }
        }
        PluginCore.PC.a(new uTank2.PluginCore.a(this.a));
    }

    private void a()
    {
        this.i = false;
        PluginCore.cq.c.TryPokeMacro();
    }

    private void a(int A_0)
    {
        if (this.e == A_0)
        {
            this.e = 0;
        }
        if (this.f == A_0)
        {
            this.f = 0;
        }
        if (this.d == A_0)
        {
            this.d = 0;
        }
        if (this.g.Contains(A_0))
        {
            this.g.Remove(A_0);
        }
        b8.a(new PluginCore.EmptyDelegate(this.a), 100);
    }

    private void a(int A_0, bk A_1)
    {
        if (A_1 == bk.y)
        {
            this.e = A_0;
        }
        if (A_1 == bk.u)
        {
            this.d = A_0;
        }
        if (A_1 == bk.x)
        {
            this.d = A_0;
        }
        if (A_1 == bk.w)
        {
            this.d = A_0;
        }
        if (A_1 == bk.z)
        {
            this.d = A_0;
        }
        if (A_1 == bk.v)
        {
            this.f = A_0;
        }
        if (!this.g.Contains(A_0))
        {
            this.g.Add(A_0);
        }
        b8.a(new PluginCore.EmptyDelegate(this.a), 100);
    }

    public void a(int A_0, e5 A_1)
    {
        this.a(A_0, A_1, true);
    }

    private void a(object A_0, NetworkMessageEventArgs A_1)
    {
        switch (A_1.get_Message().get_Type())
        {
            case 0x24:
            {
                int num = A_1.get_Message().Value<int>("object");
                this.a(num);
                return;
            }
            case 0xf7b0:
                switch (A_1.get_Message().Value<int>("event"))
                {
                    case 0x22:
                    {
                        int num2 = A_1.get_Message().Value<int>("item");
                        this.a(num2);
                        return;
                    }
                    case 0x23:
                    {
                        int num4 = A_1.get_Message().Value<int>("item");
                        bk bk = A_1.get_Message().Value<int>("slot");
                        this.a(num4, bk);
                        return;
                    }
                    case 410:
                    {
                        int num3 = A_1.get_Message().Value<int>("item");
                        this.a(num3);
                        return;
                    }
                }
                break;
        }
    }

    private void a(string A_0, int A_1)
    {
        string str;
        WorldObject obj2 = this.a.get_WorldFilter().get_Item(A_1);
        if (obj2 == null)
        {
            str = A_1.ToString();
        }
        else
        {
            str = obj2.get_Name();
        }
        a5.a(eChatType.CommandLine, A_0 + str);
    }

    public void a(int A_0, e5 A_1, bool A_2)
    {
        if (!this.f() && (!A_2 || (dh.d() == 1)))
        {
            this.h = DateTimeOffset.Now + TimeSpan.FromMilliseconds(800.0);
            this.j = A_0;
            this.i = true;
            cv cv = PluginCore.cq.p.d(A_0);
            if ((cv != null) && (cv.c() == ObjectClass.MeleeWeapon))
            {
                if (A_1 == e5.b)
                {
                    dh.a(A_0, true, 0);
                }
                else
                {
                    dh.a(A_0, true, 1);
                }
            }
            else
            {
                PluginCore.cq.ax.get_Actions().UseItem(A_0, 0);
            }
        }
    }

    public void b()
    {
        if (!this.k)
        {
            this.k = true;
            GC.SuppressFinalize(this);
            PluginCore.PC.b(new uTank2.PluginCore.a(this.a));
            this.a = null;
            this.b = null;
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

    public int d()
    {
        if (dh.b(this.d))
        {
            return this.d;
        }
        return 0;
    }

    public int e()
    {
        if (dh.b(this.f))
        {
            return this.f;
        }
        return 0;
    }

    public bool f()
    {
        if (this.h < DateTimeOffset.Now)
        {
            this.i = false;
        }
        return this.i;
    }

    public int g()
    {
        if (dh.b(this.e))
        {
            return this.e;
        }
        return 0;
    }
}

