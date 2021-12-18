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
    public class ProductRepository : Repository<Product>,IProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db): base(db)
        {
            _db= db;
        }

        public bool Update(Product product)
        {
            var obj =_db.Products.FirstOrDefault(x => x.Id == product.Id);

            if (obj != null)
            {
                obj.Name = product.Name;
                obj.ProductCategoryId = product.ProductCategoryId;
                obj.BrandId = product.BrandId;
                obj.MfgDate= product.MfgDate;
                obj.ExpDate= product.ExpDate;
                obj.PerBox = product.PerBox;
                obj.MeasurementUnitId = product.MeasurementUnitId;
                obj.Size = product.Size;
                obj.ColorId= product.ColorId;
                obj.ImageUrl = product.ImageUrl;
                obj.Description = product.Description;
                obj.EmployeeId = product.EmployeeId;
                obj.Time = product.Time;

                _db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
