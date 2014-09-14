namespace MetaViewWrappers
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public interface IImageButton : IControl
    {
        event EventHandler<MVControlEventArgs> Click;

        void SetImages(int unpressed, int pressed);
        void SetImages(int hmodule, int unpressed, int pressed);

        int Background { set; }

        Color Matte { set; }
    }
}

