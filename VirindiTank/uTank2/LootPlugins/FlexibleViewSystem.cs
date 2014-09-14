namespace uTank2.LootPlugins
{
    using MetaViewWrappers;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using uTank2;

    public class FlexibleViewSystem
    {
        internal dy a;
        internal List<IView> b = new List<IView>();

        public IView CreateViewResource(string XMLResource)
        {
            string xmldata = "";
            using (Stream stream = Assembly.GetCallingAssembly().GetManifestResourceStream(XMLResource))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    xmldata = reader.ReadToEnd();
                }
            }
            return this.CreateViewXML(xmldata);
        }

        public IView CreateViewXML(string xmldata)
        {
            IView item = ff.c(PluginCore.cq.ax, xmldata);
            this.b.Add(item);
            return item;
        }

        public void DestroyAllViews()
        {
            foreach (IView view in this.b)
            {
                view.Dispose();
            }
            this.b.Clear();
        }
    }
}

