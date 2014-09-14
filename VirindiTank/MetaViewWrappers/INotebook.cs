namespace MetaViewWrappers
{
    using System;
    using System.Runtime.CompilerServices;

    public interface INotebook : IControl
    {
        event EventHandler<MVIndexChangeEventArgs> Change;

        int ActiveTab { get; set; }
    }
}

