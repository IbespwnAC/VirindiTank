namespace uTank2
{
    using System;

    public interface IRechargeHandler
    {
        bool Activate(eRechargeVital_Single vital);
        string FriendlyNameForVital(eRechargeVital_Single vital);

        string FriendlyName { get; }

        eRechargeVital_Multiple ValidVitals { get; }
    }
}

