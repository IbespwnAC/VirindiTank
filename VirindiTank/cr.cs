using Decal.Adapter;
using System;
using uTank2;

internal class cr : IDisposable
{
    private const int a = 700;
    private int b;
    private DateTimeOffset c = DateTimeOffset.MinValue;
    private DateTimeOffset d = DateTimeOffset.MaxValue;
    private bool e;

    public cr(PluginCore A_0)
    {
        A_0.a(new uTank2.PluginCore.a(this.a));
        A_0.b(new uTank2.PluginCore.b(this.b));
    }

    private void a()
    {
        this.b++;
        this.d = DateTimeOffset.Now;
    }

    private void a(object A_0, NetworkMessageEventArgs A_1)
    {
        int num2 = A_1.get_Message().get_Type();
        if (num2 == 0xf74c)
        {
            if ((A_1.get_Message().Value<int>("object") == PluginCore.cg) && ((A_1.get_Message().Value<byte>("type_flags") & 1) > 0))
            {
                this.c = DateTimeOffset.Now;
            }
        }
        else if ((num2 == 0xf7b0) && (A_1.get_Message().Value<int>("event") == 0x1c7))
        {
            A_1.get_Message().Value<int>("unknown");
            this.b--;
            if (this.b < 0)
            {
                this.b = 0;
            }
        }
    }

    public void b()
    {
        if (!this.e)
        {
            this.e = true;
            GC.SuppressFinalize(this);
            PluginCore.PC.b(new uTank2.PluginCore.a(this.a));
            PluginCore.PC.a(new uTank2.PluginCore.b(this.b));
        }
    }

    private void b(object A_0, NetworkMessageEventArgs A_1)
    {
        if (A_1.get_Message().get_Type() == 0xf7b1)
        {
            int num2 = A_1.get_Message().Value<int>("action");
            if (num2 <= 200)
            {
                switch (num2)
                {
                    case 0x53:
                    case 0x54:
                    case 0x55:
                    case 0x56:
                    case 200:
                    case 8:
                    case 9:
                    case 0x19:
                    case 0x1a:
                    case 0x1b:
                        return;

                    case 0x4a:
                        this.a();
                        return;

                    case 10:
                        this.c = DateTimeOffset.Now;
                        return;

                    case 0x35:
                        this.a();
                        return;

                    case 0x36:
                        this.a();
                        return;
                }
            }
            else if (num2 <= 0x1bf)
            {
                if (((num2 == 0xcd) || (num2 == 0x1b7)) || (num2 == 0x1bf))
                {
                }
            }
            else
            {
                switch (num2)
                {
                    case 0x263:
                    case 0xf61c:
                    case 0xf753:
                        return;
                }
            }
        }
    }

    public void c()
    {
        if (this.b > 1)
        {
            this.b = 1;
        }
        this.d = DateTimeOffset.Now;
    }

    public bool d()
    {
        TimeSpan span = (TimeSpan) (DateTimeOffset.Now - this.d);
        if (span.TotalSeconds > 5.0)
        {
            this.d = DateTimeOffset.MaxValue;
            this.b = 0;
        }
        if (this.b <= 0)
        {
            TimeSpan span2 = (TimeSpan) (DateTimeOffset.Now - this.c);
            return (span2.TotalMilliseconds < 700.0);
        }
        return true;
    }

    protected override void e()
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
}

