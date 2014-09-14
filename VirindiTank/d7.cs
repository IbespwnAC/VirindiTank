using System;
using System.Collections.Generic;

internal abstract class d7 : dw
{
    protected Dictionary<string, k> a = new Dictionary<string, k>();
    private List<d7.a> b;

    public d7()
    {
        this.b = this.b();
        this.a();
    }

    private void a()
    {
        this.a.Clear();
        foreach (d7.a a in this.b)
        {
            this.a[a.b] = a.c;
        }
    }

    public override void a(k A_0)
    {
        this.a();
        a0 a = A_0.c() as a0;
        if ((a != null) && (a.a() >= 2))
        {
            foreach (v v in a.d())
            {
                string str = k.b(v[0]);
                k k = v[1];
                this.a[str] = k;
            }
        }
    }

    protected override string a(int A_0)
    {
        return this.b[A_0].a;
    }

    protected override void a(int A_0, string A_1)
    {
        if (this.b[A_0].d == typeof(string))
        {
            this.a[this.b[A_0].b] = k.a(A_1);
        }
        else if (this.b[A_0].d == typeof(int))
        {
            int result = 0;
            int.TryParse(A_1, out result);
            this.a[this.b[A_0].b] = k.a(result);
        }
        else if (this.b[A_0].d == typeof(double))
        {
            double num2 = 0.0;
            double.TryParse(A_1, out num2);
            this.a[this.b[A_0].b] = k.a(num2);
        }
    }

    protected abstract List<d7.a> b();
    protected override string b(int A_0)
    {
        k k = this.a[this.b[A_0].b];
        if (this.b[A_0].d == typeof(string))
        {
            return k.b(k);
        }
        if (this.b[A_0].d == typeof(int))
        {
            return k.e(k).ToString();
        }
        if (this.b[A_0].d == typeof(double))
        {
            return k.f(k).ToString();
        }
        return "";
    }

    protected override int f()
    {
        return this.b.Count;
    }

    public override k j()
    {
        a0 a = new a0(new string[] { "k", "v" });
        foreach (KeyValuePair<string, k> pair in this.a)
        {
            v v = new v(a);
            v[0] = k.a(pair.Key);
            v[1] = pair.Value;
            a.c(v);
        }
        return new k(a);
    }

    public class a
    {
        public string a;
        public string b;
        public k c;
        public Type d;

        public static d7.a Create<T>(string pLabel, string pKey, T pDefaultValue)
        {
            return new d7.a { a = pLabel, b = pKey, c = new k(pDefaultValue), d = pDefaultValue.GetType() };
        }
    }
}

