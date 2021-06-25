using System;
using System.Collections.Generic;

namespace CreditSuisse
{
    class Program
    {

        static void Main(string[] args)
        {
            DateTime dtareferenceDate;
            List<Trade> trades = new List<Trade>();

            Console.Write("Reference Date 'mm/dd/yyyy': ");
            string inLine = Console.In.ReadLine();

            dtareferenceDate = inLine.StringToDate();

            Console.Write("Number of trades: ");
            inLine = Console.In.ReadLine();

            int.TryParse(inLine, out int nTrades);

            for (int nEntry = 0; nEntry < nTrades; nEntry++)
            {
                Console.Write($"Trade {nEntry + 1}: ");
                inLine = Console.In.ReadLine();

                trades.Add(new Trade(inLine));
            }

            nTrades = 1;
            trades.ForEach(t =>
            {
                string msg = "Ok";

                TimeSpan tm = new TimeSpan(t.NextPaymentDate.Ticks - dtareferenceDate.Ticks);
                
                if (tm.Days < 30)
                    msg = "EXPIRED";
                else
                {
                    if (t.Amount > 1000000)
                        msg = t.ClientSector.ToUpper().Equals("Private".ToUpper()) ? "HIGHRISK" : "MEDIUMRISK";
                }

                Console.Out.WriteLine($"Trade {nTrades} -> {msg}");
            });
        }
    }
}


/*
 * 1. Include a property called IsPoliticallyExposed with a boolean return
 * 2. Implement the property in the trade class, from the ITrade
 * 3. In the ForEach loop, when the categories are analysed, the property is verified if it is true or false and is written PEP (politically exposed person), nullifying any other categories
 * */

