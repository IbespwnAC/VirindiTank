namespace MetaViewWrappers.VirindiViewServiceHudControls
{
    using MetaViewWrappers;
    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using VirindiViewService;
    using VirindiViewService.Controls;

    public class List : Control, IList
    {
        public event dClickedList Click;

        public event EventHandler<MVListSelectEventArgs> Selected;

        private void a(object A_0, int A_1, int A_2)
        {
            if (this.a != null)
            {
                this.a(this, A_1, A_2);
            }
            if (this.b != null)
            {
                this.b(this, new MVListSelectEventArgs(base.Id, A_1, A_2));
            }
        }

        public IListRow Add()
        {
            return this.AddRow();
        }

        public IListRow AddRow()
        {
            ((HudList) base.a).AddRow();
            return new ListRow(((HudList) base.a).get_RowCount() - 1, this);
        }

        public void Clear()
        {
            ((HudList) base.a).ClearRows();
        }

        public void Delete(int index)
        {
            this.RemoveRow(index);
        }

        public override void Dispose()
        {
            base.Dispose();
            ((HudList) base.a).remove_Click(new HudList.delClickedControl(this, (IntPtr) this.a));
        }

        public override void Initialize()
        {
            base.Initialize();
            ((HudList) base.a).add_Click(new HudList.delClickedControl(this, (IntPtr) this.a));
        }

        public IListRow Insert(int pos)
        {
            return this.InsertRow(pos);
        }

        public IListRow InsertRow(int pos)
        {
            ((HudList) base.a).InsertRow(pos);
            return new ListRow(pos, this);
        }

        public void RemoveRow(int index)
        {
            ((HudList) base.a).RemoveRow(index);
        }

        public int ColCount
        {
            get
            {
                return ((HudList) base.a).get_ColumnCount();
            }
        }

        public IListRow this[int row]
        {
            get
            {
                return new ListRow(row, this);
            }
        }

        public int RowCount
        {
            get
            {
                return ((HudList) base.a).get_RowCount();
            }
        }

        public int ScrollPosition
        {
            get
            {
                return ((HudList) base.a).get_ScrollPosition();
            }
            set
            {
                ((HudList) base.a).set_ScrollPosition(value);
            }
        }

        public class ListCell : IListCell
        {
            private List a;
            private int b;
            private int c;

            internal ListCell(int A_0, int A_1, List A_2)
            {
                this.b = A_0;
                this.c = A_1;
                this.a = A_2;
            }

            public void ResetColor()
            {
                ((HudStaticText) ((HudList) this.a.a).get_Item(this.b).get_Item(this.c)).ResetTextColor();
            }

            public System.Drawing.Color Color
            {
                get
                {
                    return ((HudStaticText) ((HudList) this.a.a).get_Item(this.b).get_Item(this.c)).get_TextColor();
                }
                set
                {
                    ((HudStaticText) ((HudList) this.a.a).get_Item(this.b).get_Item(this.c)).set_TextColor(value);
                }
            }

            public object this[int subval]
            {
                get
                {
                    HudControl control = ((HudList) this.a.a).get_Item(this.b).get_Item(this.c);
                    if (subval == 0)
                    {
                        if (control.GetType() == typeof(HudStaticText))
                        {
                            return ((HudStaticText) control).get_Text();
                        }
                        if (control.GetType() == typeof(HudCheckBox))
                        {
                            return ((HudCheckBox) control).get_Checked();
                        }
                    }
                    else if ((subval == 1) && (control.GetType() == typeof(HudPictureBox)))
                    {
                        return ((HudPictureBox) control).get_Image().get_PortalImageID();
                    }
                    return null;
                }
                set
                {
                    HudControl control = ((HudList) this.a.a).get_Item(this.b).get_Item(this.c);
                    if (subval == 0)
                    {
                        if (control.GetType() == typeof(HudStaticText))
                        {
                            ((HudStaticText) control).set_Text((string) value);
                        }
                        if (control.GetType() == typeof(HudCheckBox))
                        {
                            ((HudCheckBox) control).set_Checked((bool) value);
                        }
                    }
                    else if ((subval == 1) && (control.GetType() == typeof(HudPictureBox)))
                    {
                        int num = (int) value;
                        if (num == 0)
                        {
                            ((HudPictureBox) control).set_Image(null);
                        }
                        else
                        {
                            ((HudPictureBox) control).set_Image((ACImage) num);
                        }
                    }
                }
            }

            public int Width
            {
                get
                {
                    return ((HudStaticText) ((HudList) this.a.a).get_Item(this.b).get_Item(this.c)).get_ClipRegion().Width;
                }
                set
                {
                    throw new Exception("The method or operation is not implemented.");
                }
            }
        }

        public class ListRow : IListRow
        {
            private List a;
            private int b;

            internal ListRow(int A_0, List A_1)
            {
                this.a = A_1;
                this.b = A_0;
            }

            public IListCell this[int col]
            {
                get
                {
                    return new List.ListCell(this.b, col, this.a);
                }
            }
        }
    }
}

