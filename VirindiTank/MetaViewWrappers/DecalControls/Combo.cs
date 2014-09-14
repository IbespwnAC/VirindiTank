namespace MetaViewWrappers.DecalControls
{
    using Decal.Adapter;
    using Decal.Adapter.Wrappers;
    using MetaViewWrappers;
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class Combo : Control, ICombo
    {
        public event EventHandler<MVIndexChangeEventArgs> Change;

        public event EventHandler Change_Old;

        private void a(object A_0, IndexChangeEventArgs A_1)
        {
            if (this.a != null)
            {
                this.a(this, new MVIndexChangeEventArgs(base.Id, A_1.get_Index()));
            }
            if (this.b != null)
            {
                this.b(this, null);
            }
        }

        public void Add(string text)
        {
            ((ChoiceWrapper) base.a).Add(text, null);
        }

        public void Add(string text, object obj)
        {
            ((ChoiceWrapper) base.a).Add(text, obj);
        }

        public void Clear()
        {
            ((ChoiceWrapper) base.a).Clear();
        }

        public override void Dispose()
        {
            base.Dispose();
            ((ChoiceWrapper) base.a).remove_Change(new EventHandler<IndexChangeEventArgs>(this.a));
        }

        public override void Initialize()
        {
            base.Initialize();
            ((ChoiceWrapper) base.a).add_Change(new EventHandler<IndexChangeEventArgs>(this.a));
        }

        public void Insert(int index, string text)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Remove(int index)
        {
            this.RemoveAt(index);
        }

        public void RemoveAt(int index)
        {
            ((ChoiceWrapper) base.a).Remove(index);
        }

        public int Count
        {
            get
            {
                return ((ChoiceWrapper) base.a).get_Count();
            }
        }

        public IComboDataIndexer Data
        {
            get
            {
                return new MetaViewWrappers.DecalControls.Combo.a(this);
            }
        }

        public int Selected
        {
            get
            {
                return ((ChoiceWrapper) base.a).get_Selected();
            }
            set
            {
                ((ChoiceWrapper) base.a).set_Selected(value);
            }
        }

        public IComboIndexer Text
        {
            get
            {
                return new MetaViewWrappers.DecalControls.Combo.b(this);
            }
        }

        [DefaultMember("Item")]
        internal class a : IComboDataIndexer
        {
            private Combo a;

            internal a(Combo A_0)
            {
                this.a = A_0;
            }

            public object this[int index]
            {
                get
                {
                    return ((ChoiceWrapper) this.a.a).get_Data().get_Item(A_0);
                }
                set
                {
                    ((ChoiceWrapper) this.a.a).get_Data().set_Item(A_0, value);
                }
            }
        }

        [DefaultMember("Item")]
        internal class b : IComboIndexer
        {
            private Combo a;

            internal b(Combo A_0)
            {
                this.a = A_0;
            }

            public string this[int index]
            {
                get
                {
                    return ((ChoiceWrapper) this.a.a).get_Text().get_Item(A_0);
                }
                set
                {
                    ((ChoiceWrapper) this.a.a).get_Text().set_Item(A_0, value);
                }
            }
        }
    }
}

