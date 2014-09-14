namespace MetaViewWrappers
{
    using System;
    using System.Runtime.CompilerServices;

    public interface ITextBox : IControl
    {
        event EventHandler<MVTextBoxChangeEventArgs> Change;

        event EventHandler Change_Old;

        event EventHandler<MVTextBoxEndEventArgs> End;

        int Caret { get; set; }

        string Text { get; set; }
    }
}

