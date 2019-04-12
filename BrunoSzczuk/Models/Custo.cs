using System;
using System.Collections.Generic;

namespace BrunoSzczuk.Models
{
    public partial class Custo
    {
        public int CdCusto { get; set; }
        public int CdDestino { get; set; }
        public string DsCusto { get; set; }
        public int TpCusto { get; set; }
        public decimal VlCusto { get; set; }

        public virtual Destino CdDestinoNavigation { get; set; }
    }
}
