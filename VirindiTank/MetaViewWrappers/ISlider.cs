namespace MetaViewWrappers
{
    using System;
    using System.Runtime.CompilerServices;

    public interface ISlider : IControl
    {
        event EventHandler<MVIndexChangeEventArgs> Change;

        event EventHandler Change_Old;

        int Maximum { get; set; }

        int Minimum { get; set; }

        int Position { get; set; }
    }
}

