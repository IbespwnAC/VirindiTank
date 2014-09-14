using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using uTank2;

internal class q : IDisposable
{
    private e3 a = new e3();
    private Dictionary<int, int> b = new Dictionary<int, int>();
    private bool c;

    public q()
    {
        this.a.a(0x187f);
        this.a.a(new EventHandler(this.a));
        PluginCore.PC.b(new PluginCore.EmptyDelegate(this.b));
    }

    private void a()
    {
        if ((er.j("DeleteGhostMonstersByHPTracker") && PluginCore.cq.n.b) && (PluginCore.cq.an.h() != 0))
        {
            cv cv = PluginCore.cq.p.d(PluginCore.cq.an.h());
            if (cv != null)
            {
                string str = cv.g();
                if (PluginCore.cq.x.e(str) > 0)
                {
                    TimeSpan span = (TimeSpan) (DateTimeOffset.Now - PluginCore.cq.an.g());
                    if (span.TotalSeconds >= er.i("GhostDeleteHPTrackerSeconds"))
                    {
                        TimeSpan span2 = (TimeSpan) (DateTimeOffset.Now - PluginCore.cq.an.e());
                        if (span2.TotalSeconds >= er.i("GhostDeleteHPTrackerSeconds"))
                        {
                            int num = PluginCore.cq.an.h();
                            cv cv2 = PluginCore.cq.p.d(num);
                            if ((cv2 != null) && (cv2.c() == ObjectClass.Monster))
                            {
                                PluginCore.e("Deleting ghost monster " + cv2.g() + " (" + num.ToString() + ") due to HP tracker notification.");
                                dh.d(num);
                            }
                        }
                    }
                }
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
        this.a();
    }

    private void b()
    {
        this.a.a(true);
    }

    public void b(int A_0)
    {
        if (this.b.ContainsKey(A_0))
        {
            Dictionary<int, int> dictionary;
            int num;
            (dictionary = this.b)[num = A_0] = dictionary[num] + 1;
        }
        else
        {
            this.b[A_0] = 1;
        }
        if (this.b[A_0] > er.i("GhostMonsterSpellAttemptCount"))
        {
            cv cv = PluginCore.cq.p.d(A_0);
            if (((cv != null) && (cv.c() == ObjectClass.Monster)) && er.j("DeleteGhostMonsters"))
            {
                PluginCore.e("Deleting ghost monster " + cv.g() + " (" + A_0.ToString() + ")");
                dh.d(A_0);
            }
            this.b.Remove(A_0);
        }
    }

    public void c()
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
            PluginCore.PC.a(new PluginCore.EmptyDelegate(this.b));
        }
    }

    protected override void d()
    {
        try
        {
            this.c();
        }
        finally
        {
            base.Finalize();
        }
    }
}

