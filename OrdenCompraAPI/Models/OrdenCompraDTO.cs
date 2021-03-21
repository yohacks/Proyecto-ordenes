using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrdenCompraAPI.Models
{
    public class OrdenCompraDTO
    {
        public DateTime Fecha { get; set; }
        public int ID { get; set; }
        public string NombreVendedor { get; set; }
        public string DireccionVendedor { get; set; }
        public string TelefonoVendedor { get; set; }
        public string NombreComprador { get; set; }
        public string DireccionComprador { get; set; }
        public string TelefonoComprador { get; set; }
        public string Ciudad { get; set; }
        public string Valor { get; set; }
        public string ValorIva { get; set; }
        public string AutorizadoPor { get; set; }
        public string Observaciones { get; set; }
    }
}