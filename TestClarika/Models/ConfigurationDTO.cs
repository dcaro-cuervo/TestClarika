using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestClarika.Models
{
    public class ConfigurationDTO
    {
        [Required]
        public string Cliente { get; set; }

        [Required]
        [Display(Name = "Tipo de Seguro")]
        public string TipoSeguro { get; set; }

        [Display(Name = "Fecha de Vencimiento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        public System.DateTime FechaVencimiento { get; set; }
    }
}