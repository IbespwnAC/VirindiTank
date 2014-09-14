using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using uTank2;

internal class ay : IDisposable
{
    private cj a;
    private List<int> b = new List<int>();
    private e3 c = new e3();
    private List<string> d = new List<string>();
    private bool e;

    public ay(cj A_0)
    {
        this.a = A_0;
        this.a.g(new cj.c(this.a));
        this.a.f(new cj.c(this.b));
        this.c.a(10);
        this.c.a(new EventHandler(this.a));
    }

    public void a()
    {
        if (!this.e)
        {
            this.e = true;
            GC.SuppressFinalize(this);
            if (this.c != null)
            {
                this.c.e();
                this.c = null;
            }
            this.a.b(new cj.c(this.b));
            this.a.a(new cj.c(this.a));
            this.a = null;
        }
    }

    private void a(cv A_0)
    {
        if (((A_0.k != 0) && (A_0.k != PluginCore.cg)) && (A_0.c() == ObjectClass.Monster))
        {
            foreach (cv cv in this.a.e(A_0.k))
            {
                if (!this.b.Contains(cv.k))
                {
                    this.b.Add(cv.k);
                    this.d.Add(cv.g());
                    if (!this.c.g())
                    {
                        this.c.a(true);
                    }
                }
            }
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        if (this.b.Count > 0)
        {
            int num = this.b[0];
            string local1 = this.d[0];
            this.b.RemoveAt(0);
            this.d.RemoveAt(0);
            if (num != PluginCore.cg)
            {
                dh.d(num);
            }
        }
        else
        {
            this.c.a(false);
        }
    }

    protected override void b()
    {
        try
        {
            this.a();
        }
        finally
        {
            base.Finalize();
        }
    }

    private void b(cv A_0)
    {
        if (this.b.Contains(A_0.k))
        {
            this.b.Remove(A_0.k);
        }
    }
}

