using System;

namespace CreditSuisse
{
    public class Trade : ITrade
    {
        private readonly string inputLine;
        private double amount;
        private string clientSector;
        private DateTime nextPaymentDate;

        public double Amount => amount;

        public string ClientSector => clientSector;

        public DateTime NextPaymentDate => nextPaymentDate;

        public bool IsPoliticallyExposed => true;

        public Trade(string inputLine)
        {
            this.inputLine = inputLine;
            SetTrade();
        }

        private void SetTrade()
        {
            string[] arrLine = inputLine.Split(" ");
            if (arrLine.Length > 1)
            {
                double.TryParse(arrLine[0], out double amount);

                this.amount = amount;
                clientSector = arrLine[1];
                nextPaymentDate = arrLine[2].StringToDate();
            }
        }
    }

    public class CategoriaExpired : ICategoria
    {
        public string Name => "Expired";
        public DateTime ReferenceDate { get; set; }
        public bool IsValid(ITrade trade)
        {

            TimeSpan tm = new TimeSpan(trade.NextPaymentDate.Ticks - ReferenceDate.Ticks);

            if (tm.Days < 30)
                return true;
            else
                return false;
        }
    }

    public class CategoriaHIGHRISK : ICategoria
    {
        public string Name => "HIGHRISK";
        public bool IsValid(ITrade trade)
        {
            if (trade.Amount > 1000000 && trade.ClientSector.Equals("Private"))
                return true;
            else
                return false;
        }
    }

    public class CategoriaMEDIUMRISK : ICategoria
    {
        public string Name => "MEDIUMRISK";

        public bool IsValid(ITrade trade)
        {
            if (trade.Amount > 1000000 && !trade.ClientSector.Equals("Private"))
                return true;
            else
                return false;
        }
    }

    public class CategoriaPEP : ICategoria
    {
        public string Name => "PEP";

        public bool IsValid(ITrade trade)
        {
            if (trade.IsPoliticallyExposed)
                return true;
            else
                return false;
        }
    }
}
