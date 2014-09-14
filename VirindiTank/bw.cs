using Decal.Adapter.Wrappers;
using MyClasses.MyWorldFilter;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using uTank2;

internal class bw : IDisposable
{
    public c a = new c();
    public int b;
    public bool c;
    private int d;
    private Dictionary<int, bw.a> e = new Dictionary<int, bw.a>();
    private bool f;

    public void a()
    {
        if (!this.f)
        {
            this.f = true;
            GC.SuppressFinalize(this);
        }
    }

    public bool a(double A_0)
    {
        bool flag = false;
        if (!dh.a(PluginCore.cq.n.c))
        {
            flag = true;
        }
        if (PluginCore.cq.n.f.ContainsKey(PluginCore.cq.n.c) && PluginCore.cq.n.f[PluginCore.cq.n.c].a)
        {
            flag = true;
        }
        if (!PluginCore.cq.p.i.ContainsKey(PluginCore.cq.n.c))
        {
            flag = true;
        }
        c c = new c();
        if (!flag)
        {
            this.b = 0;
            c = new c();
            c.a(PluginCore.cq.p.d(PluginCore.cq.n.c), A_0, er.h("AttackMinimumDistance"), er.j("TargetLock"));
            if (!c.m)
            {
                flag = true;
            }
        }
        if (!flag)
        {
            this.a = c;
            return true;
        }
        this.a = new c();
        ReadOnlyCollection<cv> onlys = PluginCore.cq.p.a(ObjectClass.Monster);
        MyList<c> list = new MyList<c>(0x65);
        double num = er.h("AttackMinimumDistance");
        bool flag2 = er.j("TargetLock");
        foreach (cv cv in onlys)
        {
            c item = new c();
            item.a(cv, A_0, num, flag2);
            if (item.m)
            {
                list.Add(item);
            }
        }
        list.Sort(new Comparison<c>(this.a));
        MyList<int> list2 = new MyList<int>(0x65);
        foreach (c c3 in list)
        {
            list2.Add(c3.b);
        }
        PluginCore.PC.a(list2);
        if (list.Count > 0)
        {
            PluginCore.cq.n.n.a(ActionLockType.SpreadLockTargetRequested, TimeSpan.FromSeconds(1.0));
        }
        else
        {
            PluginCore.cq.n.n.a(ActionLockType.SpreadLockTargetRequested);
        }
        return false;
    }

    private MySpell a(string A_0)
    {
        MySpell spell = PluginCore.cq.e.a(A_0);
        if (spell == null)
        {
            return null;
        }
        return this.a(spell);
    }

