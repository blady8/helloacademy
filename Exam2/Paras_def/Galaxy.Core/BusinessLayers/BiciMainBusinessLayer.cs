using Paras.Core.BusinessLayers.Common;
using Paras.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Paras.Core.BusinessLayers
{
    public class VeicoloMainBusinessLayer
    {
        private IManager<Bici> _BiciManager;
        private IManager<Auto> _AutoManager;


        public VeicoloMainBusinessLayer(IManager<Bici> biciManager)
        {
            _BiciManager = biciManager;

        }
        public VeicoloMainBusinessLayer(IManager<Auto> auto)
        {
            _AutoManager = auto;

        }
        public VeicoloMainBusinessLayer(IManager<Bici> biciManager, IManager<Auto> auto)
        {
            _BiciManager = biciManager;
            _AutoManager = auto;
        }

        public string[] CreaBiciSeNonEsiste(string numeroTelaio, string marca, string modello, bool isElettrica, string colore, int velocita)
        {
            //1) Validazione degli input
            if (string.IsNullOrEmpty(numeroTelaio))
                throw new ArgumentNullException(nameof(numeroTelaio));
            if (string.IsNullOrEmpty(marca))
                throw new ArgumentNullException(nameof(marca));
            if (string.IsNullOrEmpty(modello))
                throw new ArgumentNullException(nameof(modello));
            if (velocita <= 0)
                throw new ArgumentOutOfRangeException(nameof(velocita));
            //Predisposizione messaggi di uscita
            IList<string> messaggi = new List<string>();

            //3)  Verifico che il prezzo sia > 1
            if (velocita < 1)
            {
                //Aggiungo il messaggio di errore, ed esco
                messaggi.Add($"La velocita deve essere maggiore di 1");
                return messaggi.ToArray();
            }

            //7) Creo l'oggetto con tutti i dati
            Bici bici = new Bici
            {
                Marca = marca,
                Modello = modello,
                Velocita = velocita,
                IsElettrica = isElettrica,
                NumeroTelaio = numeroTelaio

            };

            //Aggiungo il libro
            _BiciManager.Crea(bici);

            //8) Ritorno in uscita le validazioni (vuote se non ho errori)
            return messaggi.ToArray();
        }

        public IList<Bici> FindByModello(string modello)
        {
            if (string.IsNullOrEmpty(modello))
                throw new ArgumentNullException(nameof(modello));
            //4-2) Carico tutti 
            IList<Bici> biciclettas = _BiciManager.Carica();

            //4-3) Verifico che esista una bici con modello
            IList<Bici> bici_modello = biciclettas.Where(l => l.Modello.Contains(modello)).ToList();
            Console.WriteLine("Numero bici trovate:" + bici_modello.Count);
            if (bici_modello.Count > 0)
            {


                foreach (var bici in bici_modello)
                {
                    Console.WriteLine("Numero Telaio: " + bici.NumeroTelaio + "  Marca: " + bici.Marca + " Modello: " + bici.Modello + "  Velocita:" + bici.Velocita);

                }
            }


            return bici_modello;

        }
        public void StampaBici()
        {
            //4-2) Carico tutti 
            IList<Bici> biciclettas = _BiciManager.Carica();
            Console.WriteLine();
            foreach (var bici in biciclettas)
            {
                Console.WriteLine("Numero Telaio: " + bici.NumeroTelaio + "  Marca: " + bici.Marca + " Modello: " + bici.Modello + "  Velocita:" + bici.Velocita);

            }

        }
        public void StampaAuto()
        {
            //4-2) Carico tutti 
            IList<Auto> autos = _AutoManager.Carica();
            Console.WriteLine();

            foreach (var auto in autos)
            {
                Console.WriteLine("  Marca: " + auto.Marca + " Modello: " + auto.Modello + "  Velocita:" + auto.Velocita);

            }

        }

        public void CreaMezziDellaFamiglia(int nrBici, string marcaBici, List<string> modelliBici, string marcaAuto, string modelloAuto)
        {
            if (string.IsNullOrEmpty(marcaBici))
                throw new ArgumentNullException(nameof(marcaBici));
            if (string.IsNullOrEmpty(marcaAuto))
                throw new ArgumentNullException(nameof(marcaAuto));
            if (string.IsNullOrEmpty(modelloAuto))
                throw new ArgumentNullException(nameof(modelloAuto));

            foreach (string modello in modelliBici)
            {
                Bici b = new Bici();
                b.Marca = marcaBici;
                b.Modello = modello;
                _BiciManager.Crea(b);
            }
            Auto auto = new Auto
            {
                Marca = marcaAuto,
                Modello = modelloAuto,
                DataImmatricolazione = DateTime.Now
            };


            //Aggiungo il libro
            _AutoManager.Crea(auto);


        }

        ~VeicoloMainBusinessLayer()
        {
            //Rilascio delle risorse
            _BiciManager = null;

        }

        public string[] CreaAutoSeNonEsiste(string marca, string modello, string colore, int velocita)
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

            //3)  Verifico che il prezzo sia > 1
            if (velocita < 1)
            {
                //Aggiungo il messaggio di errore, ed esco
                messaggi.Add($"la velocita deve essere almeno 1 euro");
                return messaggi.ToArray();
            }

            //7) Creo l'oggetto con tutti i dati
            Auto auto = new Auto
            {
                Marca = marca,
                Modello = modello,
                Velocita = velocita,
                DataImmatricolazione = DateTime.Now

            };

            //Aggiungo il libro
            _AutoManager.Crea(auto);

            //8) Ritorno in uscita le validazioni (vuote se non ho errori)
            return messaggi.ToArray();
        }
    }
}
