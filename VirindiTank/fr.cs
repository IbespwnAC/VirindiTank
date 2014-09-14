using System;
using System.Collections.Generic;
using uTank2;

internal class fr : IDisposable
{
    private e3 a = new e3();
    private Dictionary<int, int> b = new Dictionary<int, int>();
    private bool c;

    public fr()
    {
        this.a.a(0x476f);
        this.a.a(new EventHandler(this.a));
        this.a.d();
    }

    public void a()
    {
        if (!this.c)
        {
            this.c = true;
            GC.SuppressFinalize(this);
            if (this.a != null)
            {
                this.a.e();
                this.a = null;
            }
        }
    }

    public void a(int A_0)
    {
        if (this.b.ContainsKey(A_0))
        {
            this.b.Remove(A_0);
        }
    }

    private void a(object A_0, EventArgs A_1)
    {
        List<int> list = new List<int>();
        foreach (KeyValuePair<int, int> pair in this.b)
        {
            if (!PluginCore.cq.ax.get_Actions().IsValidObject(pair.Key))
            {
                list.Add(pair.Key);
            }
        }
        foreach (int num in list)
        {
            this.b.Remove(num);
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

    public void b(int A_0)
    {
        if (this.b.ContainsKey(A_0))
        {
            Dictionary<int, int> dictionary;
            int num2;
            (dictionary = this.b)[num2 = A_0] = dictionary[num2] + 1;
        }
        else
        {
            this.b[A_0] = 1;
        }
        if (this.b[A_0] > er.i("BlacklistMonsterAttemptCount"))
        {
            if (PluginCore.cq.n.f.ContainsKey(A_0))
            {
                string str = "???";
                cv cv = PluginCore.cq.p.d(A_0);
                if (cv != null)
                {
                    str = cv.g();
                }
                int num = er.i("BlacklistMonsterTimeoutSeconds");
                PluginCore.e("Blacklisting unhittable monster " + str + " (" + A_0.ToString() + ") for " + num.ToString() + " seconds.");
                PluginCore.cq.n.f[A_0].a(TimeSpan.FromSeconds((double) num));
            }
            this.b.Remove(A_0);
        }
    }
}

