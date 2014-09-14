namespace MetaViewWrappers.DecalControls
{
    using Decal.Adapter.Wrappers;
    using MetaViewWrappers;
    using System;
    using System.Drawing;

    public class Control : IControl
    {
        internal IControlWrapper a;
        internal string b;
        private bool c;

        public virtual void Dispose()
        {
            if (!this.c)
            {
                this.c = true;
            }
        }

        public virtual void Initialize()
        {
        }

        public int Id
        {
            get
            {
                return this.a.get_Id();
            }
        }

        public Rectangle LayoutPosition
        {
            get
            {
                return new Rectangle();
            }
            set
            {
            }
        }

        public string Name
        {
            get
            {
                return this.b;
            }
        }

        public string TooltipText
        {
            get
            {
                return "";
            }
            set
            {
            }
        }

        public IControlWrapper Underlying
        {
            get
            {
                return this.a;
            }
        }

        public bool Visible
        {
            get
            {
                return true;
            }
            set
            {
            }
        }
    }
}

