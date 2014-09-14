namespace MetaViewWrappers
{
    using System;
    using System.Reflection;

    public interface IListRow
    {
        IListCell this[int col] { get; }
    }
}

