namespace uTank2.LootPlugins
{
    using System;

    public interface ILootPluginCapability_SalvageCombineDecision
    {
        bool CanCombineBags(double bag1workmanship, double bag2workmanship, int material);
    }
}

