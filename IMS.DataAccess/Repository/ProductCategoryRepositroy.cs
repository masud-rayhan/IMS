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
    public class ProductCategoryRepositroy : Repository<ProductCategory>,IProductCategoryRepository
    {
        private readonly ApplicationDbContext _db;

        public ProductCategoryRepositroy(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public bool Update(ProductCategory productCategory)
        {
            var obj = _db.ProductCategories.FirstOrDefault(x => x.Id == productCategory.Id);
            
            if (obj != null) 
            {
                obj.Name = productCategory.Name;
                obj.Description = productCategory.Description;

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
