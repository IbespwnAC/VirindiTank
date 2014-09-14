namespace MetaViewWrappers
{
    using System;
    using System.Runtime.CompilerServices;

    public interface ICombo : IControl
    {
        event EventHandler<MVIndexChangeEventArgs> Change;

        event EventHandler Change_Old;

        void Add(string text);
        void Add(string text, object obj);
        void Clear();
        void Insert(int index, string text);
        void Remove(int index);
        void RemoveAt(int index);

        int Count { get; }

        IComboDataIndexer Data { get; }

        int Selected { get; set; }

        IComboIndexer Text { get; }
    }
}

