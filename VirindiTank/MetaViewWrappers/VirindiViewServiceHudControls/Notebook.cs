namespace MetaViewWrappers.VirindiViewServiceHudControls
{
    using MetaViewWrappers;
    using System;
    using System.Runtime.CompilerServices;
    using VirindiViewService.Controls;

    public class Notebook : Control, INotebook
    {
        public event EventHandler<MVIndexChangeEventArgs> Change;

        private void a(object A_0, EventArgs A_1)
        {
            if (this.a != null)
            {
                this.a(this, new MVIndexChangeEventArgs(base.Id, this.ActiveTab));
            }
        }

        public override void Dispose()
        {
            ((HudTabView) base.a).remove_OpenTabChange(new EventHandler(this.a));
            base.Dispose();
        }

        public override void Initialize()
        {
            base.Initialize();
            ((HudTabView) base.a).add_OpenTabChange(new EventHandler(this.a));
        }

        public int ActiveTab
        {
            get
            {
                return ((HudTabView) base.a).get_CurrentTab();
            }
            set
            {
                ((HudTabView) base.a).set_CurrentTab(value);
                ((HudTabView) base.a).Invalidate();
            }
        }
    }
}

