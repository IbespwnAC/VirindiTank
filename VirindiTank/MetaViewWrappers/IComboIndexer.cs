namespace MetaViewWrappers
{
    using System;
    using System.Reflection;

    public interface IComboIndexer
    {
        string this[int index] { get; set; }
    }
}

