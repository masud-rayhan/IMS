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
    public class CountryRepository :Repository<Country>, ICountryRepository
    {


        private readonly ApplicationDbContext _db;
        public CountryRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
        public bool Update(Country country)
        {
            var obj = _db.Countries.FirstOrDefault(x => x.Id == country.Id);
            if (obj != null)
            {
                obj.Name = country.Name;
                obj.ShortName = country.ShortName;
                _db.SaveChanges();

                return true;
            }
            else
            {
                return false;
            }
        }



        public new bool Remove(Guid id)
        {
            try
            {
                var obj = _db.Countries.Where(x => x.Id == id).FirstOrDefault();
                
                 _db.Countries.Remove(obj);
                return true;
               
                
            }catch (Exception ex)
            {
                return false;
            }
            


        }

        public bool IsDeletable(Guid id)
        {
            return  !_db.Brands.Where( x=> x.CountryId==id).Any(); 
        }

    }
}
