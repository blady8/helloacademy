using Paras.Core.BusinessLayers.JsonProvider.Common;
using Paras.Core.Entities;

namespace Paras.Core.BusinessLayers.JsonProvider
{
    public class JsonLibroManager : JsonManagerBase<Libro>
    {
        protected override void RemapNuoviValoriSuEntityInLista(
            Libro entitySorgente, Libro entityDestinazione)
        {
            entityDestinazione.Titolo = entitySorgente.Titolo;
            entityDestinazione.Lingua = entitySorgente.Lingua;
            entityDestinazione.Prezzo = entitySorgente.Prezzo;
            entityDestinazione.Anno = entitySorgente.Anno;
            entityDestinazione.Autore = entitySorgente.Autore;
            entityDestinazione.Codice = entitySorgente.Codice;
            entityDestinazione.GenereAppartenenza = entitySorgente.GenereAppartenenza;
        }
    }
}
