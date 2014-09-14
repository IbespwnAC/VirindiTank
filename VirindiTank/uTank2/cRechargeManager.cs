namespace uTank2
{
    using Decal.Adapter.Wrappers;
    using System;
    using System.Collections.Generic;

    public class cRechargeManager : IDisposable
    {
        private List<IRechargeHandler> a = new List<IRechargeHandler>();
        private Dictionary<eRechargeVital_Single, List<uTank2.cRechargeManager.a>> b = new Dictionary<eRechargeVital_Single, List<uTank2.cRechargeManager.a>>();
        private bool c;

        internal cRechargeManager()
        {
            this.a.Add(new dn());
            this.a.Add(new a9());
            this.a.Add(new a3());
            this.a.Add(new z());
            this.a.Add(new f());
            this.a.Add(new df());
            this.a.Add(new bm());
            this.a();
        }

        private void a()
        {
            this.b.Clear();
            this.b.Add(eRechargeVital_Single.Health, new List<uTank2.cRechargeManager.a>());
            this.b.Add(eRechargeVital_Single.Stamina, new List<uTank2.cRechargeManager.a>());
            this.b.Add(eRechargeVital_Single.Mana, new List<uTank2.cRechargeManager.a>());
        }

        internal void a(k A_0)
        {
            this.a();
            if (A_0 != null)
            {
                a0 a = A_0.c() as a0;
                if (a != null)
                {
                    foreach (v v in a.d())
                    {
                        uTank2.cRechargeManager.a item = new uTank2.cRechargeManager.a {
                            c = this.a(k.b(v[1])),
                            a = k.e(v[2]),
                            b = k.e(v[3]),
                            d = (eRechargeStance) k.e(v[4])
                        };
                        this.b[(eRechargeVital_Single) k.e(v[0])].Add(item);
                    }
                }
            }
        }

        private IRechargeHandler a(string A_0)
        {
            foreach (IRechargeHandler handler in this.a)
            {
                if (handler.FriendlyName == A_0)
                {
                    return handler;
                }
            }
            return null;
        }

        internal k b()
        {
            a0 a = new a0(new string[] { "Vital", "HandlerString", "MinPercent", "MaxPercent", "Stance" });
            foreach (KeyValuePair<eRechargeVital_Single, List<uTank2.cRechargeManager.a>> pair in this.b)
            {
                foreach (uTank2.cRechargeManager.a a2 in pair.Value)
                {
                    v v = new v(a);
                    v[0] = k.a((int) pair.Key);
                    if (a2.c != null)
                    {
                        v[1] = k.a(a2.c.FriendlyName);
                    }
                    else
                    {
                        v[1] = k.a("");
                    }
                    v[2] = k.a(a2.a);
                    v[3] = k.a(a2.b);
                    v[4] = k.a((int) a2.d);
                    a.c(v);
                }
            }
            return new k(a);
        }

        public void Dispose()
        {
            if (!this.c)
            {
                this.c = true;
                GC.SuppressFinalize(this);
            }
        }

        public static bool eRechargeVital_IsSingleInMultiple(eRechargeVital_Single a, eRechargeVital_Multiple b)
        {
            return ((eRechargeVital_SingleToMultiple(a) & b) > 0);
        }

        public static CharFilterVitalType eRechargeVital_SingleToCharFilterType(eRechargeVital_Single a)
        {
            switch (a)
            {
                case eRechargeVital_Single.Health:
                    return 2;

                case eRechargeVital_Single.Stamina:
                    return 4;

                case eRechargeVital_Single.Mana:
                    return 6;
            }
            return 2;
        }

        public static VitalType eRechargeVital_SingleToHooksType(eRechargeVital_Single a, bool current)
        {
            if (current)
            {
                switch (a)
                {
                    case eRechargeVital_Single.Health:
                        return 2;

                    case eRechargeVital_Single.Stamina:
                        return 4;

                    case eRechargeVital_Single.Mana:
                        return 6;
                }
                return 2;
            }
            switch (a)
            {
                case eRechargeVital_Single.Health:
                    return 1;

                case eRechargeVital_Single.Stamina:
                    return 3;

                case eRechargeVital_Single.Mana:
                    return 5;
            }
            return 1;
        }

        public static eRechargeVital_Multiple eRechargeVital_SingleToMultiple(eRechargeVital_Single v)
        {
            switch (v)
            {
                case eRechargeVital_Single.Health:
                    return eRechargeVital_Multiple.Health;

                case eRechargeVital_Single.Stamina:
                    return eRechargeVital_Multiple.Stamina;

                case eRechargeVital_Single.Mana:
                    return eRechargeVital_Multiple.Mana;
            }
            return eRechargeVital_Multiple.Health;
        }

        public static eRechargeStance GetCurrentStance()
        {
            if (PluginCore.cq.ax.get_Actions().get_CombatMode() == 8)
            {
                return eRechargeStance.MagicMode;
            }
            return eRechargeStance.Other;
        }

        public void Recharge(eRechargeVital_Single vital)
        {
            int num = ao.a(eRechargeVital_SingleToCharFilterType(vital));
            eRechargeStance currentStance = GetCurrentStance();
            if (!this.b.ContainsKey(vital))
            {
                ai.a("Warning: could not find a way to regain vital '" + vital.ToString() + "'!");
            }
            else
            {
                List<uTank2.cRechargeManager.a> list = new List<uTank2.cRechargeManager.a>();
                foreach (uTank2.cRechargeManager.a a in this.b[vital])
                {
                    if (a.d == currentStance)
                    {
                        list.Add(a);
                    }
                }
                int num2 = 0;
                while (num2 < list.Count)
                {
                    uTank2.cRechargeManager.a a2 = list[num2];
                    if (((num2 == (list.Count - 1)) || ((a2.a <= num) && (a2.b >= num))) && a2.c.Activate(vital))
                    {
                        break;
                    }
                    num2++;
                }
                if (num2 == list.Count)
                {
                    ai.a("Warning: could not find a way to regain vital '" + vital.ToString() + "'!");
                }
            }
        }

        internal class a
        {
            public int a;
            public int b = 100;
            public IRechargeHandler c;
            public eRechargeStance d = eRechargeStance.Other;
        }
    }
}

