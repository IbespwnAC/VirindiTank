namespace MetaViewWrappers.VirindiViewServiceHudControls
{
    using MetaViewWrappers;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using VirindiViewService.Controls;

    public class Button : Control, IButton
    {
        public event EventHandler<MVControlEventArgs> Click;

        public event EventHandler Hit;

        private void a(object A_0, ControlMouseEventArgs A_1)
        {
            ControlMouseEventArgs.MouseEventType type = A_1.get_EventType();
            if (type != 0)
            {
                if ((type == 4) && (this.b != null))
                {
                    this.b(this, new MVControlEventArgs(base.Id));
                }
            }
            else if (this.a != null)
            {
                this.a(this, null);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            ((HudButton) base.a).remove_MouseEvent(new EventHandler<ControlMouseEventArgs>(this.a));
        }

        public override void Initialize()
        {
            base.Initialize();
            ((HudButton) base.a).add_MouseEvent(new EventHandler<ControlMouseEventArgs>(this.a));
        }

        public string Text
        {
            get
            {
                return ((HudButton) base.a).get_Text();
            }
            set
            {
                ((HudButton) base.a).set_Text(value);
            }
        }

        public Color TextColor
        {
            get
            {
                return Color.Black;
            }
            set
            {
            }
        }
    }
}

