namespace MetaViewWrappers.DecalControls
{
    using Decal.Adapter;
    using Decal.Adapter.Wrappers;
    using MetaViewWrappers;
    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public class List : Control, IList
    {
        public event dClickedList Click;

        public event EventHandler<MVListSelectEventArgs> Selected;

        private void a(object A_0, ListSelectEventArgs A_1)
        {
            if (this.a != null)
            {
                this.a(this, A_1.get_Row(), A_1.get_Column());
            }
            if (this.b != null)
            {
                this.b(this, new MVListSelectEventArgs(base.Id, A_1.get_Row(), A_1.get_Column()));
            }
        }

        public IListRow Add()
        {
            return this.AddRow();
        }

        public IListRow AddRow()
        {
            ((ListWrapper) base.a).Add();
            return new ListRow(this, ((ListWrapper) base.a).get_RowCount() - 1);
        }

        public void Clear()
        {
            ((ListWrapper) base.a).Clear();
        }

        public void Delete(int index)
        {
            this.RemoveRow(index);
        }

        public override void Dispose()
        {
            base.Dispose();
            ((ListWrapper) base.a).remove_Selected(new EventHandler<ListSelectEventArgs>(this.a));
        }

        public override void Initialize()
        {
            base.Initialize();
            ((ListWrapper) base.a).add_Selected(new EventHandler<ListSelectEventArgs>(this.a));
        }

        public IListRow Insert(int pos)
        {
            return this.InsertRow(pos);
        }

        public IListRow InsertRow(int pos)
        {
            ((ListWrapper) base.a).Insert(pos);
            return new ListRow(this, pos);
        }

        public void RemoveRow(int index)
        {
            ((ListWrapper) base.a).Delete(index);
        }

        public int ColCount
        {
            get
            {
                return ((ListWrapper) base.a).get_ColCount();
            }
        }

        public IListRow this[int row]
        {
            get
            {
                return new ListRow(this, row);
            }
        }

        public int RowCount
        {
            get
            {
                return ((ListWrapper) base.a).get_RowCount();
            }
        }

        public int ScrollPosition
        {
            get
            {
                return ((ListWrapper) base.a).get_ScrollPosition();
            }
            set
            {
                ((ListWrapper) base.a).set_ScrollPosition(value);
            }
        }

        public class ListCell : IListCell
        {
            internal List a;
            internal int b;
            internal int c;

            public ListCell(List l, int r, int c)
            {
                this.a = l;
                this.b = r;
                this.c = c;
            }

            public void ResetColor()
            {
                this.Color = System.Drawing.Color.White;
            }

            public System.Drawing.Color Color
            {
                get
                {
                    return ((ListWrapper) this.a.a).get_Item(this.b).get_Item(this.c).get_Color();
                }
                set
                {
                    ((ListWrapper) this.a.a).get_Item(this.b).get_Item(this.c).set_Color(value);
                }
            }

            public object this[int subval]
            {
                get
                {
                    return ((ListWrapper) this.a.a).get_Item(this.b).get_Item(this.c).get_Item(subval);
                }
                set
                {
                    ((ListWrapper) this.a.a).get_Item(this.b).get_Item(this.c).set_Item(subval, value);
                }
            }

            public int Width
            {
                get
                {
                    return ((ListWrapper) this.a.a).get_Item(this.b).get_Item(this.c).get_Width();
                }
                set
                {
                    ((ListWrapper) this.a.a).get_Item(this.b).get_Item(this.c).set_Width(value);
                }
            }
        }

        public class ListRow : IListRow
        {
            internal List a;
            internal int b;

            internal ListRow(List A_0, int A_1)
            {
                this.a = A_0;
                this.b = A_1;
            }

            public IListCell this[int col]
            {
                get
                {
                    return new List.ListCell(this.a, this.b, col);
                }
            }
        }
    }
}

