namespace MetaViewWrappers
{
    using System;
    using System.Runtime.CompilerServices;

    public interface IStaticText : IControl
    {
        event EventHandler<MVControlEventArgs> Click;

        string Text { get; set; }
    }
}

