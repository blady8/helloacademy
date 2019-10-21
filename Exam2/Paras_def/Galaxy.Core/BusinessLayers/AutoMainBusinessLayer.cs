using Paras.Core.BusinessLayers.Common;
using Paras.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paras.Core.BusinessLayers
{



    public class AutoMainBusinessLayer
    {
        private IManager<Auto> _AutoManager;


        public AutoMainBusinessLayer(IManager<Auto> AutoManager)
        {
            _AutoManager = AutoManager;

        }

        public string[] CreaAutoSeNonEsiste(string marca, string modello, bool isElettrica, int velocita)
        {
            //1) Validazione degli input
            if (string.IsNullOrEmpty(marca))
                throw new ArgumentNullException(nameof(marca));
            if (string.IsNullOrEmpty(modello))
                throw new ArgumentNullException(nameof(modello));
            if (velocita <= 0)
                throw new ArgumentOutOfRangeException(nameof(velocita));
            //Predisposizione messaggi di uscita
            IList<string> messaggi = new List<string>();

            //3)  Verifico che la velocità sia > 0
            if (velocita < 1)
            {
                //Aggiungo il messaggio di errore, ed esco
                messaggi.Add($"La velocità deve essere maggiore di 0");
                return messaggi.ToArray();
            }

            //7) Creo l'oggetto con tutti i dati
            Auto auto = new Auto
            {
                Marca = marca,
                Modello = modello,
                Velocita = velocita,
      

            };

            //Aggiungo il libro
            _AutoManager.Crea(auto);

            //8) Ritorno in uscita le validazioni (vuote se non ho errori)
            return messaggi.ToArray();
        }


        public void StampaAutomobile()
        {
            //4-2) Carico tutti 
            IList<Auto> Automobiles = _AutoManager.Carica();

            foreach (var bici in Automobiles)
            {
                Console.WriteLine( "  Marca: " + bici.Marca + " Modello: " + bici.Modello + "  Velocita:" + bici.Velocita);

            }

        }

  
        ~AutoMainBusinessLayer()
        {
            //Rilascio delle risorse
            _AutoManager = null;

        }


    }
}