using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

internal class dz
{
    private bool a;
    private double b;
    private double c;
    private double d;
    private float e;
    private float f;
    private int g;
    private bool h;
    private static Regex i = new Regex(@"(?'nsnum'[0-9]{1,2}(\.[0-9]))(?'nschr'[nNsS])[,\ ]*(?'ewnum'[0-9]{1,2}(\.[0-9]))(?'ewchr'[eEwW])");

    public float a()
    {
        return this.e;
    }

    public double a(dz A_0)
    {
        if (!this.b())
        {
            return 0.0;
        }
        if (!A_0.b())
        {
            return 0.0;
        }
        double x = A_0.f() - this.f();
        double y = A_0.g() - this.g();
        double num3 = -Math.Atan2(y, x);
        return (num3 + 1.5707963267948966);
    }

    public void a(TextReader A_0)
    {
        this.a = Convert.ToBoolean(A_0.ReadLine(), CultureInfo.InvariantCulture);
        this.b = Convert.ToDouble(A_0.ReadLine(), CultureInfo.InvariantCulture);
        this.c = Convert.ToDouble(A_0.ReadLine(), CultureInfo.InvariantCulture);
        this.d = Convert.ToDouble(A_0.ReadLine(), CultureInfo.InvariantCulture);
        this.h = false;
    }

    public void a(TextWriter A_0)
    {
        A_0.WriteLine(Convert.ToString(this.a, CultureInfo.InvariantCulture));
        A_0.WriteLine(Convert.ToString(this.b, CultureInfo.InvariantCulture));
        A_0.WriteLine(Convert.ToString(this.c, CultureInfo.InvariantCulture));
        A_0.WriteLine(Convert.ToString(this.d, CultureInfo.InvariantCulture));
    }

    public double a(dz A_0, bool A_1)
    {
        if (!this.b())
        {
            return double.MaxValue;
        }
        if (!A_0.b())
        {
            return double.MaxValue;
        }
        if (A_1)
        {
            double num = this.f() - A_0.f();
            double num2 = this.g() - A_0.g();
            double num3 = this.h() - A_0.h();
            return Math.Sqrt(((num * num) + (num2 * num2)) + (num3 * num3));
        }
        double num4 = this.f() - A_0.f();
        double num5 = this.g() - A_0.g();
        return Math.Sqrt((num4 * num4) + (num5 * num5));
    }

    public static dz a(double A_0, double A_1)
    {
        return a(A_0, A_1);
    }

    public static bool a(string A_0, out dz A_1)
    {
        A_1 = new dz();
        A_1.a = false;
        Match match = i.Match(A_0);
        if (!match.Success)
        {
            return false;
        }
        double num = double.Parse(match.Groups["ewnum"].Value);
        double num2 = double.Parse(match.Groups["nsnum"].Value);
        if (match.Groups["ewchr"].Value.ToLowerInvariant() == "w")
        {
            num *= -1.0;
        }
        if (match.Groups["nschr"].Value.ToLowerInvariant() == "s")
        {
            num2 *= -1.0;
        }
        A_1 = a(num, num2);
        return true;
    }

    public static dz a(double A_0, double A_1, double A_2)
    {
        return new dz { a = true, b = A_0, c = A_1, d = A_2 };
    }

    public static dz a(float A_0, float A_1, float A_2, int A_3)
    {
        int num = ((int) Math.Floor((double) (((double) A_3) / 16777216.0))) & 0xff;
        int num2 = ((int) Math.Floor((double) (((double) A_3) / 65536.0))) & 0xff;
        double num3 = ((((num2 - 0x7f) * 192.0) + A_1) - 84.0) / 240.0;
        double num4 = ((((num - 0x7f) * 192.0) + A_0) - 84.0) / 240.0;
        return new dz { a = true, b = num4, c = num3, d = A_2, g = A_3, e = A_0, f = A_1, h = true };
    }

    public bool b()
    {
        return this.a;
    }

    public float c()
    {
        return this.f;
    }

    public int d()
    {
        return this.g;
    }

    public bool e()
    {
        return this.h;
    }

    public double f()
    {
        return this.b;
    }

    public double g()
    {
        return this.c;
    }

    public double h()
    {
        return this.d;
    }

    public override string i()
    {
        if (!this.b())
        {
            return "???";
        }
        string str = (this.g() < 0.0) ? "S" : "N";
        string str2 = (this.f() < 0.0) ? "W" : "E";
        return (Math.Round(Math.Abs(this.g()), 1).ToString() + str + ", " + Math.Round(Math.Abs(this.f()), 1).ToString() + str2);
    }
}

