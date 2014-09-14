namespace MetaViewWrappers.VirindiViewServiceHudControls
{
    using MetaViewWrappers;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using VirindiViewService;
    using VirindiViewService.Controls;

    public class ImageButton : Control, IImageButton
    {
        public event EventHandler<MVControlEventArgs> Click;

        private void a(object A_0, ControlMouseEventArgs A_1)
        {
            if ((A_1.get_EventType() == 4) && (this.a != null))
            {
                this.a(this, new MVControlEventArgs(base.Id));
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            base.a.remove_MouseEvent(new EventHandler<ControlMouseEventArgs>(this.a));
        }

        public override void Initialize()
        {
            base.Initialize();
            base.a.add_MouseEvent(new EventHandler<ControlMouseEventArgs>(this.a));
        }

        public void SetImages(int unpressed, int pressed)
        {
            ACImage image;
            ACImage image2;
            if (!Service.PortalBitmapExists(unpressed | 0x6000000))
            {
                image = new ACImage();
            }
            else
            {
                image = new ACImage(unpressed, 0);
            }
            if (!Service.PortalBitmapExists(pressed | 0x6000000))
            {
                image2 = new ACImage();
            }
            else
            {
                image2 = new ACImage(pressed, 0);
            }
            ((HudImageButton) base.a).set_Image_Up(image);
            ((HudImageButton) base.a).set_Image_Up_Pressing(image2);
        }

        public void SetImages(int hmodule, int unpressed, int pressed)
        {
            ((HudImageButton) base.a).set_Image_Up(ACImage.FromIconLibrary(unpressed, hmodule));
            ((HudImageButton) base.a).set_Image_Up_Pressing(ACImage.FromIconLibrary(pressed, hmodule));
        }

        public int Background
        {
            set
            {
                ((HudImageButton) base.a).set_Image_Background2(new ACImage(value, 0));
            }
        }

        public Color Matte
        {
            set
            {
                ((HudImageButton) base.a).set_Image_Background(new ACImage(value));
            }
        }
    }
}

