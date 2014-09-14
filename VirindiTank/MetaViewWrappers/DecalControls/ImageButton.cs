namespace MetaViewWrappers.DecalControls
{
    using Decal.Adapter;
    using Decal.Adapter.Wrappers;
    using MetaViewWrappers;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public class ImageButton : Control, IImageButton
    {
        public event EventHandler<MVControlEventArgs> Click;

        private void a(object A_0, ControlEventArgs A_1)
        {
            if (this.a != null)
            {
                this.a(this, new MVControlEventArgs(base.Id));
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            ((ButtonWrapper) base.a).remove_Click(new EventHandler<ControlEventArgs>(this.a));
        }

        public override void Initialize()
        {
            base.Initialize();
            ((ButtonWrapper) base.a).add_Click(new EventHandler<ControlEventArgs>(this.a));
        }

        public void SetImages(int unpressed, int pressed)
        {
            ((ButtonWrapper) base.a).SetImages(unpressed, pressed);
        }

        public void SetImages(int hmodule, int unpressed, int pressed)
        {
            ((ButtonWrapper) base.a).SetImages(hmodule, unpressed, pressed);
        }

        public int Background
        {
            set
            {
                ((ButtonWrapper) base.a).set_Background(value);
            }
        }

        public Color Matte
        {
            set
            {
                ((ButtonWrapper) base.a).set_Matte(value);
            }
        }
    }
}

