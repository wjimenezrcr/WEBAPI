using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Controllers
{
    public class Receptor
    {
        public string Nombre { get; set; }
        public string Tipo_Identificacion { get; set; }
        public string Numero_Identificacion { get; set; }
        public string IdentificacionExtranjero { get; set; }
        public string NombreComercial { get; set; }
        public string Provincia { get; set; }
        public string Canton { get; set; }
        public string Distrito { get; set; }
        public string Barrio { get; set; }
        public string OtrasSenas { get; set; }
        public string OtrasSenas_Extranjero { get; set; }
        public string CodigoPaisTel { get; set; }
        public string NumTelefono { get; set; }
        public string CodigoPaisFax { get; set; }
        public string NumFax { get; set; }
        public string CorreoElectronico { get; set; }

    }
}