    private MySpell a(MySpell A_0)
    {
        if (A_0 == null)
        {
            return null;
        }
        if (this.e.ContainsKey(A_0.Id))
        {
            return this.e[A_0.Id].e.b;
        }
        bw.a a = new bw.a {
            e = new bw.b(bw.b.a.a)
        };
        bw.b b = new bw.b(bw.b.a.a) {
            b = PluginCore.cq.h.a(A_0)
        };
        if (b.b != null)
        {
            b.a = b.b.SkillWithSchool;
        }
        bw.b b2 = new bw.b(bw.b.a.b);
        foreach (int num in PluginCore.cq.j.e())
        {
            string str;
            if (PluginCore.cq.p.d(num) != null)
            {
                str = PluginCore.cq.p.d(num).g() + " [" + num.ToString() + "]";
            }
            else
            {
                str = num.ToString();
            }
            PluginCore.cq.n.a("Find debuff choice (" + str + "): Begin", e8.j);
            if (!dh.b(num) || (dh.c(num) != PluginCore.cg))
            {
                goto Label_03EA;
            }
            if (!fn.b(PluginCore.cq.aw.get_WorldFilter().get_Item(num)))
            {
                goto Label_03B9;
            }
            a1 a2 = PluginCore.cq.n.c(num);
            fn.a a3 = PluginCore.cq.n.d(num);
            if (((a2 != a1.c) && (a2 != a1.e)) && (((a2 != a1.f) && (a2 != a1.g)) && (a2 != a1.b)))
            {
                goto Label_0392;
            }
            if ((a2 != a1.b) || PluginCore.cq.z.a(num))
            {
                PluginCore.cq.n.a("Find debuff choice (" + str + "): Test 1 passed", e8.j);
                if (a3.g != null)
                {
                    PluginCore.cq.n.a("Find debuff choice (" + str + "): Test 2 passed", e8.j);
                    if (a3.g.RealFamily == A_0.RealFamily)
                    {
                        PluginCore.cq.n.a("Find debuff choice (" + str + "): Test 3 passed", e8.j);
                        if (b2.b != null)
                        {
                            PluginCore.cq.n.a("Find debuff choice (" + str + "): Test 4 passed", e8.j);
                            if (a3.g.Quality <= b2.b.Quality)
                            {
                                PluginCore.cq.n.a("Find debuff choice (" + str + "): Test 5 passed", e8.j);
                                if (a3.h <= b2.a)
                                {
                                    PluginCore.cq.n.a("Find debuff choice (" + str + "): Test 6 passed", e8.j);
                                    goto Label_036B;
                                }
                            }
                        }
                        b2.b = a3.g;
                        b2.a = a3.h;
                        a.d = num;
                        PluginCore.cq.n.a("Find debuff choice (" + str + "): Item set to be used, quality " + b2.a.ToString() + ".", e8.j);
                    }
                }
            }
        Label_036B:
            PluginCore.cq.n.a("Find debuff choice (" + str + "): Item tests done.", e8.j);
            continue;
        Label_0392:
            PluginCore.cq.n.a("Find debuff choice (" + str + "): Stop, wrong object type", e8.j);
            continue;
        Label_03B9:
            ai.a("Warning: DbT ignoring item " + PluginCore.cq.aw.get_WorldFilter().get_Item(num).get_Name() + " because it cannot currently be wielded.");
            continue;
        Label_03EA:
            PluginCore.cq.n.a("Find debuff choice (" + str + "): Stop, object invalid", e8.j);
        }
        bw.b b3 = new bw.b(bw.b.a.c);
        foreach (KeyValuePair<string, fz> pair in PluginCore.cq.l.h)
        {
            if (((fz) pair.Value) == fz.h)
            {
                bz bz = PluginCore.cq.x.d(pair.Key);
                if (bz == null)
                {
                    ai.a("Warning: DbT ignoring item " + pair.Key + " because it is not in the grenade database.");
                }
                else if (!fn.b(bz.b, bz.c, bz.d, bz.a))
                {
                    ai.a("Warning: DbT ignoring item " + bz.a + " because it cannot currently be wielded.");
                }
                else if (bz.e.RealFamily == A_0.RealFamily)
                {
                    bw.b b4 = new bw.b(bw.b.a.c) {
                        b = bz.e,
                        a = bz.f
                    };
                    if (b4.a(b3) > 0)
                    {
                        MyList<int> list2 = dh.d(pair.Key);
                        if (list2.Count > 0)
                        {
                            int num2 = 0x7fffffff;
                            int num3 = 0;
                            foreach (int num4 in list2)
                            {
                                int num5 = PluginCore.cq.aw.get_WorldFilter().get_Item(num4).Values(0xd000006);
                                if (num5 < num2)
                                {
                                    num3 = num4;
                                    num2 = num5;
                                }
                            }
                            if (num3 != 0)
                            {
                                a.b = null;
                                a.c = "";
                                a.a = num3;
                                b3 = b4;
                            }
                        }
                        else
                        {
                            MyPair<int, int> pair2 = PluginCore.cq.y.a(pair.Key, 1);
                            if (pair2 != null)
                            {
                                a.b = pair2;
                                a.c = pair.Key;
                                a.a = 0;
                                b3 = b4;
                            }
                        }
                    }
                }
            }
        }
        a.e = b;
        if (a.e.a(b2) < 0)
        {
            a.e = b2;
        }
        if (a.e.a(b3) < 0)
        {
            a.e = b3;
        }
        this.e[A_0.Id] = a;
        return a.e.b;
    }

