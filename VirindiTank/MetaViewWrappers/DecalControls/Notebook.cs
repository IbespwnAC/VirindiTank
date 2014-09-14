namespace MetaViewWrappers.DecalControls
{
    using Decal.Adapter;
    using Decal.Adapter.Wrappers;
    using MetaViewWrappers;
    using System;
    using System.Runtime.CompilerServices;

    public class Notebook : Control, INotebook
    {
        public event EventHandler<MVIndexChangeEventArgs> Change;

        private void a(object A_0, IndexChangeEventArgs A_1)
        {
            if (this.a != null)
            {
                this.a(this, new MVIndexChangeEventArgs(base.Id, A_1.get_Index()));
            }
        }

        public override void Dispose()
        {
            base.Dispose();
            ((NotebookWrapper) base.a).remove_Change(new EventHandler<IndexChangeEventArgs>(this.a));
        }

        public override void Initialize()
        {
            base.Initialize();
            ((NotebookWrapper) base.a).add_Change(new EventHandler<IndexChangeEventArgs>(this.a));
        }

        public int ActiveTab
        {
            get
            {
                return ((NotebookWrapper) base.a).get_ActiveTab();
            }
            set
            {
                ((NotebookWrapper) base.a).set_ActiveTab(value);
            }
        }
    }
}

