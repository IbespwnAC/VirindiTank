namespace MetaViewWrappers.VirindiViewServiceHudControls
{
    using MetaViewWrappers;
    using System;
    using System.Runtime.CompilerServices;
    using VirindiViewService.Controls;

    public class StaticText : Control, IStaticText
    {
        public event EventHandler<MVControlEventArgs> Click;

        public override void Dispose()
        {
            base.Dispose();
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public string Text
        {
            get
            {
                return ((HudStaticText) base.a).get_Text();
            }
            set
            {
                ((HudStaticText) base.a).set_Text(value);
            }
        }
    }
}