    private int a(c A_0, c A_1)
    {
        if (A_0.f > A_1.f)
        {
            return 1;
        }
        if (A_1.f > A_0.f)
        {
            return -1;
        }
        if (A_0.e > A_1.e)
        {
            return 1;
        }
        if (A_1.e > A_0.e)
        {
            return -1;
        }
        return 0;
    }

    public int a(int A_0, c A_1)
    {
        if (!dh.a(A_0))
        {
            return 0;
        }
        MyQuad<int, eDamageElement, ePrismaticDamageBehavior, int> quad = A_1.a();
        int a = quad.a;
        eDamageElement b = quad.b;
        int num2 = 0;
        if (PluginCore.cq.i.a(A_0, PluginCore.cq.h.a(b, eCombatSpellType.Vuln)) > TimeSpan.Zero)
        {
            num2++;
        }
        CombatState state = 8;
        if (dh.b(a) && (dh.c(a) == PluginCore.cg))
        {
            state = PluginCore.cq.n.a(PluginCore.cq.aw.get_WorldFilter().get_Item(a).get_ObjectClass());
        }
        if (state != 8)
        {
            if (PluginCore.cq.i.a(A_0, PluginCore.cq.e.a("Imperil Other I")) > TimeSpan.Zero)
            {
                num2 += 2;
            }
            return num2;
        }
        if (PluginCore.cq.i.a(A_0, PluginCore.cq.e.a("Magic Yield Other I")) > TimeSpan.Zero)
        {
            num2 += 2;
        }
        return num2;
    }

    public bool a(int A_0, bool A_1)
    {
        ev cq = PluginCore.cq;
        if (!cq.n.f.ContainsKey(A_0))
        {
            return false;
        }
        if (!dh.a(A_0))
        {
            return false;
        }
        aj.c c = cq.d.a(PluginCore.cq.p.d(A_0));
        if (!A_1 && ((c.s && !c.i) && !c.r))
        {
            return false;
        }
        return true;
    }

    public bool a(string A_0, int A_1)
    {
        ev cq = PluginCore.cq;
        return this.a(cq.e.a(A_0), A_1);
    }

    private MySpell a(eDamageElement A_0, c A_1)
    {
        MySpell spell = PluginCore.cq.h.a(PluginCore.cq.h.a(A_0, eCombatSpellType.War));
        MySpell spell2 = PluginCore.cq.h.a(PluginCore.cq.h.a(A_0, eCombatSpellType.Arc));
        if ((spell == null) && (spell2 == null))
        {
            a5.a(eChatType.Errors, "Error: no usable attack spell detected for element \"" + er.a(A_0) + "\"");
            PluginCore.cq.c.StopMacro();
            return null;
        }
        if (spell == null)
        {
            return spell2;
        }
        if (spell2 != null)
        {
            if (spell.Quality > spell2.Quality)
            {
                return spell;
            }
            if (spell2.Quality > spell.Quality)
            {
                return spell2;
            }
            switch (er.e("UseArcs"))
            {
                case 1:
                    return spell;

                case 2:
                    if (A_1.e < er.h("ArcRange"))
                    {
                        return spell;
                    }
                    return spell2;

                case 3:
                    return spell2;
            }
        }
        return spell;
    }

    public bool a(MySpell A_0, int A_1)
    {
        if (A_0 != null)
        {
            ev cq = PluginCore.cq;
            MySpell spell = cq.h.a(A_0);
            if (spell != null)
            {
                l.g();
                cq.g.a(spell, A_1);
                return true;
            }
            a5.a(eChatType.Errors, "Error: no usable spell detected in the same class as \"" + A_0.Name + "\"");
        }
        return false;
    }

    private void a(string A_0, int A_1, int A_2)
    {
        MySpell spell = PluginCore.cq.e.a(A_0);
        if (spell != null)
        {
            this.a(spell, A_1, A_2);
        }
    }

