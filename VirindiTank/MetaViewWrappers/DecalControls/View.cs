namespace MetaViewWrappers.DecalControls
{
    using Decal.Adapter.Wrappers;
    using MetaViewWrappers;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reflection;

    public class View : IView
    {
        private ViewWrapper a;
        private Dictionary<string, Control> b = new Dictionary<string, Control>();
        private List<Control> c = new List<Control>();
        private bool d;

        public void Activate()
        {
            this.Visible = true;
        }

        public void Deactivate()
        {
            this.Visible = false;
        }

        public void Dispose()
        {
            if (!this.d)
            {
                this.d = true;
                GC.SuppressFinalize(this);
                foreach (Control control in this.c)
                {
                    control.Dispose();
                }
                this.a.Dispose();
            }
        }

        public void Initialize(PluginHost p, string pXML)
        {
            this.a = p.LoadViewResource(pXML);
        }

        public void Initialize(PluginHost p, string pXML, string pWindowKey)
        {
            this.a = p.LoadViewResource(pXML);
        }

        public void InitializeRawXML(PluginHost p, string pXML)
        {
            this.a = p.LoadView(pXML);
        }

        public void InitializeRawXML(PluginHost p, string pXML, string pWindowKey)
        {
            this.a = p.LoadView(pXML);
        }

        public void SetIcon(int portalicon)
        {
        }

        public void SetIcon(int icon, int iconlibrary)
        {
            this.a.SetIcon(icon, iconlibrary);
        }

        public bool Activated
        {
            get
            {
                return this.Visible;
            }
            set
            {
                this.Visible = value;
            }
        }

        public IControl this[string id]
        {
            get
            {
                if (this.b.ContainsKey(id))
                {
                    return this.b[id];
                }
                Control item = null;
                IControlWrapper wrapper = this.a.get_Controls().get_Item(id);
                if (wrapper.GetType() == typeof(PushButtonWrapper))
                {
                    item = new Button();
                }
                if (wrapper.GetType() == typeof(CheckBoxWrapper))
                {
                    item = new CheckBox();
                }
                if (wrapper.GetType() == typeof(TextBoxWrapper))
                {
                    item = new TextBox();
                }
                if (wrapper.GetType() == typeof(ChoiceWrapper))
                {
                    item = new Combo();
                }
                if (wrapper.GetType() == typeof(SliderWrapper))
                {
                    item = new Slider();
                }
                if (wrapper.GetType() == typeof(ListWrapper))
                {
                    item = new List();
                }
                if (wrapper.GetType() == typeof(StaticWrapper))
                {
                    item = new StaticText();
                }
                if (wrapper.GetType() == typeof(NotebookWrapper))
                {
                    item = new Notebook();
                }
                if (wrapper.GetType() == typeof(ProgressWrapper))
                {
                    item = new ProgressBar();
                }
                if (wrapper.GetType() == typeof(ButtonWrapper))
                {
                    item = new ImageButton();
                }
                if (item == null)
                {
                    return null;
                }
                item.a = wrapper;
                item.b = id;
                item.Initialize();
                this.c.Add(item);
                this.b[id] = item;
                return item;
            }
        }

        public Point Location
        {
            get
            {
                return new Point(this.a.get_Position().X, this.a.get_Position().Y);
            }
            set
            {
                int width = this.a.get_Position().Width;
                int height = this.a.get_Position().Height;
                this.a.set_Position(new Rectangle(value.X, value.Y, width, height));
            }
        }

        public Rectangle Position
        {
            get
            {
                return this.a.get_Position();
            }
            set
            {
                this.a.set_Position(value);
            }
        }

        public System.Drawing.Size Size
        {
            get
            {
                return new System.Drawing.Size(this.a.get_Position().Width, this.a.get_Position().Height);
            }
        }

        public string Title
        {
            get
            {
                return this.a.get_Title();
            }
            set
            {
                this.a.set_Title(value);
            }
        }

        public ViewWrapper Underlying
        {
            get
            {
                return this.a;
            }
        }

        internal ff.b ViewType
        {
            get
            {
                return ff.b.a;
            }
        }

        public bool Visible
        {
            get
            {
                return this.a.get_Activated();
            }
            set
            {
                this.a.set_Activated(value);
            }
        }
    }
}

