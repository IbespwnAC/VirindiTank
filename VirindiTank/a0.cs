using MyClasses;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using uTank2;

internal class a0 : e6
{
    private MyList<v> a;
    private MyList<string> b;
    private MySortedDictionary<int, TypedHashtable<k, v>> c;

    public a0()
    {
        this.a = new MyList<v>(0x4d);
        this.b = new MyList<string>(0x4e);
        this.c = new MySortedDictionary<int, TypedHashtable<k, v>>(0x4f);
    }

    public a0(params string[] A_0)
    {
        this.a = new MyList<v>(0x4d);
        this.b = new MyList<string>(0x4e);
        this.c = new MySortedDictionary<int, TypedHashtable<k, v>>(0x4f);
        foreach (string str in A_0)
        {
            this.b.Add(str);
        }
    }

    public a0(MyList<string> A_0)
    {
        this.a = new MyList<v>(0x4d);
        this.b = new MyList<string>(0x4e);
        this.c = new MySortedDictionary<int, TypedHashtable<k, v>>(0x4f);
        foreach (string str in A_0)
        {
            this.b.Add(str);
        }
    }

    public int a()
    {
        return this.b.Count;
    }

    public v a(int A_0)
    {
        if (A_0 < 0)
        {
            throw new ArgumentOutOfRangeException();
        }
        if (A_0 >= this.c())
        {
            throw new ArgumentOutOfRangeException();
        }
        return this.a[A_0];
    }

