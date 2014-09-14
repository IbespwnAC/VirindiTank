namespace uTank2
{
    using Decal.Adapter;
    using System;

    public class ActiveSpellInfo
    {
        private int a;
        private int b;
        private int c;
        private int d;
        private double e;
        private double f;
        private int g;
        private double h;
        private int i;
        private int j;
        private double k;
        private DateTimeOffset l;

        protected ActiveSpellInfo()
        {
            this.l = DateTimeOffset.Now;
        }

        public ActiveSpellInfo(int pid, int player, int pfamily, int pdifficulty, double pelapsedtime, double pduration, int pcaster, double pstarttime, int pflags, int pkey, double pvalue)
        {
            this.l = DateTimeOffset.Now;
            this.a = pid;
            this.b = player;
            this.c = pfamily;
            this.d = pdifficulty;
            this.e = pelapsedtime;
            this.f = pduration;
            this.g = pcaster;
            this.h = pstarttime;
            this.i = pflags;
            this.j = pkey;
            this.k = pvalue;
        }

        public static ActiveSpellInfo FromProtocolStruct(MessageStruct s)
        {
            return new ActiveSpellInfo { a = s.Value<short>("spell"), b = s.Value<short>("layer"), c = s.Value<short>("family"), d = s.Value<int>("difficulty"), e = s.Value<double>("elapsedTime"), f = s.Value<double>("duration"), g = s.Value<int>("caster"), h = s.Value<double>("startTime"), i = s.Value<int>("flags"), j = s.Value<int>("key"), k = (double) s.Value<float>("value") };
        }

        public override string ToString()
        {
            return string.Format("ActiveSpell: id {0}, layer {1}, family {2}, diff {3}, elapsedtime {4}, duration {5}, caster {6}, starttime {7}, flags {8}, key {9}, value {10}, expiretime {11}", new object[] { this.a, this.b, this.c, this.d, this.e, this.f, this.g, this.h, this.i, this.j, this.k, this.ExpireTime });
        }

        public int Caster
        {
            get
            {
                return this.g;
            }
        }

        public int Difficulty
        {
            get
            {
                return this.d;
            }
        }

        public double Duration
        {
            get
            {
                return this.f;
            }
        }

        public double ElapsedTimeAtLastUpdate
        {
            get
            {
                return this.e;
            }
        }

        public DateTimeOffset ExpireTime
        {
            get
            {
                if (this.f <= 0.0)
                {
                    return DateTimeOffset.MaxValue;
                }
                return (this.l + TimeSpan.FromSeconds((double) (((int) (this.f + 0.5)) + ((int) (this.e + 0.5)))));
            }
        }

        public int Family
        {
            get
            {
                return this.c;
            }
        }

        public int Flags
        {
            get
            {
                return this.i;
            }
        }

        public int Id
        {
            get
            {
                return this.a;
            }
        }

        public bool IsCoolDown
        {
            get
            {
                return !PluginCore.cq.e.c(this.a);
            }
        }

        public int Key
        {
            get
            {
                return this.j;
            }
        }

        public int Layer
        {
            get
            {
                return this.b;
            }
        }

        public MySpell Spell
        {
            get
            {
                return PluginCore.cq.e.b(this.a);
            }
        }

        public double StartTimeRaw
        {
            get
            {
                return this.h;
            }
        }

        public double Value
        {
            get
            {
                return this.k;
            }
        }
    }
}

