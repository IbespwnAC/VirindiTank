using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;

[DefaultMember("Item")]
internal class o
{
    public Dictionary<int, cv> a = new Dictionary<int, cv>();
    public Dictionary<string, List<cv>> b = new Dictionary<string, List<cv>>();
    public int c;
    public int d;
    public int e;
    public int f;
    public int g;
    public float h;
    public float i;

    internal void a(cv A_0)
    {
        this.a[A_0.k] = A_0;
        if (!this.b.ContainsKey(A_0.g()))
        {
            this.b[A_0.g()] = new List<cv>();
        }
        this.b[A_0.g()].Add(A_0);
    }

    public int a(int A_0)
    {
        if (!this.a.ContainsKey(A_0))
        {
            return 0;
        }
        if (this.a[A_0].c() == ObjectClass.TradeNote)
        {
            return (int) Math.Round((double) (((float) this.a[A_0].a[0x13]) * 1.15f));
        }
        return (int) Math.Round((double) (((float) this.a[A_0].a[0x13]) * this.i));
    }

    public ReadOnlyCollection<cv> a(string A_0)
    {
        if (this.b.ContainsKey(A_0))
        {
            return this.b[A_0].AsReadOnly();
        }
        return new List<cv>().AsReadOnly();
    }

    public bool b(cv A_0)
    {
        if (A_0 == null)
        {
            throw new ArgumentException("wo");
        }
        if (A_0.c() != ObjectClass.TradeNote)
        {
            int num = A_0.a(dt.g, 0) / A_0.a(dt.ct, 1);
            int num2 = A_0.a(dt.dd, 0);
            if (num > this.f)
            {
                return false;
            }
            if ((num2 & this.d) == 0)
            {
                return false;
            }
        }
        return true;
    }

    public bool b(int A_0)
    {
        return this.a.ContainsKey(A_0);
    }

    public bool b(string A_0)
    {
        return (this.b.ContainsKey(A_0) && (this.b[A_0].Count > 0));
    }

    public int c(cv A_0)
    {
        if (A_0 == null)
        {
            throw new ArgumentException("wo");
        }
        if (!this.b(A_0))
        {
            return 0;
        }
        if (A_0.c() == ObjectClass.TradeNote)
        {
            return A_0.a[0x13];
        }
        return (int) Math.Floor((double) (((float) A_0.a[0x13]) * this.h));
    }

    public cv c(int A_0)
    {
        if (this.a.ContainsKey(A_0))
        {
            return this.a[A_0];
        }
        return null;
    }
}

