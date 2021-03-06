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
    public class BrandRepository :Repository<Brand> , IBrandRepository
    {
        private readonly ApplicationDbContext _db;

        public BrandRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public bool Update(Brand brand)
        {
            var obj = _db.Brands.FirstOrDefault(x => x.Id == brand.Id);
            if(obj != null)
            {
                obj.Name = brand.Name;
                obj.CountryId = brand.CountryId;
                

                _db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsDeletable(Guid id)
        {
            return !_db.Products.Where(x => x.ProductCategoryId == id).Any();
        }

        new bool Remove(Guid id)
        {
            try
            {
                var obj = _db.Brands.Where(x => x.Id == id).FirstOrDefault();
                _db.Brands.Remove(obj);
                _db.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }

        }

    }
}