    private void a(MySpell A_0, int A_1, int A_2)
    {
        if (!this.e.ContainsKey(A_0.Id))
        {
            throw new Exception("DebuffTarget: Uncached state detected.");
        }
        bw.a a = this.e[A_0.Id];
        if (a.e.b == null)
        {
            a5.a(eChatType.Errors, "Error: no way to apply a required debuff similar to \"" + A_0.Name + "\"");
            PluginCore.cq.c.StopMacro();
        }
        else
        {
            switch (a.e.c)
            {
                case bw.b.a.a:
                {
                    PluginCore.cq.v.d();
                    if (!er.j("SwitchWandsToDebuff"))
                    {
                        if (!PluginCore.cq.n.a(8, 0, true))
                        {
                            return;
                        }
                        break;
                    }
                    cv cv = PluginCore.cq.p.d(A_2);
                    if ((cv != null) && (PluginCore.cq.n.a(cv.c()) == 8))
                    {
                        if (PluginCore.cq.n.a(8, A_2, false))
                        {
                            break;
                        }
                        return;
                    }
                    if (PluginCore.cq.n.a(8, 0, true))
                    {
                        break;
                    }
                    return;
                }
                case bw.b.a.b:
                {
                    ObjectClass class2 = PluginCore.cq.aw.get_WorldFilter().get_Item(a.d).get_ObjectClass();
                    CombatState state = PluginCore.cq.n.a(class2);
                    if (state != 8)
                    {
                        if (!PluginCore.cq.n.a(state, a.d, false))
                        {
                            PluginCore.cq.v.d();
                            return;
                        }
                        float num = 0f;
                        if (state == 2)
                        {
                            num = 0f;
                        }
                        if (state == 4)
                        {
                            num = 1f;
                        }
                        PluginCore.cq.v.a(A_1, num, a.e.b);
                        return;
                    }
                    if (PluginCore.cq.n.a(state, a.d, false))
                    {
                        PluginCore.cq.z.a(a.d, A_1);
                        return;
                    }
                    return;
                }
                case bw.b.a.c:
                    if (a.b == null)
                    {
                        if (a.a != 0)
                        {
                            if (!PluginCore.cq.n.a(4, a.a, false))
                            {
                                return;
                            }
                            PluginCore.cq.v.a(A_1, 1f, a.e.b);
                        }
                        return;
                    }
                    if (dh.d() == 1)
                    {
                        PluginCore.cq.y.a(a.b.a, a.b.b, a.c);
                        return;
                    }
                    dh.a(1);
                    return;

                default:
                    return;
            }
            this.a(a.e.b, A_1);
        }
    }

