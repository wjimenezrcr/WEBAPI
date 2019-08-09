using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;


namespace WebAPI.Controllers
{
    public class RetornaDatosFactura
    {
        public string Status { get; set; }
        public string Mensaje { get; set; }
        public string NumeroConsecutivo { get; set; }
        public string Clave { get; set; }

    }
}