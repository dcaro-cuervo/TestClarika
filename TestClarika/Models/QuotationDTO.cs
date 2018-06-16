using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestClarika.Models
{
    public class QuotationDTO : ConfigurationDTO
    {
        public int Id { get; set; }        

        [Required]
        [Display(Name = "Forma de Pago")]
        public string FormaPago { get; set; }        

        [Required]
        [Display(Name = "Fecha de Cotización")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "date is not a corret format")]
        public System.DateTime FechaCotizacion { get; set; }

        public bool Activa { get; set; }
                
        [Display(Name = "Numero de Poliza")]
        public string NumeroPoliza { get; set; }        
    }
}