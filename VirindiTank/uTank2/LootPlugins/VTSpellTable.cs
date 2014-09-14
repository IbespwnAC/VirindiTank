namespace uTank2.LootPlugins
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using uTank2;

    public class VTSpellTable
    {
        public bool DoesSpellIDExist(int id)
        {
            return PluginCore.cq.e.c(id);
        }

        public ReadOnlyCollection<MySpell> GetAllByRealFamily(int realfamily)
        {
            List<MySpell> list = new List<MySpell>();
            foreach (MySpell spell in PluginCore.cq.e.a(realfamily))
            {
                list.Add(spell);
            }
            return list.AsReadOnly();
        }

        public MySpell GetByName(string name)
        {
            return PluginCore.cq.e.a(name);
        }

        public MySpell GetBySaying(string saying)
        {
            return PluginCore.cq.e.b(saying);
        }

        public MySpell GetBySpellID(int id)
        {
            return PluginCore.cq.e.b(id);
        }

        public MySpell GetByTableIndex(int ind)
        {
            return PluginCore.cq.e.d(ind);
        }
    }
}

