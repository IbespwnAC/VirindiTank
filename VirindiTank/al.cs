using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using uTank2;
using uTank2.Logic;

internal class al : ILogicRule
{
    private int a;
    private cj b;
    private int c;
    private int d;
    private int e;

    public al(int A_0)
    {
        this.a = A_0;
        this.b = PluginCore.cq.p;
        this.b.c(new cj.c(this.a));
    }

    private int a()
    {
        foreach (KeyValuePair<string, fz> pair in PluginCore.cq.l.h)
        {
            if (((fz) pair.Value) == fz.k)
            {
                ReadOnlyCollection<cv> onlys = PluginCore.cq.p.a(pair.Key);
                int num = 0x7fffffff;
                int k = 0;
                foreach (cv cv in onlys)
                {
                    if (PluginCore.cq.p.a(cv.k, PluginCore.cq.ax))
                    {
                        int num3 = cv.a(dt.aa, 0);
                        if (num3 < num)
                        {
                            num = num3;
                            k = cv.k;
                        }
                    }
                }
                if (k != 0)
                {
                    return k;
                }
            }
        }
        return 0;
    }

    private void a(cv A_0)
    {
        if (A_0.k == this.d)
        {
            A_0.a(PluginCore.cq.ax.get_Actions());
            if (A_0.l)
            {
                this.d = 0;
                PluginCore.cq.n.n.a(ActionLockType.ItemUse);
                PluginCore.cq.n.n.a(ActionLockType.DoorOpening);
            }
        }
    }

    public void b()
    {
        this.b.h(new cj.c(this.a));
    }

    public string uTank2.Logic.ILogicRule.FriendlyName
    {
        get
        {
            return "OpenDoor";
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
            return false;
        }
        set
        {
            if (value && (this.c != 0))
            {
                if (this.e == 0)
                {
                    this.d = this.c;
                    PluginCore.cq.n.n.a(ActionLockType.ItemUse, TimeSpan.FromSeconds(0.5));
                    PluginCore.cq.n.n.a(ActionLockType.Navigation, TimeSpan.FromSeconds(5.0));
                    PluginCore.cq.n.n.a(ActionLockType.DoorOpening, TimeSpan.FromSeconds(5.0));
                    PluginCore.cq.ax.get_Actions().UseItem(this.c, 0);
                }
                else
                {
                    PluginCore.cq.n.n.a(ActionLockType.ItemUse, TimeSpan.FromSeconds(0.5));
                    PluginCore.cq.n.n.a(ActionLockType.Navigation, TimeSpan.FromSeconds(1.0));
                    PluginCore.cq.ax.get_Actions().ApplyItem(this.e, this.c);
                }
            }
        }
    }

    public bool uTank2.Logic.ILogicRule.ValidNow
    {
        get
        {
            this.c = 0;
            this.e = 0;
            if (er.j("OpenDoors"))
            {
                if (!er.j("EnableNav"))
                {
                    return false;
                }
                ReadOnlyCollection<cv> onlys = PluginCore.cq.p.a(ObjectClass.Door);
                foreach (cv cv in onlys)
                {
                    if (((((cv.a(dt.dm, 1) & 1) <= 0) && !cv.j) && (!PluginCore.cq.u.b(cv.k) && PluginCore.cq.p.a(cv.k, PluginCore.cq.ax))) && (dh.a(dh.a(PluginCore.cg, PluginCore.cq.ax.get_Actions()), dh.a(cv.k, PluginCore.cq.ax.get_Actions()), true) <= er.h("DoorIDRange")))
                    {
                        PluginCore.cq.u.a(cv.k, b0.a.d);
                    }
                }
                if (PluginCore.cq.u.c(b0.a.d))
                {
                    PluginCore.cq.n.n.a(ActionLockType.Navigation, TimeSpan.FromSeconds(0.5));
                    return false;
                }
                if (PluginCore.cq.u.c(b0.a.c) && er.j("EnableLooting"))
                {
                    return false;
                }
                if (PluginCore.cq.n.n.b(ActionLockType.Navigation))
                {
                    return false;
                }
                if (PluginCore.cq.n.n.b(ActionLockType.ItemUse))
                {
                    return false;
                }
                if (PluginCore.cq.n.n.b(ActionLockType.DoorOpening))
                {
                    return false;
                }
                if (PluginCore.cq.n.n.b(ActionLockType.SpreadLockTargetRequested))
                {
                    return false;
                }
                bool flag = false;
                int num = 0;
                foreach (cv cv2 in onlys)
                {
                    if (((cv2.a(dt.dm, 1) & 1) <= 0) && cv2.j)
                    {
                        cv2.a(PluginCore.cq.ax.get_Actions());
                        if ((!cv2.l && PluginCore.cq.p.a(cv2.k, PluginCore.cq.ax)) && (dh.a(dh.a(PluginCore.cg, PluginCore.cq.ax.get_Actions()), dh.a(cv2.k, PluginCore.cq.ax.get_Actions()), true) <= er.h("DoorOpenRange")))
                        {
                            if (cv2.a(ds.c, false))
                            {
                                if (dh.b(eGameSkillID.Lockpick))
                                {
                                    if (PluginCore.cq.ax.get_Actions().get_Skill().get_Item(0x17) >= (cv2.a(dt.q, 0) + er.i("DoorLockpickDiffExcessThreshold")))
                                    {
                                        if (!flag)
                                        {
                                            flag = true;
                                            num = this.a();
                                        }
                                        if (num != 0)
                                        {
                                            this.e = num;
                                            this.c = cv2.k;
                                            return true;
                                        }
                                        ai.a("No usable lockpicks found, ignoring door \"" + cv2.g() + "\" (" + cv2.k.ToString() + ").");
                                    }
                                    else
                                    {
                                        ai.a("Door \"" + cv2.g() + "\" (" + cv2.k.ToString() + ") is too difficult to pick. Ignoring.");
                                    }
                                }
                                else
                                {
                                    ai.a("Door \"" + cv2.g() + "\" (" + cv2.k.ToString() + ") is locked and you don't have lockpick. Ignoring.");
                                }
                            }
                            else
                            {
                                this.c = cv2.k;
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

