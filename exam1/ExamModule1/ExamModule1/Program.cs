using ExamModule1.Entities;
using ExamModule1.Procedures;
using ExamModule1.utils;
using System;

namespace ExamModule1
{
    class Program
    {
        static void Main(string[] args)
        {
            //1) Parte il programma

            //2) Dire all'utente di inserire un numero compreso tra 1 e 10
            Console.WriteLine("**************************");
            Console.WriteLine("*** EXAM MODULE 1 ***");
            Console.WriteLine("**************************");
            Console.WriteLine("");
            Console.WriteLine("* Inserire un numero di prodotti compreso tra 1 e 10.");

            FunzioniProdotto.InserisciNumeroDiProdotti();
            FunzioniFileSystem.CreaStrutturaPerConservazioneDati();
     
        }
    }
}
