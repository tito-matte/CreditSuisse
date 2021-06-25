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
}
