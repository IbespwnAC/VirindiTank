using MyClasses.MyWorldFilter;
using System;
using System.Collections.ObjectModel;
using uTank2;
using uTank2.Logic;

internal class dd : ILogicRule
{
    private ev a = PluginCore.cq;
    private int b;
    private bool c;
    private MyList<int> d = new MyList<int>(0x2e);
    private int e;
    private Random f = new Random();
    private MySpell g;

    public dd(int A_0)
    {
        this.b = A_0;
        this.d.Add(this.a.e.a("Endurance Other I").Id);
        this.d.Add(this.a.e.a("Regeneration Other I").Id);
        this.d.Add(this.a.e.a("Rejuvenation Other I").Id);
        this.d.Add(this.a.e.a("Armor Other I").Id);
        this.d.Add(this.a.e.a("Blade Protection Other I").Id);
        this.d.Add(this.a.e.a("Bludgeoning Protection Other I").Id);
        this.d.Add(this.a.e.a("Cold Protection Other I").Id);
        this.d.Add(this.a.e.a("Fire Protection Other I").Id);
        this.d.Add(this.a.e.a("Lightning Protection Other I").Id);
        this.d.Add(this.a.e.a("Piercing Protection Other I").Id);
        this.d.Add(this.a.e.a("Acid Protection Other I").Id);
    }

    public void a()
    {
        if (!this.c)
        {
            this.c = true;
            GC.SuppressFinalize(this);
            this.a = null;
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
            return "RandomHelper";
        }
    }

    public int uTank2.Logic.ILogicRule.Priority
    {
        get
        {
            return this.b;
        }
    }

    public bool uTank2.Logic.ILogicRule.Running
    {
        get
        {
            return false;
        }
        set
        {
            if (value)
            {
                PluginCore.cq.n.a("(RandomHelper) Running", e8.g);
                if (PluginCore.cq.n.a(8, 0, true) && (this.g != null))
                {
                    this.a.n.n.a(ActionLockType.RandomHelperBuffLock, TimeSpan.FromSeconds(er.h("RandomHelperIntervalSeconds")));
                    this.a.g.a(this.g, this.e);
                }
            }
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            if (er.j("RandomHelperBuffs"))
            {
                if (this.a.n.n.b(ActionLockType.ItemUse))
                {
                    return false;
                }
                if (this.a.n.n.b(ActionLockType.RandomHelperBuffLock))
                {
                    return false;
                }
                if (this.a.g.e())
                {
                    return false;
                }
                ReadOnlyCollection<cv> onlys = PluginCore.cq.p.a(ObjectClass.Player);
                MyList<cv> list = new MyList<cv>(0x2f);
                foreach (cv cv in onlys)
                {
                    if ((cv.k != PluginCore.cg) && (dh.a(cv.k, PluginCore.cg, true) < 0.075))
                    {
                        list.Add(cv);
                    }
                }
                if (list.Count == 0)
                {
                    return false;
                }
                int num = this.f.Next(list.Count);
                this.e = list[num].k;
                for (int i = 0; i < 100; i++)
                {
                    int num3 = this.f.Next(this.d.Count);
                    this.g = this.a.h.a(this.d[num3], false);
                    if (this.g == null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}

