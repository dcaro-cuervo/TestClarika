using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IQuotationRepository : IDisposable
    {
        void InsertQuotation(Quotation quotation);

        void UpdateQuotation(Quotation quotation);

        void DeleteQuotation(Quotation quotation);

        IEnumerable<Quotation> GetQuotations(string fieldToSearch);

        Quotation GetQuotationById(int quotationId);
    }
}
