using ExamModule1.Entities;
using ExamModule1.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ExamModule1.Procedures
{
    public static class FunzioniProdotto
    {
        public static void InserisciNumeroDiProdotti()
        {
            var totalNumbers = ConsoleUtils.LeggiNumeroInteroDaConsole(1, 10);

            // Richiamo la funzione che genera i prodotti
            Product[] product = new Product[totalNumbers];

            // Dimensionamento di prodotto
            List<Product> prodotto = CaricaProdottoDaDatabase();

            // Itero per il numero di prodotti richiesto
            for (int index = 0; index < totalNumbers; index++)
            {
                //Richiamo una funzione a cui passo i prodotti
                //e l'indice corrente e questa mi aggiunge il prodotto
                AggiungiProdottoAProduct(product, index);
                             
            }

            //9) Itero e stampo a video tutti i prodotti
            StampaProdotto(product);

            //Finish
            ConsoleUtils.ConfermaUscita();
        }

        private static List<Product> CaricaProdottoDaDatabase()
        {
            //Mi assicuro che esista la folder di archivio
            var archiveFolder = FunzioniFileSystem.AssicuratiCheEsistaCartellaDiArchivio();

            //Tento di farmi dare le righe contenute nel database (se esiste)
            string[] tutteLeRigheDelDatabase = FunzioniFileSystem.OttieniRigheDaDatabase(archiveFolder);

            List<Product> persone = new List<Product>();

            //Itero per tutti gli elementi dell'array
            foreach (var currentRow in tutteLeRigheDelDatabase)
            {
                //Individuo la posizione della ","
                int virgolaPosition = currentRow.IndexOf(",");

                //Se non viene trovata la ",", passiamo al prossimo elemento
                if (virgolaPosition < 0)
                    continue;

                //Prendo come nome la stringa prima della virgola
                string codice = currentRow.Substring(0, virgolaPosition);

                //Prendo quello che ho dopo la virgola come cognome
                string nome = currentRow.Substring(virgolaPosition + 1);

                //Creazione dell'oggetto persona
                Product currentProduct = new Product
                {
                    Code = codice,
                    Name = nome
                };

                //Aggiungo la persona alla lista
                persone.Add(currentProduct);
            }

            return persone;
        }
        private static void StampaProdotto(Product[] prodotto)
        {
            Console.WriteLine("*** Visualizzazione contenuto prodotto***");
            for (var index = 0; index < prodotto.Length; index++)
            {
                Console.WriteLine($" => {prodotto[index].Code}, {prodotto[index].Name}");
            }
        }
        private static void AggiungiProdottoAProduct(Product[] prodotto, int index)
        {
            //5) Richiedo il codice del prodotto
            Console.Write("Codice: ");
            var code = Console.ReadLine();
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            //6) Creo oggetto Product da inserire in product
            Product product = new Product
            {
                Code = code,
                Name = name
            };

            //7) Aggiungo product a prodotto
            prodotto[index] = product;

            var archiveFolder = FunzioniFileSystem.AssicuratiCheEsistaCartellaDiArchivio();

            string datiInventarioStringa = $"{product.Code},{product.Name}";
            // Aggiungo il testo al database
            FunzioniFileSystem.AggiungiTestoAFileDatabase(datiInventarioStringa, archiveFolder);

        }
  

    }

}
