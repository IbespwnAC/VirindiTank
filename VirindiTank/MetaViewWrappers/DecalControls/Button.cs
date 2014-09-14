namespace MetaViewWrappers.DecalControls
{
    using Decal.Adapter;
    using Decal.Adapter.Wrappers;
    using MetaViewWrappers;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class Button : Control, IButton
    {
        public event EventHandler<MVControlEventArgs> Click;

        public event EventHandler Hit;

        private void a(object A_0, ControlEventArgs A_1)
        {
            if (this.b != null)
            {
                this.b(this, new MVControlEventArgs(base.Id));
            }
        }

        private void b(object A_0, ControlEventArgs A_1)
        {
            if (this.a != null)
            {
                this.a(this, null);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            ((PushButtonWrapper) base.a).remove_Hit(new EventHandler<ControlEventArgs>(this.b));
            ((PushButtonWrapper) base.a).remove_Click(new EventHandler<ControlEventArgs>(this.a));
        }

        public override void Initialize()
        {
            base.Initialize();
            ((PushButtonWrapper) base.a).add_Hit(new EventHandler<ControlEventArgs>(this.b));
            ((PushButtonWrapper) base.a).add_Click(new EventHandler<ControlEventArgs>(this.a));
        }

        public string Text
        {
            get
            {
                return ((PushButtonWrapper) base.a).get_Text();
            }
            set
            {
                ((PushButtonWrapper) base.a).set_Text(value);
            }
        }

        public Color TextColor
        {
            get
            {
                return ((PushButtonWrapper) base.a).get_TextColor();
            }
            set
            {
                ((PushButtonWrapper) base.a).set_TextColor(value);
            }
        }
    }
}

