using System;

namespace HelloAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            //FunzioniMatematiche.RecuperaDivisioneEDividendoEDividi();

            //FunzioniRubrica.InserisciPersoneEMostraRubrica();

            Console.WriteLine("Menu");
            Console.WriteLine("1 - Divisione");
            Console.WriteLine("2 - Rubrica semplice");
            Console.WriteLine("3 - Rubrica complessa");
            Console.WriteLine("0 - Exit");
            Console.Write("Selezione: ");
            var selezione = Utils.LeggiNumeroInteroDaConsole(1,3);

            //Selezione della funzione da avviare
            switch(selezione)
            {
                case 1:
                    FunzioniMatematiche.RecuperaDivisioneEDividendoEDividi();
                    break;
                case 2:
                    FunzioniMatematiche.RecuperaDivisioneEDividendoEDividi();
                    break;
                case 3:
                    FunzioniMatematiche.RecuperaDivisioneEDividendoEDividi();
                    break;
                case 0:
                    FunzioniMatematiche.RecuperaDivisioneEDividendoEDividi();
                    break;




            }

            FunzioniRubrica.InserisciNumeroArbitrarioPersoneInRubrica();







        }
    }    
}
