namespace MetaViewWrappers.DecalControls
{
    using Decal.Adapter.Wrappers;
    using MetaViewWrappers;
    using System;
    using System.Runtime.CompilerServices;

    public class StaticText : Control, IStaticText
    {
        public event EventHandler<MVControlEventArgs> Click;

        public string Text
        {
            get
            {
                return ((StaticWrapper) base.a).get_Text();
            }
            set
            {
                ((StaticWrapper) base.a).set_Text(value);
            }
        }
    }
}

