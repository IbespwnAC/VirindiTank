namespace MetaViewWrappers.DecalControls
{
    using Decal.Adapter;
    using Decal.Adapter.Wrappers;
    using MetaViewWrappers;
    using System;
    using System.Runtime.CompilerServices;

    public class Slider : Control, ISlider
    {
        public event EventHandler<MVIndexChangeEventArgs> Change;

        public event EventHandler Change_Old;

        private void a(object A_0, IndexChangeEventArgs A_1)
        {
            if (this.a != null)
            {
                this.a(this, new MVIndexChangeEventArgs(base.Id, A_1.get_Index()));
            }
            if (this.b != null)
            {
                this.b(this, null);
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            ((SliderWrapper) base.a).remove_Change(new EventHandler<IndexChangeEventArgs>(this.a));
        }

        public override void Initialize()
        {
            base.Initialize();
            ((SliderWrapper) base.a).add_Change(new EventHandler<IndexChangeEventArgs>(this.a));
        }

        public int Maximum
        {
            get
            {
                return ((SliderWrapper) base.a).get_Maximum();
            }
            set
            {
                ((SliderWrapper) base.a).set_Maximum(value);
            }
        }

        public int Minimum
        {
            get
            {
                return ((SliderWrapper) base.a).get_Minimum();
            }
            set
            {
                ((SliderWrapper) base.a).set_Minimum(value);
            }
        }

        public int Position
        {
            get
            {
                return ((SliderWrapper) base.a).get_SliderPostition();
            }
            set
            {
                ((SliderWrapper) base.a).set_SliderPostition(value);
            }
        }
    }
}

