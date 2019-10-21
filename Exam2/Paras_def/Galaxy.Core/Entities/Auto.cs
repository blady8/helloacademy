using System;
using System.Collections.Generic;
using System.Text;

namespace Paras.Core.Entities
{
    /// <summary>
    ///
    /// “NumeroCavalli”, “IsDiesel” e “DataImmatricolazione”.
    /// </summary>
    public class Auto : Veicolo
    {

        /// <summary>
        /// Flag per definire se e' IsDiesel
        /// </summary>
        public bool IsDiesel { get; set; }

        /// <summary>
        /// NumeroCavalli
        /// </summary>
        public int NumeroCavalli { get; set; }

        

        /// <summary>
        /// DataImmatricolazione
        /// </summary>
        public DateTime DataImmatricolazione { get; set; }


    }
}
