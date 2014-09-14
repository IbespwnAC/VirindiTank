namespace MetaViewWrappers
{
    using System;
    using System.Drawing;
    using System.Reflection;

    public interface IListCell
    {
        void ResetColor();

        System.Drawing.Color Color { get; set; }

        object this[int subval] { get; set; }

        int Width { get; set; }
    }
}

