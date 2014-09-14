namespace MetaViewWrappers.VirindiViewServiceHudControls
{
    using MetaViewWrappers;
    using System;
    using System.Runtime.CompilerServices;
    using VirindiViewService.Controls;

    public class TextBox : Control, ITextBox
    {
        public event EventHandler<MVTextBoxChangeEventArgs> Change;

        public event EventHandler Change_Old;

        public event EventHandler<MVTextBoxEndEventArgs> End;

        private void a(object A_0, EventArgs A_1)
        {
            if (base.a.get_HasFocus() && (this.c != null))
            {
                this.c(this, new MVTextBoxEndEventArgs(base.Id, true));
            }
        }

        private void b(object A_0, EventArgs A_1)
        {
            if (this.a != null)
            {
                this.a(this, new MVTextBoxChangeEventArgs(base.Id, this.Text));
            }
            if (this.b != null)
            {
                this.b(this, null);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            ((HudTextBox) base.a).remove_Change(new EventHandler(this.b));
            base.a.remove_LostFocus(new EventHandler(this.a));
        }

        public override void Initialize()
        {
            base.Initialize();
            ((HudTextBox) base.a).add_Change(new EventHandler(this.b));
            base.a.add_LostFocus(new EventHandler(this.a));
        }

        public int Caret
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        public string Text
        {
            get
            {
                return ((HudTextBox) base.a).get_Text();
            }
            set
            {
                ((HudTextBox) base.a).set_Text(value);
            }
        }
    }
}