    public void b()
    {
        ev cq = PluginCore.cq;
        if (this.a != null)
        {
            MyQuad<int, eDamageElement, ePrismaticDamageBehavior, int> quad = this.a.a();
            if (((eDamageElement) quad.b) == eDamageElement.Random)
            {
                quad.b = (eDamageElement) this.d;
                this.d++;
                if (this.d == 7)
                {
                    this.d = 0;
                }
            }
            bool flag = (this.a.b().b == eDamageElement.Fists) && PluginCore.cq.h.c(PluginCore.cq.e.a("Tusker Fists"));
            int num = quad.a;
            eDamageElement b = quad.b;
            TimeSpan span = TimeSpan.FromSeconds((double) er.i("DebuffPrecastSeconds"));
            float num2 = 1f;
            CombatState state = 8;
            if (dh.b(num) && (dh.c(num) == PluginCore.cg))
            {
                state = PluginCore.cq.n.a(PluginCore.cq.aw.get_WorldFilter().get_Item(num).get_ObjectClass());
                if (state == 2)
                {
                    fn.a a = PluginCore.cq.n.d(num);
                    if ((a.i == 1) && (PluginCore.cq.n.c(quad.d) != a1.c))
                    {
                        if ((b == eDamageElement.Slash) && a.d)
                        {
                            num2 = 0.5f;
                        }
                        else
                        {
                            num2 = 0f;
                        }
                    }
                    else if (((b == eDamageElement.Pierce) && a.d) && !a.f)
                    {
                        num2 = 0.2f;
                    }
                    else if (((b == eDamageElement.Pierce) && a.d) && (a.f && (PluginCore.cq.n.c(quad.d) == a1.c)))
                    {
                        num2 = 0.49f;
                    }
                    else if (((b == eDamageElement.Pierce) && a.d) && (a.f && (PluginCore.cq.n.c(quad.d) != a1.d)))
                    {
                        num2 = 0.2f;
                    }
                    else
                    {
                        num2 = 1f;
                    }
                }
            }
            if (er.j("UseRecklessness") && dh.b(eGameSkillID.Recklessness))
            {
                if (num2 < 0.11f)
                {
                    num2 = 0.11f;
                }
                if (num2 > 0.9f)
                {
                    num2 = 0.9f;
                }
            }
            bool flag2 = !cq.d.a(this.a.a).s;
            bool i = cq.d.a(this.a.a).i;
            bool r = cq.d.a(this.a.a).r;
            if (cq.d.a(this.a.a).h && (cq.i.a(this.a.b, this.a(cq.e.a("Magic Yield Other I"))) <= span))
            {
                this.a("Magic Yield Other I", this.a.b, num);
            }
            else if (cq.d.a(this.a.a).m && (cq.i.a(this.a.b, this.a(cq.e.a("Weakening Curse I"))) <= span))
            {
                this.a("Weakening Curse I", this.a.b, num);
            }
            else if (cq.d.a(this.a.a).n && (cq.i.a(this.a.b, this.a(cq.e.a("Festering Curse I"))) <= span))
            {
                this.a("Festering Curse I", this.a.b, num);
            }
            else if (cq.d.a(this.a.a).o && (cq.i.a(this.a.b, this.a(cq.e.a("Corruption I"))) <= TimeSpan.Zero))
            {
                this.a("Corruption I", this.a.b, num);
            }
            else if (cq.d.a(this.a.a).p && (cq.i.a(this.a.b, this.a(cq.e.a("Destructive Curse I"))) <= TimeSpan.Zero))
            {
                this.a("Destructive Curse I", this.a.b, num);
            }
            else if (cq.d.a(this.a.a).q && (cq.i.a(this.a.b, this.a(cq.e.a("Corrosion I"))) <= TimeSpan.Zero))
            {
                this.a("Corrosion I", this.a.b, num);
            }
            else if (cq.d.a(this.a.a).f && (cq.i.a(this.a.b, this.a(cq.e.a("Imperil Other I"))) <= span))
            {
                this.a("Imperil Other I", this.a.b, num);
            }
            else if (cq.d.a(this.a.a).g && (cq.i.a(this.a.b, this.a(cq.h.a(b, eCombatSpellType.Vuln))) <= span))
            {
                this.a(cq.h.a(b, eCombatSpellType.Vuln), this.a.b, num);
            }
            else if ((cq.d.a(this.a.a).c != eDamageElement.None) && (cq.i.a(this.a.b, this.a(cq.h.a(cq.d.a(this.a.a).c, eCombatSpellType.Vuln))) <= span))
            {
                this.a(cq.h.a(cq.d.a(this.a.a).c, eCombatSpellType.Vuln), this.a.b, num);
            }
            else if (cq.d.a(this.a.a).j && (cq.i.a(this.a.b, this.a(cq.e.a("Gravity Well"))) <= span))
            {
                this.a("Gravity Well", this.a.b, num);
            }
            else if (cq.d.a(this.a.a).k && (cq.i.a(this.a.b, this.a(cq.e.a("Broadside of a Barn"))) <= span))
            {
                this.a("Broadside of a Barn", this.a.b, num);
            }
            else if (cq.d.a(this.a.a).l && (cq.i.a(this.a.b, this.a(cq.e.a("Fester Other I"))) <= span))
            {
                this.a("Fester Other I", this.a.b, num);
            }
            else if (flag)
            {
                if (state != 8)
                {
                    PluginCore.cq.v.d();
                    if (!PluginCore.cq.n.a(8, 0, true))
                    {
                        return;
                    }
                }
                else
                {
                    PluginCore.cq.v.d();
                    if (!PluginCore.cq.n.a(8, num, false))
                    {
                        return;
                    }
                }
                cv cv = PluginCore.cq.p.d(PluginCore.cg);
                cv cv2 = this.a.a;
                if (cv != null)
                {
                    dz dz = cv.b(PluginCore.cq.ax.get_Actions());
                    dz w = cv2.w;
                    if (!PluginCore.cq.aq.a(dz.a(w) - 0.062831853071795868))
                    {
                        return;
                    }
                }
                this.a("Tusker Fists", this.a.b);
            }
            else if (state == 8)
            {
                PluginCore.cq.aq.b();
                PluginCore.cq.v.d();
                if (PluginCore.cq.n.a(8, num, false))
                {
                    if ((i && (this.b >= er.i("MinimumRingTargets"))) || ((i && !flag2) && (!r && (this.b > 0))))
                    {
                        if (b == eDamageElement.DrainAuto)
                        {
                            PluginCore.cq.ao.a(this.a.b, true);
                        }
                        else
                        {
                            MySpell spell = cq.h.a(b, eCombatSpellType.Ring);
                            if (spell.HasScarabsInInventory)
                            {
                                this.a(spell, this.a.b);
                            }
                            else
                            {
                                this.a(this.a(b, this.a), this.a.b);
                            }
                        }
                    }
                    else if ((flag2 && !r) || ((!flag2 && !r) && i))
                    {
                        if (b == eDamageElement.DrainAuto)
                        {
                            PluginCore.cq.ao.a(this.a.b, false);
                        }
                        else
                        {
                            this.a(this.a(b, this.a), this.a.b);
                        }
                    }
                    else if (!flag2 && r)
                    {
                        if (b == eDamageElement.DrainAuto)
                        {
                            PluginCore.cq.ao.a(this.a.b, false);
                        }
                        else
                        {
                            MySpell spell2 = PluginCore.cq.h.a(PluginCore.cq.h.a(b, eCombatSpellType.Streak));
                            if (spell2 != null)
                            {
                                this.a(spell2, this.a.b);
                            }
                            else
                            {
                                ai.a(string.Format("No streak spell usable for element '{0}', using bolt/arc instead.", er.a(b)));
                                this.a(this.a(b, this.a), this.a.b);
                            }
                        }
                    }
                    else if (flag2 && r)
                    {
                        MySpell spell3 = PluginCore.cq.h.a(PluginCore.cq.h.a(b, eCombatSpellType.Streak));
                        int num3 = 0;
                        if (spell3 != null)
                        {
                            if (PluginCore.cq.an.d() > 0)
                            {
                                num3 = PluginCore.cq.an.d() / 7;
                            }
                            else
                            {
                                num3 = spell3.Difficulty / 7;
                            }
                        }
                        bool flag5 = ((PluginCore.cq.an.h() == this.a.b) && (PluginCore.cq.an.b() > 0)) && (PluginCore.cq.an.b() < num3);
                        if (b == eDamageElement.DrainAuto)
                        {
                            PluginCore.cq.ao.a(this.a.b, false);
                        }
                        else if (flag5 && (spell3 != null))
                        {
                            this.a(spell3, this.a.b);
                        }
                        else
                        {
                            if (flag5)
                            {
                                ai.a(string.Format("No streak spell usable for element '{0}', using bolt/arc instead.", er.a(b)));
                            }
                            this.a(this.a(b, this.a), this.a.b);
                        }
                    }
                }
            }
            else
            {
                PluginCore.cq.aq.b();
                if (PluginCore.cq.n.a(state, num, false, b, quad.c, quad.d))
                {
                    PluginCore.cq.v.a(this.a.b, num2, null);
                }
            }
        }
    }

