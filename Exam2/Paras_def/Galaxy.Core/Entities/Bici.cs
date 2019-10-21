using System;
using System.Collections.Generic;
using System.Text;

namespace Paras.Core.Entities
{
    /// <summary>
    /// Classe che rappresenta una bici
    /// </summary>
    public class Bici : Veicolo
    {

        /// <summary>
        /// Flag per definire se la bici è elettrica
        /// </summary>
        public bool IsElettrica { get; set; }


  
        /// <summary>
        /// Modello
        /// </summary>NumeroTelaio
        public string NumeroTelaio { get; set; }

    }
}
