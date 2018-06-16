using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestClarika.Models;

namespace TestClarika.Mapping
{
    public class MapperDTO
    {
        public static QuotationDTO MapToQuotationDTO(ConfigurationDTO configurationDTO)
        {
            var result = new QuotationDTO()
            {
                Cliente = configurationDTO.Cliente,
                TipoSeguro = configurationDTO.TipoSeguro
            };

            return result;
        }
    }
}