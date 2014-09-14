namespace MetaViewWrappers.DecalControls
{
    using Decal.Adapter;
    using Decal.Adapter.Wrappers;
    using MetaViewWrappers;
    using System;
    using System.Runtime.CompilerServices;

    public class CheckBox : Control, ICheckBox
    {
        public event EventHandler<MVCheckBoxChangeEventArgs> Change;

        public event EventHandler Change_Old;

        private void a(object A_0, CheckBoxChangeEventArgs A_1)
        {
            if (this.a != null)
            {
                this.a(this, new MVCheckBoxChangeEventArgs(base.Id, this.Checked));
            }
            if (this.b != null)
            {
                this.b(this, null);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            ((CheckBoxWrapper) base.a).remove_Change(new EventHandler<CheckBoxChangeEventArgs>(this.a));
        }

        public override void Initialize()
        {
            base.Initialize();
            ((CheckBoxWrapper) base.a).add_Change(new EventHandler<CheckBoxChangeEventArgs>(this.a));
        }

        public bool Checked
        {
            get
            {
                return ((CheckBoxWrapper) base.a).get_Checked();
            }
            set
            {
                ((CheckBoxWrapper) base.a).set_Checked(value);
            }
        }

        public string Text
        {
            get
            {
                return ((CheckBoxWrapper) base.a).get_Text();
            }
            set
            {
                ((CheckBoxWrapper) base.a).set_Text(value);
            }
        }
    }
}

