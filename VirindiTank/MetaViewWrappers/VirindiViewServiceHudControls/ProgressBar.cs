namespace MetaViewWrappers.VirindiViewServiceHudControls
{
    using MetaViewWrappers;
    using System;
    using VirindiViewService.Controls;

    public class ProgressBar : Control, IProgressBar
    {
        public int MaxValue
        {
            get
            {
                return ((HudProgressBar) base.a).get_Max();
            }
            set
            {
                ((HudProgressBar) base.a).set_Max(value);
            }
        }

        public int Position
        {
            get
            {
                return ((HudProgressBar) base.a).get_Position();
            }
            set
            {
                ((HudProgressBar) base.a).set_Position(value);
            }
        }

        public string PreText
        {
            get
            {
                return ((HudProgressBar) base.a).get_PreText();
            }
            set
            {
                ((HudProgressBar) base.a).set_PreText(value);
            }
        }

        public int Value
        {
            get
            {
                return this.Position;
            }
            set
            {
                this.Position = value;
            }
        }
    }
}

