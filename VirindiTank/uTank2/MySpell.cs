namespace uTank2
{
    using Decal.Adapter;
    using Decal.Adapter.Wrappers;
    using Decal.Filters;
    using Decal.Interop.Filters;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;

    public class MySpell
    {
        private cd.c a;
        private bool b;
        private ev c;
        private static Dictionary<string, bool> d = new Dictionary<string, bool>();
        private static string e = "";

        private MySpell()
        {
        }

        internal MySpell(cd.c A_0, ev A_1)
        {
            this.c = A_1;
            this.a = A_0;
            this.b = true;
        }

        public bool SameCompClass(MySpell p)
        {
            return (p.a().a(this.a.j) == 0);
        }

        public bool CanKill
        {
            get
            {
                return ((this.School.Name == "War Magic") || (((this.Family == 640) || (this.Family == 0x27f)) || ((this.Saying == "feazhzhapaj") || ((this.Saying == "equinzhapaj") || (this.Saying == "tugakquati")))));
            }
        }

        public MyList<int> ComponentIDs
        {
            get
            {
                return this.a.h;
            }
        }

        internal cd.a CompSet
        {
            get
            {
                return this.a.j;
            }
        }

        public int Difficulty
        {
            get
            {
                return this.a.f;
            }
        }

        public double Duration
        {
            get
            {
                switch (this.Family)
                {
                    case 0x27c:
                        return 31.0;

                    case 0x27d:
                        return 16.0;

                    case 0x27e:
                        return 31.0;
                }
                return this.a.g;
            }
        }

        public double DurationMS
        {
            get
            {
                return (this.Duration * 1000.0);
            }
        }

        public int EffectiveDurationMS
        {
            get
            {
                return (this.EffectiveDurationS * 0x3e8);
            }
        }

        public int EffectiveDurationS
        {
            get
            {
                double num = 1.0 + (0.2 * this.c.a0);
                switch (this.Family)
                {
                    case 0x27c:
                    case 0x27d:
                    case 0x27e:
                        return (int) this.Duration;
                }
                return (int) (num * this.Duration);
            }
        }

        public int Family
        {
            get
            {
                return this.a.d;
            }
        }

        public string FriendlyName
        {
            get
            {
                string b = this.a.b;
                if (b.EndsWith(" I"))
                {
                    b = b.Substring(0, b.Length - 2);
                }
                else if (b.EndsWith(" II"))
                {
                    b = b.Substring(0, b.Length - 3);
                }
                else if (b.EndsWith(" III"))
                {
                    b = b.Substring(0, b.Length - 4);
                }
                else if (b.EndsWith(" IV"))
                {
                    b = b.Substring(0, b.Length - 3);
                }
                else if (b.EndsWith(" V"))
                {
                    b = b.Substring(0, b.Length - 2);
                }
                else if (b.EndsWith(" VI"))
                {
                    b = b.Substring(0, b.Length - 3);
                }
                if (b.EndsWith(" Self"))
                {
                    return b.Substring(0, b.Length - 5);
                }
                if (b.EndsWith(" Other"))
                {
                    b = b.Substring(0, b.Length - 6);
                }
                return b;
            }
        }

        public bool HasScarabsInInventory
        {
            get
            {
                string b = er.f("BlacklistedSpellComps");
                if (!string.Equals(e, b))
                {
                    e = b;
                    do @do = new do(2);
                    @do.a(b);
                    MySpell.d.Clear();
                    foreach (string[] strArray in @do)
                    {
                        MySpell.d[strArray[1]] = true;
                    }
                }
                if (((FileService) CoreManager.get_Current().get_FileService()).get_ComponentTable() != null)
                {
                    MyDictionary<string, int> dictionary = new MyDictionary<string, int>(0x3e8);
                    foreach (int num in this.ComponentIDs)
                    {
                        if (PluginCore.cq.e.g.ContainsKey(num))
                        {
                            cd.d d = PluginCore.cq.e.g[num];
                            if (d.e.Contains("Scarab"))
                            {
                                if (!dictionary.ContainsKey(d.e))
                                {
                                    dictionary[d.e] = 1;
                                }
                                else
                                {
                                    Dictionary<string, int> dictionary2;
                                    string str2;
                                    (dictionary2 = dictionary)[str2 = d.e] = dictionary2[str2] + 1;
                                }
                            }
                        }
                    }
                    foreach (KeyValuePair<string, int> pair in dictionary)
                    {
                        if (MySpell.d.ContainsKey(pair.Key))
                        {
                            return false;
                        }
                        int introduced15 = PluginCore.cq.p.d(pair.Key);
                        if (introduced15 < pair.Value)
                        {
                            ai.a("Warning: You do not have enough of the item \"" + pair.Key + "\". Spells using it have been disabled.");
                            return false;
                        }
                    }
                }
                return true;
            }
        }

        public bool HitsMultipleTargets
        {
            get
            {
                return ((this.ComponentIDs[0] == 110) || ((this.Saying == "tugakquati") || (this.Family == 0x27e)));
            }
        }

        public int Id
        {
            get
            {
                return this.a.c;
            }
        }

        public static MySpell InvalidSpell
        {
            get
            {
                MySpell spell = new MySpell {
                    b = false,
                    a = new cd.c()
                };
                spell.a.a = new SchoolRetInfo();
                return spell;
            }
        }

        public bool isFellowship
        {
            get
            {
                return this.a.k;
            }
        }

        public bool IsInstantCast
        {
            get
            {
                if (this.Difficulty < 50)
                {
                    return true;
                }
                switch (this.RealFamily)
                {
                    case 0xf3:
                        return true;

                    case 0xf4:
                        return true;

                    case 0xf5:
                        return true;

                    case 0xf6:
                        return true;

                    case 0xf7:
                        return true;

                    case 0xf8:
                        return true;

                    case 0xf9:
                        return true;

                    case 0x27f:
                        return true;
                }
                return false;
            }
        }

        public bool isOffensive
        {
            get
            {
                return this.a.m;
            }
        }

        public bool isUntargetted
        {
            get
            {
                return this.a.l;
            }
        }

        public bool isValid
        {
            get
            {
                return this.b;
            }
        }

        public bool LowersMyHP
        {
            get
            {
                return (this.Saying == "tugakquati");
            }
        }

        public float LowersMyHPAmount
        {
            get
            {
                if (this.Saying == "tugakquati")
                {
                    return 0.5f;
                }
                return 1f;
            }
        }

        public string Name
        {
            get
            {
                return this.a.b;
            }
        }

        public int Quality
        {
            get
            {
                if (PluginCore.cq.x.e())
                {
                    cu cu = PluginCore.cq.x.c(this.a.c);
                    if ((cu != null) && cu.b)
                    {
                        return cu.c;
                    }
                }
                return this.a.f;
            }
        }

        public int RealFamily
        {
            get
            {
                if (PluginCore.cq.x.e())
                {
                    cu cu = PluginCore.cq.x.c(this.a.c);
                    if ((cu != null) && cu.b)
                    {
                        return cu.d;
                    }
                }
                return this.a.e;
            }
        }

        public string Saying
        {
            get
            {
                return this.a.i;
            }
        }

        public SchoolRetInfo School
        {
            get
            {
                return this.a.a;
            }
        }

        public int SkillWithSchool
        {
            get
            {
                int num2;
                int skillId = this.a.a.SkillId;
                SkillInfo o = null;
                try
                {
                    o = PluginCore.cq.aw.get_CharacterFilter().get_Underlying().get_Skill((eSkillID) skillId);
                    num2 = o.get_Buffed();
                }
                finally
                {
                    if (o != null)
                    {
                        Marshal.ReleaseComObject(o);
                    }
                }
                return num2;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SchoolRetInfo
        {
            public string Name;
            public int Id;
            public CharFilterSkillType SkillId
            {
                get
                {
                    switch (this.Id)
                    {
                        case 1:
                            return 0x22;

                        case 2:
                            return 0x21;

                        case 3:
                            return 0x20;

                        case 4:
                            return 0x1f;

                        case 5:
                            return 0x2b;
                    }
                    PluginCore.cq.n.a("Spell school invalid!", e8.e);
                    return 15;
                }
            }
        }
    }
}

