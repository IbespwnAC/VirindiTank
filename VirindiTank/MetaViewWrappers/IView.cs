namespace MetaViewWrappers
{
    using Decal.Adapter.Wrappers;
    using System;
    using System.Drawing;
    using System.Reflection;

    public interface IView : IDisposable
    {
        void Activate();
        void Deactivate();
        void Initialize(PluginHost p, string pXML);
        void Initialize(PluginHost p, string pXML, string pWindowKey);
        void InitializeRawXML(PluginHost p, string pXML);
        void InitializeRawXML(PluginHost p, string pXML, string pWindowKey);
        void SetIcon(int portalicon);
        void SetIcon(int icon, int iconlibrary);

        bool Activated { get; set; }

        IControl this[string id] { get; }

        Point Location { get; set; }

        Rectangle Position { get; set; }

        System.Drawing.Size Size { get; }

        string Title { get; set; }

        bool Visible { get; set; }
    }
}

