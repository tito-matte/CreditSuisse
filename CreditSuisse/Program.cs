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
            List<ICategoria> categorias = new List<ICategoria>();

            Console.Write("Reference Date 'mm/dd/yyyy': ");
            string inLine = Console.In.ReadLine();

            dtareferenceDate = inLine.StringToDate();

            categorias.Add(new CategoriaPEP());
            categorias.Add(new CategoriaHIGHRISK());
            categorias.Add(new CategoriaExpired() { ReferenceDate = dtareferenceDate });
            categorias.Add(new CategoriaMEDIUMRISK());

            Console.Write("Number of trades: ");
            inLine = Console.In.ReadLine();

            int.TryParse(inLine, out int nTrades);

            for (int nEntry = 0; nEntry < nTrades; nEntry++)
            {
                Console.Write($"Trade {nEntry + 1}: ");
                inLine = Console.In.ReadLine();

                Trade trade = new Trade(inLine);

                string msg = "Ok";

                foreach (var categoria in categorias)
                {
                    if (categoria.IsValid(trade))
                    {
                        msg = categoria.Name;
                        break;
                    }
                }

                trades.Add(trade);
                Console.Out.WriteLine($"Trade {nTrades} -> {msg}");
            }
        }
    }
}


/*
 * 1. Include a property called IsPoliticallyExposed with a boolean return
 * 2. Implement the property in the trade class, from the ITrade
 * 3. In the ForEach loop, when the categories are analysed, the property is verified if it is true or false and is written PEP (politically exposed person), nullifying any other categories
 * */

