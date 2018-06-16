using DataEntity;
using DataRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Business
{
    public class QuotationRepository : IQuotationRepository, IDisposable
    {
        private GenericRepository<Cotizaciones> _quotationsRepository = new GenericRepository<Cotizaciones>(new TestCotizacionesEntities());
        private readonly IMapper iMapper;

        public QuotationRepository()
        {
            //Initialize automapper
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Quotation, Cotizaciones>();

                cfg.CreateMap<Cotizaciones, Quotation>();

            });

            iMapper = config.CreateMapper();
        }
            
        #region Data Entity

        private void Add(Cotizaciones newQuotation)
        {
            _quotationsRepository.Add(newQuotation);
            _quotationsRepository.Save();
        }

        private void Update(Cotizaciones quotationToUpdate)
        {
            _quotationsRepository.Edit(quotationToUpdate);
            _quotationsRepository.Save();
        }

        private void Remove(Cotizaciones quotationToRemove)
        {
            _quotationsRepository.Delete(quotationToRemove);
            _quotationsRepository.Save();
        }

        private IEnumerable<Cotizaciones> GetAll()
        {
            return _quotationsRepository.GetAll();
        }

        private Cotizaciones FindById(int id)
        {
            return _quotationsRepository.FindById(id);
        }

        private Cotizaciones Find(Expression<Func<Cotizaciones, bool>> predicate)
        {
            return _quotationsRepository.Find(predicate);
        }

        #endregion

        #region Data Model

        public void InsertQuotation(Quotation quotation)
        {
            Cotizaciones mappedEntity = iMapper.Map<Quotation, Cotizaciones>(quotation);
            mappedEntity.FechaVencimiento = DateTime.Today.AddYears(1);
            Add(mappedEntity);
        }

        public void UpdateQuotation(Quotation quotation)
        {
            Cotizaciones mappedEntity = iMapper.Map<Quotation, Cotizaciones>(quotation);
            Update(mappedEntity);
        }

        public void DeleteQuotation(Quotation quotationToRemove)
        {
            Cotizaciones mappedEntity = iMapper.Map<Quotation, Cotizaciones>(quotationToRemove);
            Remove(mappedEntity);
        }

        public IEnumerable<Quotation> GetQuotations(string fieldToSearch)
        {
            return iMapper.Map<IEnumerable<Cotizaciones>, IEnumerable<Quotation>>(GetAll().Where(x => x.Cliente.ToLower().Contains(fieldToSearch.ToLower()) || x.NumeroPoliza.Contains(fieldToSearch)));
        }

        public Quotation GetQuotationById(int quotationId)
        {
            var query = FindById(quotationId);
            var result = iMapper.Map<Cotizaciones, Quotation>(query);

            return result;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _quotationsRepository.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion       
    }
}
