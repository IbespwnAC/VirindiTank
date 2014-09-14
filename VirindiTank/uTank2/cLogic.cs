namespace uTank2
{
    using Decal.Adapter;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using uTank2.Logic;

    public class cLogic : IDisposable
    {
        private const int a = 0x125;
        private const int b = 0xc83;
        private PluginCore c;
        private DateTimeOffset d = DateTimeOffset.MinValue;
        private DateTimeOffset e = DateTimeOffset.MinValue;
        private e3 f;
        private e3 g;
        private ILogicRule h;
        private bool i;
        private ulong j;
        private bool k;
        private MyList<ILogicRule> l = new MyList<ILogicRule>(0x48);
        private MyList<ILogicRule> m = new MyList<ILogicRule>(0x66);
        private MyList<ILogicRule> n = new MyList<ILogicRule>(0x270f);

        internal cLogic(dv A_0, PluginCore A_1, s A_2)
        {
            this.c = A_1;
            this.f = new e3();
            A_0.a(new dv.b(this.a));
            A_0.b(new dv.a(this.a));
            A_2.a(new s.a(this.a));
            A_2.b(new s.c(this.a));
            this.f.a(new EventHandler(this.b));
            this.g = new e3();
            this.g.a(new EventHandler(this.a));
            this.g.a(0xc83);
            PluginCore.PC.b(new PluginCore.EmptyDelegate(this.a));
        }

        private void a()
        {
            this.g.d();
        }

        private void a(dv.d A_0)
        {
            if (A_0 == dv.d.a)
            {
                this.SchedulePoke();
            }
        }

        private void a(s.b A_0)
        {
            if (A_0 == s.b.a)
            {
                this.SchedulePoke();
            }
        }

        private void a(object A_0, ChatTextInterceptEventArgs A_1)
        {
        }

        private void a(object A_0, EventArgs A_1)
        {
            if (!PluginCore.cq.n.b)
            {
                this.a(this.m, null);
            }
        }

        private void a(MyList<ILogicRule> A_0, MyList<ILogicRule> A_1)
        {
            try
            {
                if (!PluginCore.cq.n.k)
                {
                    fj.b("!!!! Evaluate Meta Rules");
                    if (PluginCore.cq.n.b && er.j("EnableMeta"))
                    {
                        PluginCore.cq.@as.e();
                        a2.e();
                    }
                    fj.a("!!!! Evaluate Meta Rules", 20.0);
                }
                if (A_1 != null)
                {
                    fj.b("!!!! Evaluate Always Rules");
                    foreach (ILogicRule rule in A_1)
                    {
                        if (rule.ValidNow)
                        {
                            rule.Running = true;
                        }
                        else
                        {
                            rule.Running = false;
                        }
                    }
                    fj.a("!!!! Evaluate Always Rules", 20.0);
                }
                if (PluginCore.cq.n.k)
                {
                    return;
                }
                PluginCore.cq.n.a("----------- Primary logic loop started (" + A_0.Count.ToString() + " rules) -----------", e8.b);
                fj.b("Primary logic loop");
                ILogicRule rule2 = null;
                fj.b("!!!! Logic loop - find valid rule");
                foreach (ILogicRule rule3 in A_0)
                {
                    string str = "!!!! Logic loop - validnow - " + rule3.FriendlyName;
                    fj.b(str);
                    bool validNow = rule3.ValidNow;
                    fj.a(str, 20.0);
                    if (validNow)
                    {
                        PluginCore.cq.n.a("Picked " + rule3.FriendlyName + " P: " + rule3.Priority.ToString() + "   I=" + PluginCore.cq.n.n.b(ActionLockType.ItemUse).ToString() + ", N=" + PluginCore.cq.n.n.b(ActionLockType.Navigation).ToString() + ", S=" + PluginCore.cq.n.n.b(ActionLockType.Salvage).ToString(), e8.b);
                        rule2 = rule3;
                        PluginCore.cq.n.q = rule3.Priority;
                        goto Label_031D;
                    }
                }
                PluginCore.cq.n.a("All rules inactive.   I=" + PluginCore.cq.n.n.b(ActionLockType.ItemUse).ToString() + ", N=" + PluginCore.cq.n.n.b(ActionLockType.Navigation).ToString() + ", S=" + PluginCore.cq.n.n.b(ActionLockType.Salvage).ToString(), e8.b);
                PluginCore.cq.n.q = 0;
            Label_031D:
                fj.a("!!!! Logic loop - find valid rule", 20.0);
                fj.b("!!!! Logic loop - clear rules");
                foreach (ILogicRule rule4 in A_0)
                {
                    if (rule4 != rule2)
                    {
                        rule4.Running = false;
                    }
                }
                fj.a("!!!! Logic loop - clear rules", 20.0);
                if (rule2 != null)
                {
                    string str2 = "!!!! Logic loop - activate rule " + rule2.FriendlyName;
                    fj.b(str2);
                    rule2.Running = true;
                    fj.a(str2, 20.0);
                }
                this.h = rule2;
                l.a(rule2);
                fj.a("Primary logic loop");
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
            finally
            {
                DateTimeOffset now = DateTimeOffset.Now;
                TimeSpan span = (TimeSpan) (now - this.d);
                if (span.TotalSeconds > 30.0)
                {
                    this.d = now;
                    string str3 = "!!!! Logic finally - forcegc F";
                    fj.b(str3);
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    fj.a(str3, 80.0);
                }
            }
        }

        private void a(MySpell A_0, int A_1, bool A_2, bool A_3)
        {
            PluginCore.cq.ap.c();
            if (A_2 && PluginCore.cq.n.f.ContainsKey(A_1))
            {
                PluginCore.cq.n.f[A_1].a = true;
                PluginCore.PC.f(A_1);
            }
            if (A_3)
            {
                if (er.j("EnableLooting"))
                {
                    PluginCore.cq.n.n.a(ActionLockType.Navigation, TimeSpan.FromSeconds(3.0));
                }
                l.f();
            }
        }

        public void AddLogicRule(ILogicRule lr)
        {
            this.l.Add(lr);
        }

        public void AddLogicRule(int pPos, ILogicRule lr)
        {
            this.l.Insert(pPos, lr);
        }

        public void AddLogicRule_MacroDisabled(ILogicRule lr)
        {
            this.m.Add(lr);
        }

        public void AddLogicRule_MacroDisabled(int pPos, ILogicRule lr)
        {
            this.m.Insert(pPos, lr);
        }

        public bool AddLogicRuleAfterSentinel(ILogicRule lr, string sentmarker)
        {
            for (int i = 0; i < this.l.Count; i++)
            {
                LogicRuleSentinel sentinel = this.l[i] as LogicRuleSentinel;
                if ((sentinel != null) && (sentinel.Marker == sentmarker))
                {
                    this.l.Insert(i + 1, lr);
                    return true;
                }
            }
            return false;
        }

        private void b(object A_0, EventArgs A_1)
        {
            try
            {
                this.f.a(0x125);
                this.TryPokeMacro();
            }
            catch (Exception exception)
            {
                ad.a(exception);
            }
        }

        public void ClearLogicRules()
        {
            this.l.Clear();
        }

        public void ClearLogicRules_MacroDisabled()
        {
            this.m.Clear();
        }

        public void Dispose()
        {
            if (!this.i)
            {
                this.i = true;
                this.f.b(new EventHandler(this.b));
                if (this.f != null)
                {
                    this.f.e();
                }
                this.f = null;
                if (this.g != null)
                {
                    this.g.e();
                }
                this.g = null;
                this.c = null;
                foreach (ILogicRule rule in this.l)
                {
                    rule.Dispose();
                }
                GC.SuppressFinalize(this);
            }
        }

        ~cLogic()
        {
            this.Dispose();
        }

        public ReadOnlyCollection<ILogicRule> GetLogicRules()
        {
            return this.l.AsReadOnly();
        }

        public ReadOnlyCollection<string> GetLogicSentinelLabels()
        {
            List<string> list = new List<string>();
            foreach (ILogicRule rule in this.l)
            {
                LogicRuleSentinel sentinel = rule as LogicRuleSentinel;
                if (sentinel != null)
                {
                    list.Add(sentinel.Marker);
                }
            }
            return list.AsReadOnly();
        }

        public void InitializeDefaultLogicRules()
        {
            ISettingDelegate[] reqs = new ISettingDelegate[] { new SettingDelegate_Bool("NavPriorityBoost", true) };
            ISettingDelegate[] delegateArray2 = new ISettingDelegate[] { new SettingDelegate_Bool("LootPriorityBoost", true) };
            ISettingDelegate[] delegateArray3 = new ISettingDelegate[] { new SettingDelegate_Bool("EnableCombat", true) };
            ISettingDelegate[] delegateArray4 = new ISettingDelegate[] { new SettingDelegate_Bool("ManaChargesWhenOff", true) };
            ISettingDelegate[] delegateArray5 = new ISettingDelegate[0];
            int num = 0;
            this.ClearLogicRules_MacroDisabled();
            this.AddLogicRule_MacroDisabled(new LogicRuleSentinel("START", num++));
            this.AddLogicRule_MacroDisabled(new LogicRulePreChain(num++, new em(0), delegateArray4));
            this.AddLogicRule_MacroDisabled(new LogicRuleSentinel("END", num++));
            int num2 = 0;
            this.n.Clear();
            this.n.Add(new e7(num2++));
            int num3 = 0;
            this.ClearLogicRules();
            this.AddLogicRule(new LogicRuleSentinel("START", num3++));
            this.AddLogicRule(new am(num3++, "SpellCompMin-Critical"));
            fz[] fzArray = new fz[6];
            fzArray[1] = fz.b;
            fzArray[2] = fz.c;
            fzArray[3] = fz.d;
            fzArray[4] = fz.e;
            fzArray[5] = fz.f;
            this.AddLogicRule(new ee(num3++, fzArray, false));
            this.AddLogicRule(new az(num3++, "Recharge-Norm-HitP", "Recharge-Norm-Stam", "Recharge-Norm-Mana"));
            this.AddLogicRule(new em(num3++));
            this.AddLogicRule(new bg(num3++, "RebuffTimeRemainingSeconds", true));
            this.AddLogicRule(new am(num3++, "SpellCompMin-Normal"));
            this.AddLogicRule(new LogicRuleSentinel("POSTBUFF", num3++));
            this.AddLogicRule(new eb(num3++));
            this.AddLogicRule(new fy(num3++));
            this.AddLogicRule(new d4(num3++, "Recharge-Helper-HitP"));
            this.AddLogicRule(new bu(num3++, "Recharge-Helper-HitP", "Recharge-Helper-Stam", "Recharge-Helper-Mana"));
            this.AddLogicRule(new ck(num3++));
            this.AddLogicRule(new ee(num3++));
            this.AddLogicRule(new bn(num3++, "PetRefillCount-Normal"));
            this.AddLogicRule(new LogicRuleSentinel("POSTHELPER", num3++));
            this.AddLogicRule(new dc(num3++));
            this.AddLogicRule(new LogicRuleSentinel("POSTAUTOFELLOW", num3++));
            this.AddLogicRule(new al(num3++));
            this.AddLogicRule(new LogicRuleSentinel("PREPRIORITYLOOTACTIONS", num3++));
            this.AddLogicRule(new LogicRulePreChain(num3++, new bb(0), delegateArray2));
            this.AddLogicRule(new LogicRulePreChain(num3++, new c1(0), delegateArray2));
            this.AddLogicRule(new LogicRulePreChain(num3++, new fp(0), delegateArray2));
            this.AddLogicRule(new LogicRuleSentinel("POSTPRIORITYLOOTACTIONS", num3++));
            this.AddLogicRule(new LogicRuleSentinel("PREPRIORITYLOOT", num3++));
            this.AddLogicRule(new LogicRulePreChain(num3++, new aw(0, "CorpseApproachRange-Min", "CorpseApproachRange-Max", new a6("CorpseApproachRange-Max")), new ISettingDelegate[] { new SettingDelegate_Bool("EnableLooting", true), new SettingDelegate_Bool("LootPriorityBoost", true) }));
            this.AddLogicRule(new LogicRulePreChain(num3++, new co(0, 0.020833333333333332), delegateArray2));
            this.AddLogicRule(new LogicRulePreChain(num3++, new fu(0), delegateArray2));
            this.AddLogicRule(new LogicRulePreChain(num3++, new de(0), delegateArray2));
            this.AddLogicRule(new LogicRuleSentinel("POSTPRIORITYLOOT", num3++));
            this.AddLogicRule(new LogicRuleSentinel("PREPRIORITYNAV", num3++));
            aw mr = new aw(0, "NavCloseStopRange", "NavFarStopRange", new bs(PluginCore.cq));
            this.AddLogicRule(new LogicRulePreChain(num3++, mr, reqs));
            this.AddLogicRule(new LogicRuleSentinel("POSTPRIORITYNAV", num3++));
            this.AddLogicRule(new LogicRuleSentinel("PREATTACK", num3++));
            this.AddLogicRule(new cq(num3++));
            this.AddLogicRule(new LogicRuleSentinel("POSTATTACK", num3++));
            this.AddLogicRule(new LogicRuleSentinel("PREIDLESTATUS", num3++));
            this.AddLogicRule(new am(num3++, "SpellCompMin-Idle"));
            fz[] fzArray2 = new fz[6];
            fzArray2[1] = fz.b;
            fzArray2[2] = fz.c;
            fzArray2[3] = fz.d;
            fzArray2[4] = fz.e;
            fzArray2[5] = fz.f;
            this.AddLogicRule(new ee(num3++, fzArray2, true));
            this.AddLogicRule(new bn(num3++, "PetRefillCount-Idle"));
            this.AddLogicRule(new LogicRuleSentinel("PREIDLELOOTACTIONS", num3++));
            this.AddLogicRule(new LogicRulePreChain(num3++, new bb(0), delegateArray5, new ILogicRule[] { new ez(0) }));
            this.AddLogicRule(new LogicRulePreChain(num3++, new c1(0), delegateArray5, new ILogicRule[] { new ez(0) }));
            this.AddLogicRule(new LogicRulePreChain(num3++, new fp(0), delegateArray5, new ILogicRule[] { new ez(0) }));
            this.AddLogicRule(new LogicRuleSentinel("POSTIDLELOOTACTIONS", num3++));
            this.AddLogicRule(new LogicRuleSentinel("PREIDLELOOT", num3++));
            aw aw2 = new aw(0, "CorpseApproachRange-Min", "CorpseApproachRange-Max", new a6("CorpseApproachRange-Max"));
            this.AddLogicRule(new LogicRulePreChain(num3++, aw2, new ISettingDelegate[] { new SettingDelegate_Bool("EnableLooting", true) }, new ILogicRule[] { new LogicRulePreChain(0, new ez(0), new ISettingDelegate[] { new SettingDelegate_Custom(new SettingDelegate_Custom.dBoolDelegate(aw2.a().l)) }) }));
            this.AddLogicRule(new LogicRulePreChain(num3++, new co(0, 0.020833333333333332), delegateArray5, new ILogicRule[] { new ez(0) }));
            this.AddLogicRule(new fu(num3++));
            this.AddLogicRule(new de(num3++));
            this.AddLogicRule(new LogicRuleSentinel("POSTIDLELOOT", num3++));
            this.AddLogicRule(new LogicRuleSentinel("PREIDLEBUFF", num3++));
            this.AddLogicRule(new LogicRulePreChain(num3++, new bg(0, "IdleBuffTopoffTimeSeconds", false), new ISettingDelegate[] { new SettingDelegate_Bool("IdleBuffTopoff", true) }));
            this.AddLogicRule(new LogicRuleSentinel("POSTIDLEBUFF", num3++));
            this.AddLogicRule(new LogicRuleSentinel("PRETARGETAPPROACH", num3++));
            aw aw3 = new aw(0, "AttackDistance", "ApproachDistance", new b("ApproachDistance"));
            this.AddLogicRule(new LogicRulePreChain(num3++, aw3, delegateArray3, new ILogicRule[] { new LogicRulePreChain(0, new ez(0), new ISettingDelegate[] { new SettingDelegate_Custom(new SettingDelegate_Custom.dBoolDelegate(aw3.a().l)) }) }));
            this.AddLogicRule(new LogicRuleSentinel("POSTTARGETAPPROACH", num3++));
            this.AddLogicRule(new LogicRuleSentinel("PREIDLERECHARGE", num3++));
            this.AddLogicRule(new az(num3++, "Recharge-NoTarg-HitP", "Recharge-NoTarg-Stam", "Recharge-NoTarg-Mana"));
            this.AddLogicRule(new LogicRuleSentinel("POSTIDLERECHARGE", num3++));
            this.AddLogicRule(new LogicRuleSentinel("PRENAVROUTE", num3++));
            aw aw4 = new aw(0, "NavCloseStopRange", "NavFarStopRange", new bs(PluginCore.cq));
            this.AddLogicRule(new LogicRulePreChain(num3++, aw4, delegateArray5, new ILogicRule[] { new LogicRulePreChain(0, new ez(0), new ISettingDelegate[] { new SettingDelegate_Custom(new SettingDelegate_Custom.dBoolDelegate(aw4.a().k)) }) }));
            this.AddLogicRule(new LogicRuleSentinel("POSTNAVROUTE", num3++));
            this.AddLogicRule(new dd(num3++));
            this.AddLogicRule(new LogicRuleSentinel("END", num3++));
            this.AddLogicRule(new ez(num3++));
        }

        public bool RemoveLogicRule(ILogicRule lr)
        {
            return this.l.Remove(lr);
        }

        public void SchedulePoke()
        {
            this.j = e3.b();
            this.f.a(1);
        }

        public void StartMacro()
        {
            if (!PluginCore.ck)
            {
                a5.a(eChatType.Errors, "The macro encountered an exception on startup. Cannot continue.");
            }
            else if (PluginCore.cg == 0)
            {
                PluginCore.cq.c.StopMacro();
                a5.a(eChatType.Errors, "Please wait until you are fully logged in.");
            }
            else if (!PluginCore.cq.ay.cl)
            {
                PluginCore.cq.c.StopMacro();
                a5.a(eChatType.Errors, "Please wait until you are fully logged in.");
            }
            else
            {
                this.k = true;
                PluginCore.cq.n.b = true;
                PluginCore.cq.n.i.Clear();
                PluginCore.cq.n.a = false;
                PluginCore.cq.n.r = 0;
                PluginCore.cq.g.d();
                PluginCore.cq.n.c();
                PluginCore.cq.n.n.a();
                a2.e();
                PluginCore.cq.@as.g = DateTimeOffset.Now;
                PluginCore.cq.ay.aq();
                PluginCore.cq.ay.v.Checked = true;
                this.f.a(0x125);
                this.f.d();
                ai.a();
                this.k = false;
                PluginCore.e("Macro started.");
                foreach (ILogicRule rule in this.m)
                {
                    rule.Running = false;
                }
                PluginCore.cq.aj.g();
                this.TryPokeMacro();
            }
        }

        public void StopMacro()
        {
            try
            {
                foreach (ILogicRule rule in this.l)
                {
                    rule.Running = false;
                }
                PluginCore.cq.n.b = false;
                PluginCore.cq.g.d();
                this.f.f();
                PluginCore.cq.ay.v.Checked = false;
                if (PluginCore.cq.n.c != 0)
                {
                    PluginCore.cq.n.c = 0;
                    PluginCore.PC.a(new MyList<int>(100));
                }
                PluginCore.cq.ay.aq();
                PluginCore.e("Macro stopped.");
            }
            catch
            {
            }
        }

        public void TryPokeMacro()
        {
            if (!this.k && (this.j != e3.b()))
            {
                this.j = e3.b();
                if (PluginCore.cq.n.b)
                {
                    this.a(this.l, this.n);
                }
            }
        }

        public bool Enabled
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        public ILogicRule LastExecutedRule
        {
            get
            {
                return this.h;
            }
        }
    }
}

