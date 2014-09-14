namespace uTank2.LootPlugins
{
    using System.Collections.Generic;

    public interface ILootPluginCapability_SalvageCombineDecision2
    {
        List<int> ChooseBagsToCombine(List<GameItemInfo> availablebags);
    }
}

