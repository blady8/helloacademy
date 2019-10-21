using Paras.Core.BusinessLayers.JsonProvider.Common;
using Paras.Core.Entities;

namespace Paras.Core.BusinessLayers.JsonProvider
{
    public class JsonAutoManager : JsonManagerBase<Auto>
    {
        protected override void RemapNuoviValoriSuEntityInLista(Auto targetEntity, Auto sourceEntity)
        {


            targetEntity.Colore = sourceEntity.Colore;
            targetEntity.Modello = sourceEntity.Modello;
            targetEntity.Marca = sourceEntity.Marca;
        }
    }
}
