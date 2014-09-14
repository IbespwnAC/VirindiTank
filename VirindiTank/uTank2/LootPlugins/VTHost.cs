namespace uTank2.LootPlugins
{
    using System;
    using uTank2;

    public class VTHost
    {
        internal dy a;

        public void AddChatText(string text)
        {
            a5.a(eChatType.CommandLine, "[" + this.a.d + "] " + text);
        }

        public void AddChatText(string text, int color)
        {
            a5.a(eChatType.CommandLine, "[" + this.a.d + "] " + text);
        }

        public void AddChatText(string text, int color, int window)
        {
            a5.a(eChatType.CommandLine, "[" + this.a.d + "] " + text);
        }

        public VTSpellTable SpellTable
        {
            get
            {
                return new VTSpellTable();
            }
        }
    }
}

