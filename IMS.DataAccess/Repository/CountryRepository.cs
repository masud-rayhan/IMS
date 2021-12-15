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

        public void Update(Country country)
        {
            var obj=_db.Countries.FirstOrDefault(x => x.Id == country.Id);
            if(obj != null)
            {
                obj.Name = country.Name;
                obj.ShortName = country.ShortName;
                _db.SaveChanges();
            }
        }
    }
}
