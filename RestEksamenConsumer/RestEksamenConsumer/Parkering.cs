using System;
using System.Collections.Generic;
using System.Text;

namespace RestEksamenConsumer
{
    class Parkering
    {
        public int ID { get; set; }
        public string NrPlade { get; set; }

        public int AntalTimer { get; set; }

        public int TimePris { get; set; }

        public int TotalPris { get; set; }

        public string Dato { get; set; }

        public Parkering()
        {
        }

        public Parkering(int id, string nrplade, int antaltimer, int timepris, int totalpris, string dato)
        {
            ID = id;
            NrPlade = nrplade;
            AntalTimer = antaltimer;
            TimePris = timepris;
            TotalPris = totalpris;
            Dato = dato;
        }

        public override string ToString()
        {
            return $"{nameof(ID)}: {ID}, {nameof(NrPlade)}: {NrPlade}, {nameof(AntalTimer)}: {AntalTimer}, {nameof(TimePris)}: {TimePris}," +
                   $"{nameof(TotalPris)}: {TotalPris},{nameof(Dato)}: {Dato},";
        }

    }

}

