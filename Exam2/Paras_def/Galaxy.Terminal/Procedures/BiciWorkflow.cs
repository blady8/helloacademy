using Paras.Core.BusinessLayers;
using Paras.Core.BusinessLayers.Common;
using Paras.Core.BusinessLayers.JsonProvider;
using Paras.Core.Entities;
using System;

namespace Paras.Terminal.Procedures
{
    public static class BiciWorkflow
    {

        public static void EseguiCreaModificaCancella()
        {
            //Creazione dell'istanza del manager delle bici
            Console.WriteLine();
            Console.WriteLine("ESECUZIONE DEL WORKFLOW BICI...");
            Console.WriteLine();

            IManager<Bici> manager = new JsonBiciManager();

            //Visualizzazione contenuto database
            Console.WriteLine("Lettura del database...");
            var biciInArchivio = manager.Carica();
            Console.WriteLine($"Trovate n° {biciInArchivio.Count} bici in archivio");
            foreach (var currentBici in biciInArchivio)
                Console.WriteLine($"Lettura: {currentBici.NumeroTelaio} (ID:{currentBici.Id})");
            Console.WriteLine("");
            Console.WriteLine("Premere invio per proseguire...");
            Console.ReadLine();

            //Creazione di una nuova bici => "C" di CRUD
            Console.WriteLine("Creazione di una bici...");
            var nuovaBici = new Bici { NumeroTelaio = "012345", Colore = "Green", IsElettrica = true, Modello = "Piaggio" };
            manager.Crea(nuovaBici);
            Console.WriteLine("La bici dovrebbe essere stata creata su disco!");
            Console.WriteLine();

            //Leggiamo bici dal disco => "R" di CRUD
            Console.WriteLine("Lettura del database...");
            var tutteLeBici = manager.Carica();
            Console.WriteLine($"Numero biciclette trovati: {tutteLeBici.Count}");
            foreach (var currentBici in tutteLeBici)
                Console.WriteLine($"Lettura dati bici: {currentBici.NumeroTelaio} (ID:{currentBici.Id})");
            Console.WriteLine();
            Console.WriteLine("Premere invio per proseguire...");
            Console.ReadLine();

            //Modifico bici esistente e scrivo sui disco
            Console.WriteLine("Modifica di una bici esistente...");
            nuovaBici.NumeroTelaio = "012345";
            manager.Aggiorna(nuovaBici);
            Console.WriteLine("Il nome cambiato dovrebbe essere sul disco!");
            Console.WriteLine();

            //Rileggiamo per vedere se effettivamente è cambiato
            Console.WriteLine("Lettura del database...");
            var tutteLeBiciDiNuovo = manager.Carica();
            Console.WriteLine($"Numero bici trovate: {tutteLeBiciDiNuovo.Count}");
            foreach (var currentBici in tutteLeBiciDiNuovo)
                Console.WriteLine($"Lettura bici: {currentBici.NumeroTelaio} (ID:{currentBici.Id})");
            Console.WriteLine();
            Console.WriteLine("Premere invio per proseguire...");
            Console.ReadLine();

            //Cancellazione del Bicicletta => "D" di CRUD
//            Console.WriteLine("Cancellazione di un Bicicletta esistente...");
//            manager.Cancella(nuovaBici);
//            Console.WriteLine("Il Bicicletta dovrebbe essere stato cancellato dal disco!");
//            Console.WriteLine();

            //Rileggiamo per vedere se effettivamente è cambiato
            Console.WriteLine("Lettura del database...");
            var tuttiIbicicletteUltimaVolta = manager.Carica();
            Console.WriteLine($"Numero biciclette trovate: {tuttiIbicicletteUltimaVolta.Count}");
            foreach (var currentBicicletta in tuttiIbicicletteUltimaVolta)
                Console.WriteLine($"Lettura Bicicletta: {currentBicicletta.NumeroTelaio} (ID:{currentBicicletta.Id})");
            Console.WriteLine();
            Console.WriteLine("Premere invio per proseguire...");
            Console.ReadLine();
        }
  
    
    }
}
