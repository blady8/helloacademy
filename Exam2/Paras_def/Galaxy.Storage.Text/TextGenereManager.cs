﻿using Paras.Core.BusinessLayers.Common;
using Paras.Core.Entities;
using System;

namespace Paras.Core.BusinessLayers
{
    public class TextGenereManager: TextManagerBase<Genere>
    {
        const string NomeFileDatabaseGeneri = "generi.txt";

        protected override string GetNomeFileDatabase()
        {
            return NomeFileDatabaseGeneri;
        }

        protected override string ConvertiEntityInStringa(Genere entityDaConvertire)
        {
            //Conversione del genere a string
            string genereStringa =
                entityDaConvertire.Id + "|" +
                entityDaConvertire.Nome + "|" +
                entityDaConvertire.Descrizione + "|" +
                entityDaConvertire.Timestamp + "|" +
                entityDaConvertire.UtenteCreatore + "|";
            return genereStringa;
        }

        protected override void RemapNuoviValoriSuEntityInLista(Genere entitySorgente, Genere entityDestinazione)
        {
            entityDestinazione.Nome = entitySorgente.Nome;
            entityDestinazione.Descrizione = entitySorgente.Descrizione;
        }

        protected override Genere ConvertSegmentiInEntity(string[] segments)
        {
            //segmenti[0] => "Id"
            //segmenti[1] => "Nome"
            //segmenti[2] => "Descrizione"
            //segmenti[3] => "Timestamp"
            //segmenti[4] => "UtenteCreatore"
            //segmenti[5] => Exception!

            var genere = new Genere
            {
                Id = int.Parse(segments[0]),
                Nome = segments[1],
                Descrizione = segments[2],
                Timestamp = DateTime.Parse(segments[3]),
                UtenteCreatore = segments[4],
            };
            return genere;
        }        
    }
}
