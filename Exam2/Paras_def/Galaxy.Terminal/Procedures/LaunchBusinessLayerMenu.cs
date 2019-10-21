using Paras.Core.BusinessLayers;
using Paras.Core.BusinessLayers.Common;
using Paras.Core.BusinessLayers.JsonProvider;
using Paras.Core.Entities;
using Paras.Core.Managers.Providers.Enum;
using Paras.Terminal.Utils;
using System;
using System.Collections.Generic;

namespace Paras.Terminal.Procedures
{
    public static class BusinessLayerMenu
    {
        public static void Start()
        {
            //Menu
            Console.WriteLine("************************");
            Console.WriteLine("********* MENU *********");
            Console.WriteLine("************************");
            Console.WriteLine("* 1 - Menu Auto *");
            Console.WriteLine("* 2 - Menu Bici *");

            //Recupero della selezione
            var selezione = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 2);

            //Avvio della procedura
            switch (selezione)
            {
                //********************************************************
                case 1:
                    MenuA(); // menu auto
                    break;

                case 2:
                    MenuB(); //menu bici
                    break;
                //********************************************************
                default:
                    Console.WriteLine("Selezione non valida");
                    break;
            }
        }

        private static void MenuA()
        {
            //Menu
            Console.WriteLine("***********************");
            Console.WriteLine("* Menu Auto *");
            Console.WriteLine("***********************");
            Console.WriteLine("* 1 - Inserisci");
            Console.WriteLine("* 2 - Lista presenti");

            //Recupero della selezione
            var selezione = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 2);

