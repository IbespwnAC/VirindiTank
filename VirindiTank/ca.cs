using System;
using uTank2;

internal class ca : IDisposable
{
    private bool a;

    public ca(bv A_0, ei A_1)
    {
    }

    public void a()
    {
        if (!this.a)
        {
            this.a = true;
            GC.SuppressFinalize(this);
        }
    }

    public void a(int A_0, bool A_1)
    {
        if (PluginCore.cq.an.h() == A_0)
        {
            cv cv = PluginCore.cq.p.d(A_0);
            if (cv != null)
            {
                int num = PluginCore.cq.ax.get_Actions().get_Vital().get_Item(2);
                int num2 = PluginCore.cq.ax.get_Actions().get_Vital().get_Item(1);
                int num3 = PluginCore.cq.an.b();
                int num4 = ((int) Math.Ceiling((double) ((num2 * er.i("Recharge-Norm-HitP")) / 100.0))) - 1;
                if (((num != 0) && (num2 != 0)) && (num3 != 0))
                {
                    bool flag = true;
                    v v = PluginCore.cq.x.c["MonsterImmunities"].a(0, k.a(cv.g()));
                    if ((v != null) && ((k.e(v[1]) & 2) > 0))
                    {
                        flag = false;
                    }
                    MySpell spell = bq.a(num, num2, num4, num3, flag, A_1);
                    if (spell != null)
                    {
                        PluginCore.cq.g.a(spell, A_0);
                    }
                    else
                    {
                        PluginCore.cq.ak.Recharge(eRechargeVital_Single.Health);
                    }
                }
            }
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
}

