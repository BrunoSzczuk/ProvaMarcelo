using System;
using System.Collections.Generic;

namespace BrunoSzczuk.Models
{
    public partial class Destino
    {
        public Destino()
        {
            Custo = new HashSet<Custo>();
        }

        public int CdDestino { get; set; }
        public string DsDestino { get; set; }
        public DateTime DtInicio { get; set; }
        public DateTime DtTermino { get; set; }
        public decimal VlTotal { get; set; }

        public virtual ICollection<Custo> Custo { get; set; }
    }
}
