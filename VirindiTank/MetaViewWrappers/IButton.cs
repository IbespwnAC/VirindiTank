namespace MetaViewWrappers
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;

    public interface IButton : IControl
    {
        event EventHandler<MVControlEventArgs> Click;

        event EventHandler Hit;

        string Text { get; set; }

        Color TextColor { get; set; }
    }
}