    public bool b(double A_0)
    {
        this.e.Clear();
        if (PluginCore.cq.l.f)
        {
            return this.a(A_0);
        }
        bool flag = er.b("DebuffEachFirst", "All") || er.b("DebuffEachFirst", "Priority");
        bool flag2 = er.b("DebuffEachFirst", "All");
        ev cq = PluginCore.cq;
        ReadOnlyCollection<cv> onlys = PluginCore.cq.p.a(ObjectClass.Monster);
        double num = er.h("AttackMinimumDistance");
        bool flag3 = er.j("TargetLock");
        this.a = new c();
        this.b = 0;
        int num2 = 0;
        double num3 = er.h("RingDistance");
        int num4 = er.e("TargetSelectMethod");
        double num5 = 0.0;
        if (num4 == 3)
        {
            num5 = er.h("TargetSelectAngleRange");
        }
        foreach (cv cv in onlys)
        {
            c c = new c();
            c.a(cv, A_0, num, flag3);
            if (!c.m)
            {
                continue;
            }
            num2++;
            if ((c.e < num3) && cq.d.a(cv).i)
            {
                this.b++;
            }
            if (!flag2)
            {
                if (c.d > this.a.d)
                {
                    goto Label_052A;
                }
                if (c.d >= this.a.d)
                {
                    goto Label_01CE;
                }
                continue;
            }
            if (c.h && !this.a.h)
            {
                goto Label_052A;
            }
            if (!c.h && this.a.h)
            {
                continue;
            }
            if (c.d > this.a.d)
            {
                goto Label_052A;
            }
            if (c.d < this.a.d)
            {
                continue;
            }
        Label_01CE:
            if (flag)
            {
                if (c.h && !this.a.h)
                {
                    goto Label_052A;
                }
                if (!c.h && this.a.h)
                {
                    continue;
                }
            }
            if (c.g > this.a.g)
            {
                goto Label_052A;
            }
            if (c.g >= this.a.g)
            {
                if (c.i && !this.a.i)
                {
                    goto Label_052A;
                }
                if (c.i || !this.a.i)
                {
                    if ((c.e < num5) && (this.a.e < num5))
                    {
                        MyQuad<int, eDamageElement, ePrismaticDamageBehavior, int> quad = c.a();
                        MyQuad<int, eDamageElement, ePrismaticDamageBehavior, int> quad2 = this.a.a();
                        int num6 = 0;
                        if (quad.a != PluginCore.cq.av.d())
                        {
                            num6++;
                        }
                        if (quad.d != PluginCore.cq.av.e())
                        {
                            num6++;
                        }
                        int num7 = 0;
                        if (quad2.a != PluginCore.cq.av.d())
                        {
                            num7++;
                        }
                        if (quad2.d != PluginCore.cq.av.e())
                        {
                            num7++;
                        }
                        if (num6 < num7)
                        {
                            goto Label_052A;
                        }
                        if (num6 > num7)
                        {
                            continue;
                        }
                    }
                    if (c.k && !this.a.k)
                    {
                        goto Label_052A;
                    }
                    if (c.k || !this.a.k)
                    {
                        switch (num4)
                        {
                            case 1:
                                if (c.e < this.a.e)
                                {
                                    goto Label_052A;
                                }
                                if (c.e <= this.a.e)
                                {
                                    if (c.f < this.a.f)
                                    {
                                        goto Label_052A;
                                    }
                                    if (c.f <= this.a.f)
                                    {
                                    }
                                }
                                break;

                            case 2:
                                if (c.f < this.a.f)
                                {
                                    goto Label_052A;
                                }
                                if (c.f <= this.a.f)
                                {
                                    if (c.e < this.a.e)
                                    {
                                        goto Label_052A;
                                    }
                                    if (c.e <= this.a.e)
                                    {
                                    }
                                }
                                break;

                            case 3:
                                goto Label_0379;
                        }
                    }
                }
            }
            continue;
        Label_0379:
            if ((c.e >= num5) || (this.a.e <= num5))
            {
                if ((c.e > num5) && (this.a.e < num5))
                {
                    continue;
                }
                if (c.e < num5)
                {
                    if (c.f < this.a.f)
                    {
                        goto Label_052A;
                    }
                    if (c.f <= this.a.f)
                    {
                        if (c.e < this.a.e)
                        {
                            goto Label_052A;
                        }
                        if (c.e <= this.a.e)
                        {
                        }
                    }
                    continue;
                }
                if (c.e >= this.a.e)
                {
                    if (c.e > this.a.e)
                    {
                        continue;
                    }
                    if (c.f >= this.a.f)
                    {
                        if (c.f <= this.a.f)
                        {
                        }
                        continue;
                    }
                }
            }
        Label_052A:
            this.a = c;
        }
        PluginCore.cq.n.d = this.a.b;
        PluginCore.cq.an.b(this.a.b);
        l.c(num2);
        l.b(this.b);
        l.a(onlys.Count);
        return (this.a.b != 0);
    }

