namespace MetaViewWrappers
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public interface IList : IControl
    {
        event dClickedList Click;

        event EventHandler<MVListSelectEventArgs> Selected;

        IListRow Add();
        IListRow AddRow();
        void Clear();
        void Delete(int index);
        IListRow Insert(int pos);
        IListRow InsertRow(int pos);
        void RemoveRow(int index);

        int ColCount { get; }

        IListRow this[int row] { get; }

        int RowCount { get; }

        int ScrollPosition { get; set; }
    }
}

