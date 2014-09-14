using System;
using System.IO;
using System.Reflection;
using uTank2;

[DefaultMember("Item")]
internal class v : MyList<k>
{
    private a0 a;

    public v(a0 A_0) : base(0x51)
    {
        this.a = A_0;
        for (int i = 0; i < A_0.a(); i++)
        {
            base.Add(new k());
        }
    }

    public a0 a()
    {
        return this.a;
    }

    public void a(TextReader A_0)
    {
        for (int i = 0; i < base.Count; i++)
        {
            base[i].a(A_0);
        }
    }

    public void a(TextWriter A_0)
    {
        foreach (k k in this)
        {
            k.a(A_0);
        }
    }

    public k a(string A_0)
    {
        return base[this.a.a(A_0)];
    }

    public void a(string A_0, k A_1)
    {
        base[this.a.a(A_0)] = A_1;
    }
}