    public bool b(int A_0, c A_1)
    {
        ev cq = PluginCore.cq;
        if (!cq.n.f.ContainsKey(A_0))
        {
            return false;
        }
        if (!dh.a(A_0))
        {
            return false;
        }
        cf local1 = cq.n.f[A_0];
        aj.c c = cq.d.a(PluginCore.cq.p.d(A_0));
        MyQuad<int, eDamageElement, ePrismaticDamageBehavior, int> quad = null;
        if (c.g)
        {
            quad = A_1.a();
        }
        TimeSpan span = TimeSpan.FromSeconds((double) er.i("DebuffPrecastSeconds"));
        if (((((!c.h || (cq.i.a(A_0, this.a("Magic Yield Other I")) > span)) && (!c.m || (cq.i.a(A_0, this.a("Weakening Curse I")) > span))) && ((!c.f || (cq.i.a(A_0, this.a("Imperil Other I")) > span)) && (!c.j || (cq.i.a(A_0, this.a("Gravity Well")) > span)))) && (((!c.k || (cq.i.a(A_0, this.a("Broadside of a Barn")) > span)) && (!c.l || (cq.i.a(A_0, this.a("Fester Other I")) > span))) && ((!c.n || (cq.i.a(A_0, this.a("Festering Curse I")) > span)) && (!c.o || (cq.i.a(A_0, this.a("Corruption I")) > TimeSpan.Zero))))) && (((!c.p || (cq.i.a(A_0, this.a("Destructive Curse I")) > TimeSpan.Zero)) && (!c.q || (cq.i.a(A_0, this.a("Corrosion I")) > TimeSpan.Zero))) && ((!c.g || (cq.i.a(A_0, this.a(cq.h.a(quad.b, eCombatSpellType.Vuln))) > span)) && ((c.c == eDamageElement.None) || (cq.i.a(A_0, this.a(cq.h.a(c.c, eCombatSpellType.Vuln))) > span)))))
        {
            return false;
        }
        return true;
    }

