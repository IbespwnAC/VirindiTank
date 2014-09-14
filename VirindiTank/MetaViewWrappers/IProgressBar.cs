namespace MetaViewWrappers
{
    using System;

    public interface IProgressBar : IControl
    {
        int MaxValue { get; set; }

        int Position { get; set; }

        string PreText { get; set; }

        int Value { get; set; }
    }
}

