using System;

namespace CreditSuisse
{
    public interface ITrade
    {
        double Amount { get; }
        string ClientSector { get; }
        DateTime NextPaymentDate { get; }
        bool IsPoliticallyExposed { get; }
    }
}
