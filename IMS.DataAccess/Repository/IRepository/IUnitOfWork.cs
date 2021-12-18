using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork :IDisposable
    {
        IBrandRepository Brand { get; }
        IColorRepository Color { get; }
        ICountryRepository Country { get;}
        ICustomerRepository Customer { get; }
        IDesignationRepositoy Designation { get; }
        IProductRepository Product { get;}
        IProductCategoryRepository ProductCategory { get; }
        IPurchaseRepository Purchase { get; }
        ISellRepository Sell { get; }
        ISupplierRepository Supplier { get; }
        IEmployeeRepository Employee { get;}
        IMeasurementUnitRepository MeasurementUnit { get;}
        
        bool Save();
    }
}
