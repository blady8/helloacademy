using Paras.Core.BusinessLayers.JsonProvider.Common;
using Paras.Core.Entities;

namespace Paras.Core.BusinessLayers.JsonProvider
{
    public class JsonBiciManager : JsonManagerBase<Bici>
    {
        protected override void RemapNuoviValoriSuEntityInLista(Bici targetEntity, Bici sourceEntity)
        {

            targetEntity.NumeroTelaio = sourceEntity.NumeroTelaio;
            targetEntity.IsElettrica = sourceEntity.IsElettrica;
            targetEntity.Colore = sourceEntity.Colore;
            targetEntity.Colore = sourceEntity.Colore;
            targetEntity.Modello = sourceEntity.Modello;
            targetEntity.Marca = sourceEntity.Marca;

        }
    }
}
