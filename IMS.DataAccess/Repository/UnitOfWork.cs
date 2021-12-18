using IMS.DataAccess.Data;
using IMS.DataAccess.Repository.IRepository;
using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public ICountryRepository Country { get; private set; }
        public IBrandRepository Brand { get; private set; }
        public IColorRepository Color { get; private set; }
        public ICustomerRepository Customer { get; private set; }
        public IDesignationRepositoy Designation { get; private set; }
        public IEmployeeRepository Employee { get; private set; }
        public IMeasurementUnitRepository MeasurementUnit { get; private set; }
        public IProductRepository Product { get; private set; }
        public IProductCategoryRepository ProductCategory { get; private set; }
        public IPurchaseRepository Purchase { get; private set; }
        public ISellRepository Sell { get; private set; }
        public ISupplierRepository Supplier { get; private set; }
         

        

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Country = new CountryRepository(_db);
            Brand = new BrandRepository(_db);
            Color = new ColorRepository(_db);



        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public bool Save()
        {
            try
            {
                _db.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
