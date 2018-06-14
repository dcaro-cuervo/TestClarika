using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class Quotation
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string TipoSeguro { get; set; }
        public string FormaPago { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public System.DateTime FechaCotizacion { get; set; }
        public bool Activa { get; set; }
        public string NumeroPoliza { get; set; }
    }
}
