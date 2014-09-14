namespace MetaViewWrappers.DecalControls
{
    using Decal.Adapter;
    using Decal.Adapter.Wrappers;
    using MetaViewWrappers;
    using System;
    using System.Runtime.CompilerServices;

    public class TextBox : Control, ITextBox
    {
        public event EventHandler<MVTextBoxChangeEventArgs> Change;

        public event EventHandler Change_Old;

        public event EventHandler<MVTextBoxEndEventArgs> End;

        private void a(object A_0, TextBoxChangeEventArgs A_1)
        {
            if (this.a != null)
            {
                this.a(this, new MVTextBoxChangeEventArgs(base.Id, A_1.get_Text()));
            }
            if (this.b != null)
            {
                this.b(this, null);
            }
        }

        private void a(object A_0, TextBoxEndEventArgs A_1)
        {
            if (this.c != null)
            {
                this.c(this, new MVTextBoxEndEventArgs(base.Id, A_1.get_Success()));
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            ((TextBoxWrapper) base.a).remove_Change(new EventHandler<TextBoxChangeEventArgs>(this.a));
            ((TextBoxWrapper) base.a).remove_End(new EventHandler<TextBoxEndEventArgs>(this.a));
        }

        public override void Initialize()
        {
            base.Initialize();
            ((TextBoxWrapper) base.a).add_Change(new EventHandler<TextBoxChangeEventArgs>(this.a));
            ((TextBoxWrapper) base.a).add_End(new EventHandler<TextBoxEndEventArgs>(this.a));
        }

        public int Caret
        {
            get
            {
                return ((TextBoxWrapper) base.a).get_Caret();
            }
            set
            {
                ((TextBoxWrapper) base.a).set_Caret(value);
            }
        }

        public string Text
        {
            get
            {
                return ((TextBoxWrapper) base.a).get_Text();
            }
            set
            {
                ((TextBoxWrapper) base.a).set_Text(value);
            }
        }
    }
}

