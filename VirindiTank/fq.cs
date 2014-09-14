using System;
using System.Collections.Generic;
using System.Reflection;
using uTank2;

[DefaultMember("Item")]
internal class fq : IDisposable
{
    private MyDictionary<u, e2> a = new MyDictionary<u, e2>(0x33);
    public int b = r.a();
    private bool c;

    public void a()
    {
        if (!this.c)
        {
            this.c = true;
            GC.SuppressFinalize(this);
            this.b();
            this.a = null;
        }
    }

    public bool a(u A_0)
    {
        return (this.a.ContainsKey(A_0) && this.a[A_0].a());
    }

    public void a(u A_0, bool A_1)
    {
        if (this.a.ContainsKey(A_0))
        {
            this.a[A_0].a(A_1);
        }
        else if (A_1)
        {
            this.a.Add(A_0, new e2(A_0, this.b));
            this.a[A_0].a(A_1);
        }
    }

    public void b()
    {
        foreach (KeyValuePair<u, e2> pair in this.a)
        {
            pair.Value.a(false);
        }
    }

    public void b(u A_0, bool A_1)
    {
        this.a(A_0, A_1);
    }
}

