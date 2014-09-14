using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

internal class k : IComparable<k>
{
    private Type a;
    private object b;

    public k()
    {
        this.a = typeof(void);
        this.b = null;
    }

    public k(object A_0)
    {
        this.a = A_0.GetType();
        this.b = A_0;
    }

    public Type a()
    {
        return this.a;
    }

    public static bool a(k A_0)
    {
        return (bool) A_0.b;
    }

    public static k a(bool A_0)
    {
        return new k(A_0);
    }

    public static k a(double A_0)
    {
        return new k(A_0);
    }

    public static k a(int A_0)
    {
        return new k(A_0);
    }

    public void a(TextReader A_0)
    {
        string str = A_0.ReadLine();
        string key = str;
        if (key != null)
        {
            int num;
            if (bx.l == null)
            {
                Dictionary<string, int> dictionary1 = new Dictionary<string, int>(6);
                dictionary1.Add("d", 0);
                dictionary1.Add("i", 1);
                dictionary1.Add("u", 2);
                dictionary1.Add("f", 3);
                dictionary1.Add("s", 4);
                dictionary1.Add("b", 5);
                bx.l = dictionary1;
            }
            if (bx.l.TryGetValue(key, out num))
            {
                switch (num)
                {
                    case 0:
                        this.a = typeof(double);
                        this.b = Convert.ToDouble(A_0.ReadLine(), CultureInfo.InvariantCulture);
                        return;

                    case 1:
                        this.a = typeof(int);
                        this.b = Convert.ToInt32(A_0.ReadLine(), CultureInfo.InvariantCulture);
                        return;

                    case 2:
                        this.a = typeof(uint);
                        this.b = Convert.ToUInt32(A_0.ReadLine(), CultureInfo.InvariantCulture);
                        return;

                    case 3:
                        this.a = typeof(float);
                        this.b = Convert.ToSingle(A_0.ReadLine(), CultureInfo.InvariantCulture);
                        return;

                    case 4:
                        this.a = typeof(string);
                        this.b = A_0.ReadLine();
                        return;

                    case 5:
                        this.a = typeof(bool);
                        this.b = Convert.ToBoolean(A_0.ReadLine(), CultureInfo.InvariantCulture);
                        return;
                }
            }
        }
        this.b = bf.a(str);
        if (this.b != null)
        {
            this.a = this.b.GetType();
            ((e6) this.b).a(A_0);
        }
    }

    public void a(TextWriter A_0)
    {
        if (this.a == typeof(double))
        {
            A_0.WriteLine("d");
            A_0.WriteLine(Convert.ToString((double) this.b, CultureInfo.InvariantCulture));
        }
        else if (this.a == typeof(int))
        {
            A_0.WriteLine("i");
            A_0.WriteLine(Convert.ToString((int) this.b, CultureInfo.InvariantCulture));
        }
        else if (this.a == typeof(uint))
        {
            A_0.WriteLine("u");
            A_0.WriteLine(Convert.ToString((uint) this.b, CultureInfo.InvariantCulture));
        }
        else if (this.a == typeof(float))
        {
            A_0.WriteLine("f");
            A_0.WriteLine(Convert.ToString((float) this.b, CultureInfo.InvariantCulture));
        }
        else if (this.a == typeof(string))
        {
            A_0.WriteLine("s");
            string b = (string) this.b;
            b = b.Replace("\n", "");
            A_0.WriteLine(b);
        }
        else if (this.a == typeof(bool))
        {
            A_0.WriteLine("b");
            A_0.WriteLine(Convert.ToString((bool) this.b, CultureInfo.InvariantCulture));
        }
        else if (typeof(e6).IsAssignableFrom(this.a))
        {
            e6 e = (e6) this.b;
            A_0.WriteLine(e.a());
            e.a(A_0);
        }
        else
        {
            A_0.WriteLine("0");
        }
    }

    public void a(object A_0)
    {
        this.a = A_0.GetType();
        this.b = A_0;
    }

    public static k a(float A_0)
    {
        return new k(A_0);
    }

    public static k a(string A_0)
    {
        return new k(A_0);
    }

    public static k a(uint A_0)
    {
        return new k(A_0);
    }

    public override string b()
    {
        if (this.a == typeof(double))
        {
            return f(this).ToString(CultureInfo.CurrentCulture);
        }
        if (this.a == typeof(int))
        {
            return e(this).ToString(CultureInfo.CurrentCulture);
        }
        if (this.a == typeof(uint))
        {
            return d(this).ToString(CultureInfo.CurrentCulture);
        }
        if (this.a == typeof(float))
        {
            return c(this).ToString(CultureInfo.CurrentCulture);
        }
        if (this.a == typeof(string))
        {
            return b(this);
        }
        if (this.a == typeof(bool))
        {
            return a(this).ToString(CultureInfo.CurrentCulture);
        }
        return "[CANNOT CONVERT]";
    }

    public static string b(k A_0)
    {
        return (string) A_0.b;
    }

    public override bool b(object A_0)
    {
        if (this.a == typeof(double))
        {
            return (f(this) == f((k) A_0));
        }
        if (this.a == typeof(int))
        {
            return (e(this) == e((k) A_0));
        }
        if (this.a == typeof(uint))
        {
            return (d(this) == d((k) A_0));
        }
        if (this.a == typeof(float))
        {
            return (c(this) == c((k) A_0));
        }
        if (this.a == typeof(string))
        {
            return b(this).Equals(b((k) A_0), StringComparison.OrdinalIgnoreCase);
        }
        return ((this.a == typeof(bool)) && (a(this) == a((k) A_0)));
    }

    public object c()
    {
        return this.b;
    }

    public static float c(k A_0)
    {
        return (float) A_0.b;
    }

    public override int d()
    {
        if (this.a == typeof(string))
        {
            return ((string) this.b).ToLowerInvariant().GetHashCode();
        }
        return this.b.GetHashCode();
    }

    public static uint d(k A_0)
    {
        return (uint) A_0.b;
    }

    public static int e(k A_0)
    {
        return (int) A_0.b;
    }

    public static double f(k A_0)
    {
        return (double) A_0.b;
    }

    public static k FromCustom<T>(T val) where T: e6
    {
        return new k { a = typeof(T), b = val };
    }

    public int g(k A_0)
    {
        if (A_0.a != this.a)
        {
            throw new Exception("Invalid DBField comparison");
        }
        if (this.a == typeof(double))
        {
            return f(this).CompareTo(f(A_0));
        }
        if (this.a == typeof(int))
        {
            return e(this).CompareTo(e(A_0));
        }
        if (this.a == typeof(uint))
        {
            return d(this).CompareTo(d(A_0));
        }
        if (this.a == typeof(float))
        {
            return c(this).CompareTo(c(A_0));
        }
        if (this.a != typeof(string))
        {
            throw new Exception("Unknown DBField comparison");
        }
        return string.Compare(b(this), b(A_0), StringComparison.OrdinalIgnoreCase);
    }
}

