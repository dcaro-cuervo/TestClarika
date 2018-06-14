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
        private Repository<Cotizaciones> _quotationsRepository = new Repository<Cotizaciones>(new TestCotizacionesEntities());

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
            Cotizaciones mappedEntity = Mapper.Map<Quotation, Cotizaciones>(quotation);
            Add(mappedEntity);
        }

        public void UpdateQuotation(Quotation quotation)
        {
            Cotizaciones mappedEntity = Mapper.Map<Quotation, Cotizaciones>(quotation);
            Update(mappedEntity);
        }

        public void DeleteQuotation(Quotation quotationToRemove)
        {
            Cotizaciones mappedEntity = Mapper.Map<Quotation, Cotizaciones>(quotationToRemove);
            Remove(mappedEntity);
        }

        public IEnumerable<Quotation> GetQuotations()
        {
            return Mapper.Map<IEnumerable<Cotizaciones>, IEnumerable<Quotation>>(GetAll());
        }

        public Quotation GetQuotationById(int quotationId)
        {
            var query = FindById(quotationId);
            var result = Mapper.Map<Cotizaciones, Quotation>(query);

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
