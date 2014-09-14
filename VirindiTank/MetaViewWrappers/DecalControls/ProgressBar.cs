namespace MetaViewWrappers.DecalControls
{
    using Decal.Adapter.Wrappers;
    using MetaViewWrappers;
    using System;

    public class ProgressBar : Control, IProgressBar
    {
        public int MaxValue
        {
            get
            {
                return ((ProgressWrapper) base.a).get_MaxValue();
            }
            set
            {
                ((ProgressWrapper) base.a).set_MaxValue(value);
            }
        }

        public int Position
        {
            get
            {
                return ((ProgressWrapper) base.a).get_Value();
            }
            set
            {
                ((ProgressWrapper) base.a).set_Value(value);
            }
        }

        public string PreText
        {
            get
            {
                return ((ProgressWrapper) base.a).get_PreText();
            }
            set
            {
                ((ProgressWrapper) base.a).set_PreText(value);
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

