namespace uTank2.LootPlugins
{
    using System;
    using uTank2;

    public class LootAction
    {
        internal eLootAction a;
        internal int b;
        internal string c;

        internal LootAction(eLootAction A_0)
        {
            this.c = "";
            this.a = A_0;
        }

        internal LootAction(eLootAction A_0, int A_1)
        {
            this.c = "";
            this.a = A_0;
            this.b = A_1;
        }

        public static LootAction GetKeepUpTo(int maxcount)
        {
            return new LootAction(eLootAction.KeepUpTo, maxcount);
        }

        public int Data1
        {
            get
            {
                return this.b;
            }
        }

        public bool IsKeep
        {
            get
            {
                return (this.a == eLootAction.Keep);
            }
        }

        public bool IsKeepUpTo
        {
            get
            {
                return (this.a == eLootAction.KeepUpTo);
            }
        }

        public bool IsNoLoot
        {
            get
            {
                return (this.a == eLootAction.NoLoot);
            }
        }

        internal bool IsRead
        {
            get
            {
                return (this.a == eLootAction.Read);
            }
        }

        public bool IsSalvage
        {
            get
            {
                return (this.a == eLootAction.Salvage);
            }
        }

        public bool IsSell
        {
            get
            {
                return (this.a == eLootAction.Sell);
            }
        }

        public static LootAction Keep
        {
            get
            {
                return new LootAction(eLootAction.Keep);
            }
        }

        public static LootAction NoLoot
        {
            get
            {
                return new LootAction(eLootAction.NoLoot);
            }
        }

        internal static LootAction Read
        {
            get
            {
                return new LootAction(eLootAction.Read);
            }
        }

        public string RuleName
        {
            get
            {
                return this.c;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this.c = value;
                }
                else
                {
                    this.c = "";
                }
            }
        }

        public static LootAction Salvage
        {
            get
            {
                return new LootAction(eLootAction.Salvage);
            }
        }

        public static LootAction Sell
        {
            get
            {
                return new LootAction(eLootAction.Sell);
            }
        }

        public eLootAction SimpleAction
        {
            get
            {
                return this.a;
            }
        }

        public static LootAction User1
        {
            get
            {
                return new LootAction(eLootAction.User1);
            }
        }

        public static LootAction User2
        {
            get
            {
                return new LootAction(eLootAction.User2);
            }
        }

        public static LootAction User3
        {
            get
            {
                return new LootAction(eLootAction.User3);
            }
        }

        public static LootAction User4
        {
            get
            {
                return new LootAction(eLootAction.User4);
            }
        }

        public static LootAction User5
        {
            get
            {
                return new LootAction(eLootAction.User5);
            }
        }
    }
}