    public bool a(TextReader A_0)
    {
        try
        {
            this.f();
            this.b.Clear();
            int num = Convert.ToInt32(A_0.ReadLine(), CultureInfo.InvariantCulture);
            for (int i = 0; i < num; i++)
            {
                this.b.Add(A_0.ReadLine());
            }
            for (int j = 0; j < num; j++)
            {
                if (A_0.ReadLine() == "y")
                {
                    this.c(j);
                }
            }
            int num4 = Convert.ToInt32(A_0.ReadLine(), CultureInfo.InvariantCulture);
            for (int k = 0; k < num4; k++)
            {
                v v = new v(this);
                v.a(A_0);
                this.c(v);
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public void a(TextWriter A_0)
    {
        A_0.WriteLine(this.b.Count.ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
        foreach (string str in this.b)
        {
            A_0.WriteLine(str);
        }
        for (int i = 0; i < this.b.Count; i++)
        {
            if (this.c.ContainsKey(i))
            {
                A_0.WriteLine("y");
            }
            else
            {
                A_0.WriteLine("n");
            }
        }
        A_0.WriteLine(this.a.Count.ToString(), CultureInfo.InvariantCulture);
        foreach (v v in this.a)
        {
            v.a(A_0);
        }
    }

    public int a(string A_0)
    {
        return this.b.IndexOf(A_0);
    }

    public int a(v A_0)
    {
        int num = 0;
        foreach (v v in this.a)
        {
            if (v == A_0)
            {
                return num;
            }
            num++;
        }
        return -1;
    }

    public void a(a0 A_0, int A_1)
    {
        if (A_1 >= this.a())
        {
            throw new Exception("Invalid column number in MergeShallowOverwrite");
        }
        if (A_1 < 0)
        {
            throw new Exception("Invalid column number in MergeShallowOverwrite");
        }
        if (this.b.Count == A_0.b.Count)
        {
            bool flag = this.c.ContainsKey(A_1);
            if (!flag)
            {
                this.c(A_1);
            }
            foreach (v v in A_0.a)
            {
                v v2 = this.a(A_1, v[A_1]);
                if (v2 != null)
                {
                    for (int i = 0; i < v2.Count; i++)
                    {
                        if (i != A_1)
                        {
                            v2[i] = v[i];
                        }
                    }
                }
                else
                {
                    v2 = new v(this);
                    for (int j = 0; j < v2.Count; j++)
                    {
                        v2[j] = v[j];
                    }
                    this.c(v2);
                }
            }
            if (!flag)
            {
                this.d(A_1);
            }
        }
    }

    public v a(int A_0, k A_1)
    {
        if (A_0 >= this.a())
        {
            throw new Exception("Invalid column number in GetByField");
        }
        if (A_0 < 0)
        {
            throw new Exception("Invalid column number in GetByField");
        }
        if (this.c.ContainsKey(A_0))
        {
            if (this.c[A_0].c(A_1))
            {
                return this.c[A_0].a(A_1);
            }
            return null;
        }
        foreach (v v in this.a)
        {
            if (v[A_0].g(A_1) == 0)
            {
                return v;
            }
        }
        return null;
    }

    public void a(int A_0, int A_1)
    {
        if (A_0 < 0)
        {
            throw new ArgumentException("Index must be greater than zero.", "ind1");
        }
        if (A_1 < 0)
        {
            throw new ArgumentException("Index must be greater than zero.", "ind2");
        }
        if (A_0 >= this.a.Count)
        {
            throw new ArgumentException("Index must less than recordcount.", "ind1");
        }
        if (A_1 >= this.a.Count)
        {
            throw new ArgumentException("Index must less than recordcount.", "ind2");
        }
        v v = this.a[A_0];
        this.a[A_0] = this.a[A_1];
        this.a[A_1] = v;
    }

    public v a(string A_0, k A_1)
    {
        if (!this.b.Contains(A_0))
        {
            throw new Exception("Unknown column \"" + A_0 + "\"");
        }
        int index = this.b.IndexOf(A_0);
        return this.a(index, A_1);
    }

    public string b()
    {
        return "TABLE";
    }

    public bool b(int A_0)
    {
        if (A_0 >= this.a())
        {
            throw new Exception("Invalid column number in HasIndexOnColumn");
        }
        if (A_0 < 0)
        {
            throw new Exception("Invalid column number in HasIndexOnColumn");
        }
        return this.c.ContainsKey(A_0);
    }

    public void b(string A_0)
    {
        if (!this.b.Contains(A_0))
        {
            throw new Exception("Unknown column \"" + A_0 + "\"");
        }
        int index = this.b.IndexOf(A_0);
        this.c(index);
    }

    public bool b(v A_0)
    {
        bool flag = this.a.Remove(A_0);
        if (flag)
        {
            foreach (KeyValuePair<int, TypedHashtable<k, v>> pair in this.c)
            {
                if (pair.Value.c(A_0[pair.Key]))
                {
                    pair.Value.b(A_0[pair.Key]);
                }
            }
        }
        return flag;
    }

    public MyList<v> b(int A_0, k A_1)
    {
        if (A_0 >= this.a())
        {
            throw new Exception("Invalid column number in GetByField");
        }
        if (A_0 < 0)
        {
            throw new Exception("Invalid column number in GetByField");
        }
        MyList<v> list = new MyList<v>(80);
        foreach (v v in this.a)
        {
            if (v[A_0].g(A_1) == 0)
            {
                list.Add(v);
            }
        }
        return list;
    }

    public void b(string A_0, k A_1)
    {
        this.b.Add(A_0);
        foreach (v v in this.a)
        {
            v.Add(A_1);
        }
    }

    public int c()
    {
        return this.a.Count;
    }

    public void c(int A_0)
    {
        if (A_0 >= this.a())
        {
            throw new Exception("Invalid column number");
        }
        if (A_0 < 0)
        {
            throw new Exception("Invalid column number");
        }
        if (!this.c.ContainsKey(A_0))
        {
            this.c[A_0] = new TypedHashtable<k, v>();
            foreach (v v in this.a)
            {
                this.c[A_0].a(v[A_0], v);
            }
        }
    }

    public void c(string A_0)
    {
        if (!this.b.Contains(A_0))
        {
            throw new Exception("Unknown column \"" + A_0 + "\"");
        }
        int index = this.b.IndexOf(A_0);
        this.d(index);
    }

    public void c(v A_0)
    {
        if (A_0.a() != this)
        {
            throw new Exception("Attempted to add a record bound to the wrong table");
        }
        if (A_0.Count != this.a())
        {
            throw new Exception("Column count changed since record created");
        }
        this.a.Add(A_0);
        foreach (KeyValuePair<int, TypedHashtable<k, v>> pair in this.c)
        {
            pair.Value.a(A_0[pair.Key], A_0);
        }
    }

    public MyList<v> d()
    {
        MyList<v> list = new MyList<v>(0x4b);
        foreach (v v in this.a)
        {
            list.Add(v);
        }
        return list;
    }

    public void d(int A_0)
    {
        if (A_0 >= this.a())
        {
            throw new Exception("Invalid column number");
        }
        if (A_0 < 0)
        {
            throw new Exception("Invalid column number");
        }
        if (this.c.ContainsKey(A_0))
        {
            this.c.Remove(A_0);
        }
    }

    public MyList<string> e()
    {
        MyList<string> list = new MyList<string>(0x4c);
        foreach (string str in this.b)
        {
            list.Add(str);
        }
        return list;
    }

    public void e(int A_0)
    {
        if (A_0 < 0)
        {
            throw new Exception("Invalid removal index");
        }
        if (A_0 >= this.a.Count)
        {
            throw new Exception("Invalid removal index");
        }
        this.a.RemoveAt(A_0);
    }

    public void f()
    {
        this.a.Clear();
        this.c.Clear();
    }
}

