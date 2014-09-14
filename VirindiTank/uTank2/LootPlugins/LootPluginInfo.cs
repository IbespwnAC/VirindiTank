namespace uTank2.LootPlugins
{
    using System;

    public class LootPluginInfo
    {
        internal string a;
        internal string[] b;

        public LootPluginInfo(string ProfileFileExtension, params string[] ExtraDirectories)
        {
            this.a = ProfileFileExtension.TrimStart(new char[] { '.' }).ToLowerInvariant();
            if (ExtraDirectories == null)
            {
                this.b = new string[0];
            }
            else
            {
                this.b = ExtraDirectories;
            }
        }
    }
}

