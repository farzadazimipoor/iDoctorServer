using AN.Core.Domain;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Shared.Models;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public interface IInvoiceRepository
    {
        Task<Invoice> GetInvoiceByIdAsync(int id);

        Task<DataTablesPagedResults<InvoiceListItemViewModel>> GetDataTableAsync(int shiftCenterId, DataTablesParameters table, InvoiceFilterViewModel filters, Lang lng = Lang.KU);
    }
}
