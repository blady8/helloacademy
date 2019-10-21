using Paras.Terminal.Procedures;
using Paras.Terminal.Utils;
using System;

namespace Paras.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {


            BusinessLayerMenu.Start();

            //Richiedo conferma di uscita
            ConsoleUtils.ConfermaUscita();
        }
    }
}
