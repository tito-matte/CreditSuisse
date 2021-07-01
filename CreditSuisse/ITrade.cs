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

    public interface ICategoria
    {
        string Name { get; }
        bool IsValid(ITrade trade);
    }
}
