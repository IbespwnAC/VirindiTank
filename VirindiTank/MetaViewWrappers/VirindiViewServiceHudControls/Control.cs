namespace MetaViewWrappers.VirindiViewServiceHudControls
{
    using MetaViewWrappers;
    using System;
    using System.Drawing;
    using VirindiViewService;
    using VirindiViewService.Controls;

    public class Control : IControl
    {
        internal HudControl a;
        internal string b;
        private TooltipSystem.cTooltipInfo c;
        private bool d;

        public virtual void Dispose()
        {
            if (!this.d)
            {
                this.d = true;
                this.a.Dispose();
            }
        }

        public virtual void Initialize()
        {
        }

        public int Id
        {
            get
            {
                return this.a.get_XMLID();
            }
        }

        public Rectangle LayoutPosition
        {
            get
            {
                if (this.Underlying.get_Group().get_HeadControl() == null)
                {
                    return new Rectangle();
                }
                if (this.Underlying.get_Group().get_HeadControl().get_Name() == this.Underlying.get_Name())
                {
                    return new Rectangle();
                }
                HudControl control = this.Underlying.get_Group().ParentOf(this.Underlying.get_Name());
                if (control == null)
                {
                    return new Rectangle();
                }
                HudFixedLayout layout = control as HudFixedLayout;
                if (layout == null)
                {
                    return new Rectangle();
                }
                return layout.GetControlRect(this.Underlying);
            }
            set
            {
                if ((this.Underlying.get_Group().get_HeadControl() != null) && (this.Underlying.get_Group().get_HeadControl().get_Name() != this.Underlying.get_Name()))
                {
                    HudControl control = this.Underlying.get_Group().ParentOf(this.Underlying.get_Name());
                    if (control != null)
                    {
                        HudFixedLayout layout = control as HudFixedLayout;
                        if (layout != null)
                        {
                            layout.SetControlRect(this.Underlying, value);
                        }
                    }
                }
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
                if (this.c != null)
                {
                    return this.c.get_Text();
                }
                return "";
            }
            set
            {
                if (this.c != null)
                {
                    TooltipSystem.RemoveTooltip(this.c);
                    this.c = null;
                }
                if (!string.IsNullOrEmpty(value))
                {
                    this.c = TooltipSystem.AssociateTooltip(this.a, value);
                }
            }
        }

        public HudControl Underlying
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
                return this.a.get_Visible();
            }
            set
            {
                this.a.set_Visible(value);
            }
        }
    }
}

