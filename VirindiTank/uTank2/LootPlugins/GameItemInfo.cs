namespace uTank2.LootPlugins
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Drawing;
    using uTank2;

    public class GameItemInfo
    {
        private cv a;
        private int b;
        private bool c;
        private uTank2.LootPlugins.ObjectClass d;
        private List<PaletteData> e;

        internal GameItemInfo(cv A_0)
        {
            if (A_0 != null)
            {
                this.b = A_0.k;
                this.a = A_0;
                this.d = (uTank2.LootPlugins.ObjectClass) A_0.c();
                this.c = true;
            }
        }

        internal GameItemInfo(int A_0)
        {
            this.b = A_0;
            if ((PluginCore.cq.aw.get_WorldFilter().get_Item(A_0) != null) && PluginCore.cq.p.i.ContainsKey(A_0))
            {
                this.a = PluginCore.cq.p.i[A_0];
                this.d = (uTank2.LootPlugins.ObjectClass) this.a.c();
                this.c = true;
            }
        }

        private void a()
        {
            this.e = new List<PaletteData>();
            foreach (bo bo in this.a.t)
            {
                this.e.Add(new PaletteData(bo));
            }
        }

        public bool GetValueBool(int key, bool defaultvalue)
        {
            if (!this.a.c.ContainsKey(key))
            {
                return defaultvalue;
            }
            return this.a.c[key];
        }

        public bool GetValueBool(BoolValueKey key, bool defaultvalue)
        {
            return this.GetValueBool((int) key, defaultvalue);
        }

        public double GetValueDouble(int key, double defaultvalue)
        {
            if (!this.a.d.ContainsKey(key))
            {
                return defaultvalue;
            }
            return this.a.d[key];
        }

        public double GetValueDouble(DoubleValueKey key, double defaultvalue)
        {
            return this.GetValueDouble((int) key, defaultvalue);
        }

        public int GetValueInt(int key, int defaultvalue)
        {
            if (!this.a.a.ContainsKey(key))
            {
                return defaultvalue;
            }
            return this.a.a[key];
        }

        public int GetValueInt(IntValueKey key, int defaultvalue)
        {
            return this.GetValueInt((int) key, defaultvalue);
        }

        public long GetValueQuad(int key, long defaultvalue)
        {
            if (!this.a.e.ContainsKey(key))
            {
                return defaultvalue;
            }
            return this.a.e[key];
        }

        public long GetValueQuad(QuadValueKey key, long defaultvalue)
        {
            return this.GetValueQuad((int) key, defaultvalue);
        }

        public string GetValueString(int key, string defaultvalue)
        {
            if (!this.a.b.ContainsKey(key))
            {
                return defaultvalue;
            }
            return this.a.b[key];
        }

        public string GetValueString(StringValueKey key, string defaultvalue)
        {
            return this.GetValueString((int) key, defaultvalue);
        }

        public bool KeyExistsBool(int key)
        {
            return this.a.c.ContainsKey(key);
        }

        public bool KeyExistsDouble(int key)
        {
            return this.a.d.ContainsKey(key);
        }

        public bool KeyExistsInt(int key)
        {
            return this.a.a.ContainsKey(key);
        }

        public bool KeyExistsQuad(int key)
        {
            return this.a.e.ContainsKey(key);
        }

        public bool KeyExistsString(int key)
        {
            return this.a.b.ContainsKey(key);
        }

        public bool HasIDData
        {
            get
            {
                return this.a.j;
            }
        }

        public int Id
        {
            get
            {
                return this.b;
            }
        }

        public bool IsValid
        {
            get
            {
                return this.c;
            }
        }

        public MySpell ItemSpell
        {
            get
            {
                if (this.a.i == -1)
                {
                    return null;
                }
                if (!PluginCore.cq.e.c(this.a.i))
                {
                    return null;
                }
                return PluginCore.cq.e.b(this.a.i);
            }
        }

        public ReadOnlyCollection<int> KeysBool
        {
            get
            {
                List<int> list = new List<int>();
                foreach (int num in this.a.c.Keys)
                {
                    list.Add(num);
                }
                return list.AsReadOnly();
            }
        }

        public ReadOnlyCollection<int> KeysDouble
        {
            get
            {
                List<int> list = new List<int>();
                foreach (int num in this.a.d.Keys)
                {
                    list.Add(num);
                }
                return list.AsReadOnly();
            }
        }

        public ReadOnlyCollection<int> KeysInt
        {
            get
            {
                List<int> list = new List<int>();
                foreach (int num in this.a.a.Keys)
                {
                    list.Add(num);
                }
                return list.AsReadOnly();
            }
        }

        public ReadOnlyCollection<int> KeysQuad
        {
            get
            {
                List<int> list = new List<int>();
                foreach (int num in this.a.e.Keys)
                {
                    list.Add(num);
                }
                return list.AsReadOnly();
            }
        }

        public ReadOnlyCollection<int> KeysString
        {
            get
            {
                List<int> list = new List<int>();
                foreach (int num in this.a.b.Keys)
                {
                    list.Add(num);
                }
                return list.AsReadOnly();
            }
        }

        public uTank2.LootPlugins.ObjectClass ObjectClass
        {
            get
            {
                return this.d;
            }
        }

        public ReadOnlyCollection<PaletteData> Palettes
        {
            get
            {
                if (this.e == null)
                {
                    this.a();
                }
                return this.e.AsReadOnly();
            }
        }

        public ReadOnlyCollection<MySpell> Spells
        {
            get
            {
                List<MySpell> list = new List<MySpell>();
                foreach (int num in this.a.h)
                {
                    if (PluginCore.cq.e.c(num))
                    {
                        list.Add(PluginCore.cq.e.b(num));
                    }
                }
                return list.AsReadOnly();
            }
        }

        public class PaletteData
        {
            private bo a;

            internal PaletteData(bo A_0)
            {
                this.a = A_0;
            }

            public Color ExampleColor
            {
                get
                {
                    return this.a.a();
                }
            }

            public byte Length
            {
                get
                {
                    return this.a.c;
                }
            }

            public byte Offset
            {
                get
                {
                    return this.a.b;
                }
            }

            public int Palette
            {
                get
                {
                    return this.a.a;
                }
            }
        }
    }
}

