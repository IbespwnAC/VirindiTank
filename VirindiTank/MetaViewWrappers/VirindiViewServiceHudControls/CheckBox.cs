namespace MetaViewWrappers.VirindiViewServiceHudControls
{
    using MetaViewWrappers;
    using System;
    using System.Runtime.CompilerServices;
    using VirindiViewService.Controls;

    public class CheckBox : Control, ICheckBox
    {
        public event EventHandler<MVCheckBoxChangeEventArgs> Change;

        public event EventHandler Change_Old;

        private void a(object A_0, EventArgs A_1)
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
            ((HudCheckBox) base.a).remove_Change(new EventHandler(this.a));
        }

        public override void Initialize()
        {
            base.Initialize();
            ((HudCheckBox) base.a).add_Change(new EventHandler(this.a));
        }

        public bool Checked
        {
            get
            {
                return ((HudCheckBox) base.a).get_Checked();
            }
            set
            {
                ((HudCheckBox) base.a).set_Checked(value);
            }
        }

        public string Text
        {
            get
            {
                return ((HudCheckBox) base.a).get_Text();
            }
            set
            {
                ((HudCheckBox) base.a).set_Text(value);
            }
        }
    }
}

