namespace MetaViewWrappers
{
    using System;
    using System.Runtime.CompilerServices;

    public interface ICheckBox : IControl
    {
        event EventHandler<MVCheckBoxChangeEventArgs> Change;

        event EventHandler Change_Old;

        bool Checked { get; set; }

        string Text { get; set; }
    }
}

