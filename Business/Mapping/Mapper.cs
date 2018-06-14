using AutoMapper;
using DataEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    public class Mapper
    {
        public static void CreateMap()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Quotation, Cotizaciones>();

                cfg.CreateMap<Cotizaciones, Quotation>();

            });
        }
    }
}
