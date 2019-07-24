using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Xml;
using System.Web;

namespace WebAPI.Controllers
{
    public class FacturaController : ApiController
    {
        [HttpPost]
        public JObject ObtenerDatos(JObject jsonResult)
        {
            TripObject item = JsonConvert.DeserializeObject<TripObject>(jsonResult.ToString());
            //Obtiene numero consecutivo
            Datos Datos = new Datos();
            Return DatoRetorna = Datos.CreaNumeroSecuencia(item.Factura.CasaMatriz_Sucursal,item.Factura.Terminal_PuntoVenta,item.Factura.Tipo_Comprobante,item.Factura.Numero_Comprobante);
            if  (DatoRetorna.Status == "OK")
            {
                item.Factura.NumeroConsecutivo = DatoRetorna.value;
                FacturaElectronicaCR Factura = new FacturaElectronicaCR(item);
                XmlDocument docXML = Factura.CreaXMLFacturaElectronica();
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write("hola");
            }
                
            return jsonResult;
        }
    }
}