            //Avvio della procedura
            switch (selezione)
            {
                //********************************************************
                case 1:
                    CreaAuto();
                    break;
                case 2:
                    StampaListaAuto();
                    break;
                //case 3:
                //    Find();
                //    break;
                //case 4:
                //    CreaMezziDellaFamiglia();

                //********************************************************
                default:
                    Console.WriteLine("Selezione non valida");
                    break;
            }
        }

        //menu bici
        private static void MenuB()
        {
            //Menu
            Console.WriteLine("***********************");
            Console.WriteLine("* Menu Bici *");
            Console.WriteLine("***********************");
            Console.WriteLine("* 1 - Inserisci");
            Console.WriteLine("* 2 - Lista bici in presenti");
            Console.WriteLine("* 3- Ricerca bici secondo il modello");
          

            //Recupero della selezione
            var selezione = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 3);

            //Avvio della procedura
            switch (selezione)
            {
                //********************************************************
                case 1:
                    CreaBici();
                    break;
                case 2:
                    StampaListaBici();
                    break;
                case 3:
                    Find();
                    break;
                default:
                    Console.WriteLine("Selezione non valida");
                    break;
            }
        }


     
        private static void StampaListaBici()
        {
            //Richiedo all'utente il tipo di provider dati
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Provider storage(Json)");
            string storageTypeAsString = "Json";
            //ConsoleUtils.ReadLine<string>(e => e == "Json");
            StorageType storageType = Enum.Parse<StorageType>(storageTypeAsString);

            IManager<Bici> biciManager;
            //Switch sul tipo di storage
            switch (storageType)
            {
                case StorageType.Json:
                    biciManager = new JsonBiciManager();
                    break;
                default:
                    throw new NotSupportedException($"Il provider {storageType} non è supportato");
            }

            //Istanzio il business layer (che il cervello della 
            //nostra applicazione)
            VeicoloMainBusinessLayer layer = new VeicoloMainBusinessLayer(biciManager);

            layer.StampaBici();

        }
        private static void StampaListaAuto()
        {
            //Richiedo all'utente il tipo di provider dati
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Provider storage(Json)");
            string storageTypeAsString = "Json";
            //ConsoleUtils.ReadLine<string>(e => e == "Json");
            StorageType storageType = Enum.Parse<StorageType>(storageTypeAsString);

            IManager<Auto> bAutoManager;
            //Switch sul tipo di storage
            switch (storageType)
            {
                case StorageType.Json:
                    bAutoManager = new JsonAutoManager();
                    break;
                default:
                    throw new NotSupportedException($"Il provider {storageType} non è supportato");
            }

            //Istanzio il business layer (che il cervello della 
            //nostra applicazione)
            VeicoloMainBusinessLayer layer = new VeicoloMainBusinessLayer(bAutoManager);

            layer.StampaAuto();

        }

        private static void Find()
        {
            //Richiedo all'utente il tipo di provider dati
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Provider storage(Json)");
            string storageTypeAsString = "Json";
            //ConsoleUtils.ReadLine<string>(e => e == "Json");
            StorageType storageType = Enum.Parse<StorageType>(storageTypeAsString);

            IManager<Bici> biciManager;
            //Switch sul tipo di storage
            switch (storageType)
            {
                case StorageType.Json:
                    biciManager = new JsonBiciManager();
                    break;
                default:
                    throw new NotSupportedException($"Il provider {storageType} non è supportato");
            }
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Modello da ricerchare:");
            string Modello = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));

            //Istanzio il business layer
            VeicoloMainBusinessLayer layer = new VeicoloMainBusinessLayer(biciManager);


            layer.FindByModello(Modello);


        }

        private static void CreaBici()
        {
            //Richiedo all'utente il tipo di provider dati
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Provider storage(Json)");
            string storageTypeAsString = "Json";
            //ConsoleUtils.ReadLine<string>(e => e == "Json");
            StorageType storageType = Enum.Parse<StorageType>(storageTypeAsString);

            //Richiediamo i dati da console
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "NumeroTelaio:");
            string NumeroTelaio = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Marca:");
            string Marca = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Colore:");
            string Colore = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Modello:");
            string Modello = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));

            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Velocità:");
            int Velocita = ConsoleUtils.ReadLine<int>(p => p > 0);

            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "IsElettrica:");
            bool IsElettrica = ConsoleUtils.ReadLine<bool>(t => t == true || t == false);


            IManager<Bici> biciManager;

            //Switch sul tipo di storage
            switch (storageType)
            {
                case StorageType.Json:
                    biciManager = new JsonBiciManager();
                    break;
                default:
                    throw new NotSupportedException($"Il provider {storageType} non è supportato");
            }

            //Istanzio il business layer 
            VeicoloMainBusinessLayer layer = new VeicoloMainBusinessLayer(biciManager);

            //Avvio la funzione di creazione
            string[] messaggiDiErrore = layer.CreaBiciSeNonEsiste(
                NumeroTelaio, Marca, Modello, IsElettrica, Colore, Velocita);

            //Se non ho messaggi di errore, confermo
            if (messaggiDiErrore.Length == 0)
                ConsoleUtils.WriteColorLine(ConsoleColor.Green, "TUTTOBBBENE!!!");
            else
            {
                //Messaggio di errore generale
                ConsoleUtils.WriteColorLine(ConsoleColor.Yellow,
                    "Attenzione! Ci sono errori nella creazione!");

                //Scorriamo gli errori e li mostriamo all'utente
                foreach (var currentMessage in messaggiDiErrore)
                    ConsoleUtils.WriteColorLine(ConsoleColor.Yellow, currentMessage);
            }

        }


        private static void CreaAuto()
        {
            //Richiedo all'utente il tipo di provider dati
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Provider storage(Json)");
            string storageTypeAsString = "Json";
            //ConsoleUtils.ReadLine<string>(e => e == "Json");
            StorageType storageType = Enum.Parse<StorageType>(storageTypeAsString);

            //Richiediamo i dati da console

            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Marca:");
            string Marca = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Colore:");
            string Colore = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));
            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Modello:");
            string Modello = ConsoleUtils.ReadLine<string>(t => !string.IsNullOrEmpty(t));

            ConsoleUtils.WriteColor(ConsoleColor.Yellow, "Velocità:");
            int Velocita = ConsoleUtils.ReadLine<int>(p => p > 0);




            IManager<Auto> autoManager;

            //Switch sul tipo di storage
            switch (storageType)
            {
                case StorageType.Json:
                    autoManager = new JsonAutoManager();

                    break;
               
                default:
                    throw new NotSupportedException($"Il provider {storageType} non è supportato");
            }

            //Istanzio il business layer (che il cervello della 
            //nostra applicazione)
            VeicoloMainBusinessLayer layer = new VeicoloMainBusinessLayer(autoManager);

            //Avvio la funzione di creazione
            string[] messaggiDiErrore = layer.CreaAutoSeNonEsiste(Marca, Modello, Colore, Velocita);

            //Se non ho messaggi di errore, confermo
            if (messaggiDiErrore.Length == 0)
                ConsoleUtils.WriteColorLine(ConsoleColor.Green, "TUTTOBBBENE!!!");
            else
            {
                //Messaggio di errore generale
                ConsoleUtils.WriteColorLine(ConsoleColor.Yellow,
                    "Attenzione! Ci sono errori nella creazione!");

                //Scorriamo gli errori e li mostriamo all'utente
                foreach (var currentMessage in messaggiDiErrore)
                    ConsoleUtils.WriteColorLine(ConsoleColor.Yellow, currentMessage);
            }

        }


    }
}

