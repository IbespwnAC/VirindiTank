using System;
using System.Runtime.InteropServices;

internal class d9
{
    private static long a;
    private static decimal b = 1000M;
    private static bool c = false;
    private DateTimeOffset d;
    private double e;
    private bool f;

    private d9(DateTimeOffset A_0)
    {
        b();
        this.d = A_0;
        this.f = true;
    }

    private d9(double A_0)
    {
        b();
        this.e = A_0;
        this.f = false;
    }

    public static d9 a()
    {
        try
        {
            b();
            long num = 0L;
            QueryPerformanceCounter(out num);
            return new d9(num * (((double) b) / ((double) a)));
        }
        catch
        {
            return new d9(DateTimeOffset.Now);
        }
    }

    public static double a(d9 A_0, d9 A_1)
    {
        if (A_0.f != A_1.f)
        {
            return 0.0;
        }
        if (A_0.f)
        {
            TimeSpan span = (TimeSpan) (A_0.d - A_1.d);
            return span.TotalMilliseconds;
        }
        return (A_0.e - A_1.e);
    }

    private static void b()
    {
        if (!c)
        {
            if (!QueryPerformanceFrequency(out a))
            {
                throw new Exception();
            }
            c = true;
        }
    }

    [DllImport("Kernel32.dll")]
    private static extern bool QueryPerformanceCounter(out long A_0);
    [DllImport("Kernel32.dll")]
    private static extern bool QueryPerformanceFrequency(out long A_0);
}

