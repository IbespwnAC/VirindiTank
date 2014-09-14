namespace MetaViewWrappers
{
    using System;
    using System.Drawing;

    public interface IControl : IDisposable
    {
        int Id { get; }

        Rectangle LayoutPosition { get; set; }

        string Name { get; }

        string TooltipText { get; set; }

        bool Visible { get; set; }
    }
}

