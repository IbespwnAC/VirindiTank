namespace MetaViewWrappers.VirindiViewServiceHudControls
{
    using MetaViewWrappers;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using VirindiViewService.Controls;

    public class Combo : Control, ICombo
    {
        private List<object> a = new List<object>();

        public event EventHandler<MVIndexChangeEventArgs> Change;

        public event EventHandler Change_Old;

        private void a(object A_0, EventArgs A_1)
        {
            if (this.b != null)
            {
                this.b(this, new MVIndexChangeEventArgs(base.Id, this.Selected));
            }
            if (this.c != null)
            {
                this.c(this, null);
            }
        }

        public void Add(string text)
        {
            ((HudCombo) base.a).AddItem(text, null);
            this.a.Add(null);
        }

        public void Add(string text, object obj)
        {
            ((HudCombo) base.a).AddItem(text, null);
            this.a.Add(obj);
        }

        public void Clear()
        {
            ((HudCombo) base.a).Clear();
            this.a.Clear();
        }

        public override void Dispose()
        {
            base.Dispose();
            ((HudCombo) base.a).remove_Change(new EventHandler(this.a));
        }

        public override void Initialize()
        {
            base.Initialize();
            ((HudCombo) base.a).add_Change(new EventHandler(this.a));
        }

        public void Insert(int index, string text)
        {
            ((HudCombo) base.a).InsertItem(index, text, null);
            this.a.Insert(index, null);
        }

        public void Remove(int index)
        {
            this.RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            ((HudCombo) base.a).DeleteItem(index);
            this.a.RemoveAt(index);
        }

        public int Count
        {
            get
            {
                return ((HudCombo) base.a).get_Count();
            }
        }

        public IComboDataIndexer Data
        {
            get
            {
                return new ComboDataIndexer(this);
            }
        }

        public int Selected
        {
            get
            {
                return ((HudCombo) base.a).get_Current();
            }
            set
            {
                ((HudCombo) base.a).set_Current(value);
            }
        }

        public IComboIndexer Text
        {
            get
            {
                return new ComboIndexer(this);
            }
        }

        public class ComboDataIndexer : IComboDataIndexer
        {
            private Combo a;

            internal ComboDataIndexer(Combo A_0)
            {
                this.a = A_0;
            }

            public object this[int index]
            {
                get
                {
                    return this.a.a[index];
                }
                set
                {
                    this.a.a[index] = value;
                }
            }
        }

        public class ComboIndexer : IComboIndexer
        {
            private Combo a;

            internal ComboIndexer(Combo A_0)
            {
                this.a = A_0;
            }

            public string this[int index]
            {
                get
                {
                    return ((HudStaticText) ((HudCombo) this.a.a).get_Item(index)).get_Text();
                }
                set
                {
                    ((HudStaticText) ((HudCombo) this.a.a).get_Item(index)).set_Text(value);
                }
            }
        }
    }
}

