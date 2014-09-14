namespace uTank2.LootPlugins
{
    using System;

    public abstract class LootPluginBase
    {
        internal FlexibleViewSystem a;
        internal VTHost b;

        protected LootPluginBase()
        {
        }

        public abstract void CloseEditorForProfile();
        public abstract bool DoesPotentialItemNeedID(GameItemInfo item);
        public abstract LootAction GetLootDecision(GameItemInfo item);
        public abstract void LoadProfile(string filename, bool newprofile);
        public abstract void OpenEditorForProfile();
        public abstract void Shutdown();
        public abstract LootPluginInfo Startup();
        public abstract void UnloadProfile();

        protected VTHost Host
        {
            get
            {
                return this.b;
            }
        }

        protected FlexibleViewSystem ViewSystem
        {
            get
            {
                return this.a;
            }
        }
    }
}

