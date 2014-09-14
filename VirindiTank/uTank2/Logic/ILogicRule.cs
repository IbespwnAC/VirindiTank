namespace uTank2.Logic
{
    using System;

    public interface ILogicRule : IDisposable
    {
        string FriendlyName { get; }

        int Priority { get; }

        bool Running { get; set; }

        bool ValidNow { get; }
    }
}

