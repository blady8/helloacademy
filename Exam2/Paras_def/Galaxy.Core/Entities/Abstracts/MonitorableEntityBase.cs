using Paras.Core.Entities.Interfaces;
using System;

namespace Paras.Core.Entities
{
    /// <summary>
    /// Classe astratta per tutte le entità monitorabili
    /// </summary>
    public abstract class MonitorableEntityBase: IEntity, IMonitorableEntity
    {
        /// <summary>
        /// Id primario
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// Data di creazione dell'entità
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Utente che ha fisicamente creato dell'entità nel catalogo
        /// </summary>
        public string UtenteCreatore { get; set; }


    }
}