    public bool c()
    {
        return this.b(er.h("AttackDistance"));
    }

    public class a
    {
        public int a;
        public MyPair<int, int> b;
        public string c = "";
        public int d;
        public bw.b e;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct b : IComparable<bw.b>
    {
        public int a;
        public MySpell b;
        public bw.b.a c;
        public b(bw.b.a A_0)
        {
            this.c = A_0;
            this.a = 0;
            this.b = null;
        }

        public int a(bw.b A_0)
        {
            if (this.b == null)
            {
                return -1;
            }
            if (A_0.b == null)
            {
                return 1;
            }
            if (er.b("DebuffSelectionMethod", "SpellLevel"))
            {
                if (this.b.Quality > A_0.b.Quality)
                {
                    return 1;
                }
                if (this.b.Quality < A_0.b.Quality)
                {
                    return -1;
                }
                if (this.a > A_0.a)
                {
                    return 1;
                }
                if (this.a < A_0.a)
                {
                    return -1;
                }
            }
            else if (er.b("DebuffSelectionMethod", "Skill"))
            {
                if (this.a > A_0.a)
                {
                    return 1;
                }
                if (this.a < A_0.a)
                {
                    return -1;
                }
                if (this.b.Quality > A_0.b.Quality)
                {
                    return 1;
                }
                if (this.b.Quality < A_0.b.Quality)
                {
                    return -1;
                }
            }
            if (this.c == bw.b.a.a)
            {
                return 1;
            }
            if (A_0.c == bw.b.a.a)
            {
                return -1;
            }
            return 0;
        }
        public enum a
        {
            a,
            b,
            c
        }
    }
}

