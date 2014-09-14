namespace MetaViewWrappers.VirindiViewServiceHudControls
{
    using MetaViewWrappers;
    using System;
    using System.Runtime.CompilerServices;
    using VirindiViewService.Controls;

    public class Slider : Control, ISlider
    {
        public event EventHandler<MVIndexChangeEventArgs> Change;

        public event EventHandler Change_Old;

        private void a(int A_0, int A_1, int A_2)
        {
            if (this.a != null)
            {
                this.a(this, new MVIndexChangeEventArgs(base.Id, A_2));
            }
            if (this.b != null)
            {
                this.b(this, null);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            ((HudHSlider) base.a).remove_Changed(new LinearPositionControl.delScrollChanged(this, (IntPtr) this.a));
        }

        public override void Initialize()
        {
            base.Initialize();
            ((HudHSlider) base.a).add_Changed(new LinearPositionControl.delScrollChanged(this, (IntPtr) this.a));
        }

        public int Maximum
        {
            get
            {
                return ((HudHSlider) base.a).get_Max();
            }
            set
            {
                ((HudHSlider) base.a).set_Max(value);
            }
        }

        public int Minimum
        {
            get
            {
                return ((HudHSlider) base.a).get_Min();
            }
            set
            {
                ((HudHSlider) base.a).set_Min(value);
            }
        }

        public int Position
        {
            get
            {
                return ((HudHSlider) base.a).get_Position();
            }
            set
            {
                ((HudHSlider) base.a).set_Position(value);
            }
        }
    }
}

