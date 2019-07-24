using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Controllers
{
    public class Detalle
    {
        public string NumeroLinea { get; set; }
        public string PartidaArancelaria { get; set; }
        public string Codigo { get; set; }
        public string FechaEmision { get; set; }
        public Emisor Emisor { get; set; }
        public Receptor Receptor { get; set; }
        public string CondicionVenta { get; set; }
        public string PlazoCredito { get; set; }
        public string MedioPago { get; set; }
    }
}