using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Controllers
{
    public class Encabezado
    {
        public string CasaMatriz_Sucursal { get; set; }
        public string Terminal_PuntoVenta { get; set; }
        public string Tipo_Comprobante { get; set; }
        public string Numero_Comprobante { get; set; }
        public string CodigoActividad { get; set; }
        public string Clave { get; set; }
        public string NumeroConsecutivo { get; set; }
        public string FechaEmision { get; set; }
        public Emisor Emisor { get; set; }
        public Receptor Receptor { get; set; }
        public string CondicionVenta { get; set; }
        public string PlazoCredito { get; set; }
        public string MedioPago { get; set; }
    }
}