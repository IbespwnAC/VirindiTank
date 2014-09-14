namespace MetaViewWrappers
{
    using System;
    using System.Reflection;

    public interface IComboDataIndexer
    {
        object this[int index] { get; set; }
    }
}

