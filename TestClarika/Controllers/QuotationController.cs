using AutoMapper;
using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestClarika.Mapping;
using TestClarika.Models;

namespace TestClarika.Controllers
{
    public class QuotationController : Controller
    {
        private IQuotationRepository quotationRepository;
        private readonly IMapper iMapper;

        public QuotationController()
        {
            this.quotationRepository = new QuotationRepository();

            //Initialize automapper
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Quotation, QuotationDTO>();
                cfg.CreateMap<ConfigurationDTO, Quotation>();

                cfg.CreateMap<QuotationDTO, Quotation>();
                cfg.CreateMap<QuotationDTO, ConfigurationDTO>();

            });

            iMapper = config.CreateMapper();
        }

        public QuotationController(IQuotationRepository quotationRepository)
        {
            this.quotationRepository = quotationRepository;
        }

        // GET: Quotation
        public ActionResult Index(string search)
        {
            if (String.IsNullOrEmpty(search))
                search = String.Empty;

            IEnumerable<QuotationDTO> quotationList = iMapper.Map<IEnumerable<Quotation>, IEnumerable<QuotationDTO>>(quotationRepository.GetQuotations(search));

            return View(quotationList);
        }

        // GET: Quotation/Configuration
        public ActionResult Configuration(string client, string typeSecurity)
        {
            var configurationDTO = new ConfigurationDTO { FechaVencimiento = DateTime.Today.AddYears(1) };

            if (!String.IsNullOrEmpty(client))
            {
                configurationDTO.Cliente = client;
                configurationDTO.TipoSeguro = typeSecurity;
            }

            return View(configurationDTO);
        }

        // POST: Quotation/Configuration
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Configuration(ConfigurationDTO configuration)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                return RedirectToAction("Create", new { Cliente = configuration.Cliente, TipoSeguro = configuration.TipoSeguro });
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", "Error when add quotation" + exception.Message);
                return View();
            }
        }

        // GET: Quotation/Create
        public ActionResult Create(ConfigurationDTO configurationModel)
        {
            var quotationDTO = MapperDTO.MapToQuotationDTO(configurationModel);
            quotationDTO.FechaCotizacion = DateTime.Today;
            quotationDTO.Activa = true;
            return View(quotationDTO);
        }

        // POST: Quotation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QuotationDTO quotation)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                // TODO: Add insert logic here
                quotationRepository.InsertQuotation(iMapper.Map<QuotationDTO, Quotation>(quotation));

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                ModelState.AddModelError("", "Error when add quotation" + exception.Message);
                return View();
            }
        }
    }
}
