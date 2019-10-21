using Paras.Core.BusinessLayers.JsonProvider.Common;
using Paras.Core.Entities;

namespace Paras.Core.BusinessLayers.JsonProvider
{
    public class JsonGenereManager : JsonManagerBase<Genere>
    {
        protected override void RemapNuoviValoriSuEntityInLista(
            Genere entitySorgente, Genere entityDestinazione)
        {
            entityDestinazione.Nome = entitySorgente.Nome;
            entityDestinazione.Descrizione = entitySorgente.Descrizione;
        }
    }
}
