namespace MetaViewWrappers.VirindiViewServiceHudControls
{
    using Decal.Adapter.Wrappers;
    using MetaViewWrappers;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Reflection;
    using VirindiViewService;
    using VirindiViewService.Controls;
    using VirindiViewService.XMLParsers;

    public class View : IView
    {
        private HudView a;
        private Dictionary<string, Control> b = new Dictionary<string, Control>();
        private bool c;
        private List<Control> d = new List<Control>();

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
            if (!this.c)
            {
                this.c = true;
                GC.SuppressFinalize(this);
                foreach (Control control in this.d)
                {
                    control.Dispose();
                }
                this.a.Dispose();
            }
        }

        public void Initialize(PluginHost p, string pXML)
        {
            ViewProperties properties;
            ControlGroup group;
            new Decal3XMLParser().ParseFromResource(pXML, ref properties, ref group);
            this.a = new HudView(properties, group);
        }

        public void Initialize(PluginHost p, string pXML, string pWindowKey)
        {
            ViewProperties properties;
            ControlGroup group;
            new Decal3XMLParser().ParseFromResource(pXML, ref properties, ref group);
            this.a = new HudView(properties, group, pWindowKey);
        }

        public void InitializeRawXML(PluginHost p, string pXML)
        {
            ViewProperties properties;
            ControlGroup group;
            new Decal3XMLParser().Parse(pXML, ref properties, ref group);
            this.a = new HudView(properties, group);
        }

        public void InitializeRawXML(PluginHost p, string pXML, string pWindowKey)
        {
            ViewProperties properties;
            ControlGroup group;
            new Decal3XMLParser().Parse(pXML, ref properties, ref group);
            this.a = new HudView(properties, group, pWindowKey);
        }

        public void SetIcon(int portalicon)
        {
            this.a.set_Icon((ACImage) portalicon);
        }

        public void SetIcon(int icon, int iconlibrary)
        {
            this.a.set_Icon(ACImage.FromIconLibrary(icon, iconlibrary));
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
                HudControl control2 = this.a.get_Item(id);
                if (control2.GetType() == typeof(HudButton))
                {
                    item = new Button();
                }
                if (control2.GetType() == typeof(HudCheckBox))
                {
                    item = new CheckBox();
                }
                if (control2.GetType() == typeof(HudTextBox))
                {
                    item = new TextBox();
                }
                if (control2.GetType() == typeof(HudCombo))
                {
                    item = new Combo();
                }
                if (control2.GetType() == typeof(HudHSlider))
                {
                    item = new Slider();
                }
                if (control2.GetType() == typeof(HudList))
                {
                    item = new List();
                }
                if (control2.GetType() == typeof(HudStaticText))
                {
                    item = new StaticText();
                }
                if (control2.GetType() == typeof(HudTabView))
                {
                    item = new Notebook();
                }
                if (control2.GetType() == typeof(HudProgressBar))
                {
                    item = new ProgressBar();
                }
                if (control2.GetType() == typeof(HudImageButton))
                {
                    item = new ImageButton();
                }
                if (item == null)
                {
                    return null;
                }
                item.a = control2;
                item.b = id;
                item.Initialize();
                this.d.Add(item);
                this.b[id] = item;
                return item;
            }
        }

        public Point Location
        {
            get
            {
                return this.a.get_Location();
            }
            set
            {
                this.a.set_Location(value);
            }
        }

        public Rectangle Position
        {
            get
            {
                return new Rectangle(this.Location, this.Size);
            }
            set
            {
                this.Location = value.Location;
                this.a.set_ClientArea(value.Size);
            }
        }

        public System.Drawing.Size Size
        {
            get
            {
                return new System.Drawing.Size(this.a.get_Width(), this.a.get_Height());
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

        public HudView Underlying
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
                return ff.b.b;
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

