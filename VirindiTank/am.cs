using System;
using System.Collections.Generic;
using uTank2;
using uTank2.Logic;

internal class am : ILogicRule
{
    private int a;
    private string b;
    private bool c;
    private MyPair<int, int> d;
    private string e;

    public am(int A_0, string A_1)
    {
        this.a = A_0;
        this.b = A_1;
    }

    public void a()
    {
        if (!this.c)
        {
            this.c = true;
            GC.SuppressFinalize(this);
        }
    }

    protected override void e()
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

    public string uTank2.Logic.ILogicRule.FriendlyName
    {
        get
        {
            return "SplitPeas";
        }
    }

    public int uTank2.Logic.ILogicRule.Priority
    {
        get
        {
            return this.a;
        }
    }

    public bool uTank2.Logic.ILogicRule.Running
    {
        get
        {
            return (PluginCore.cq.y.c() != dr.b.a);
        }
        set
        {
            if (value)
            {
                PluginCore.cq.n.a("(SplitPeas) Running", e8.g);
                if (dh.d() != 1)
                {
                    dh.a(1);
                }
                else
                {
                    PluginCore.cq.y.a(this.d.a, this.d.b, this.e);
                }
            }
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            if (!PluginCore.cq.n.n.b(ActionLockType.ItemUse))
            {
                if (PluginCore.cq.y.c() != dr.b.a)
                {
                    return false;
                }
                if (!er.j("SplitPeas"))
                {
                    return false;
                }
                int num = er.i(this.b);
                bool flag = false;
                foreach (KeyValuePair<string, fz> pair in PluginCore.cq.l.h)
                {
                    if ((((fz) pair.Value) == fz.l) && pair.Key.Equals("[All Peas]"))
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    if (dh.e("Splitting Tool") == 0)
                    {
                        ai.a("Warning: No splitting tool found in inventory. Cannot split peas.");
                    }
                    foreach (v v in PluginCore.cq.x.c["CraftInteractions"].b(0, k.a("Splitting Tool")))
                    {
                        string str = k.b(v[1]);
                        string str2 = k.b(v[2]);
                        if (dh.a(str) != 0)
                        {
                            this.d = PluginCore.cq.y.a(str2, num);
                            this.e = str2;
                            if (this.d != null)
                            {
                                return true;
                            }
                        }
                    }
                }
                else
                {
                    foreach (KeyValuePair<string, fz> pair2 in PluginCore.cq.l.h)
                    {
                        if (((fz) pair2.Value) == fz.j)
                        {
                            if (dh.e("Splitting Tool") == 0)
                            {
                                ai.a("Warning: No splitting tool found in inventory. Cannot split peas.");
                            }
                            this.d = PluginCore.cq.y.a(pair2.Key, num);
                            this.e = pair2.Key;
                            if (this.d != null)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
}

