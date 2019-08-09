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
using System.Web.Script;
using System.Web.Script.Serialization;

namespace WebAPI.Controllers
{
    public class FacturaController : ApiController
    {
        [HttpPost]
        public string ObtenerDatos(JObject jsonResult)
        {
            RetornaDatosFactura DatosRetorna = new RetornaDatosFactura();
            try
            {
                TripObject item = JsonConvert.DeserializeObject<TripObject>(jsonResult.ToString());
                Datos Datos = new Datos();

                //Obtiene Numero Consecutivo
                String NumeroConsecutivo = Datos.CreaNumeroSecuencia(item.Factura.CasaMatriz_Sucursal, 
                                                                     item.Factura.Terminal_PuntoVenta, 
                                                                     item.Factura.Tipo_Comprobante, 
                                                                     item.Factura.Numero_Comprobante);
                //Obtiene Codigo Seguridad
                String CodigoSeguridad = Datos.CreaCodigoSeguridad(item.Factura.Tipo_Comprobante,
                                                                   item.Factura.CasaMatriz_Sucursal,
                                                                   item.Factura.Terminal_PuntoVenta,
                                                                   Convert.ToDateTime(item.Factura.FechaEmision),
                                                                   item.Factura.Numero_Comprobante);

                var dia = Convert.ToDateTime(item.Factura.FechaEmision).Day.ToString();
                var mes = Convert.ToDateTime(item.Factura.FechaEmision).Month.ToString();
                var ano = Convert.ToDateTime(item.Factura.FechaEmision).Year.ToString().Substring(2, 2);

                //Obtiene Clave
                String clave = Datos.CreaClave(item.Factura.Codigo_Pais,
                                               Convert.ToDateTime(item.Factura.FechaEmision).Day.ToString(),
                                               Convert.ToDateTime(item.Factura.FechaEmision).Month.ToString(),
                                               Convert.ToDateTime(item.Factura.FechaEmision).Year.ToString().Substring(2,2),
                                               item.Factura.Emisor.Numero_Identificacion,
                                               NumeroConsecutivo,
                                               item.Factura.Situacion_Comprobante, // 1. Normal, 2. Contingencia, 3. Sin Internet
                                               CodigoSeguridad);

                
                item.Factura.NumeroConsecutivo = NumeroConsecutivo;
                item.Factura.Clave = clave;
                FacturaElectronicaCR Factura = new FacturaElectronicaCR(item);
                XmlDocument docXML = Factura.CreaXMLFacturaElectronica();

                DatosRetorna.Status = "OK";
                DatosRetorna.Mensaje = "Datos procesados correctamente.";
                DatosRetorna.NumeroConsecutivo = NumeroConsecutivo;
                DatosRetorna.Clave = clave;
            }

            catch (Exception ex)
            {
                DatosRetorna.Status = "ERROR";
                DatosRetorna.Mensaje = ex.Message;
                DatosRetorna.NumeroConsecutivo = "";
                DatosRetorna.Clave = "";
            }
            
            JavaScriptSerializer js = new JavaScriptSerializer();
            return js.Serialize(DatosRetorna);

        }
    }

    
}