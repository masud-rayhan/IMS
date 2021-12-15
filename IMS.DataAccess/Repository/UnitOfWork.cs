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

        

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Country = new CountryRepository(_db);
            Brand = new BrandRepository(_db);



        }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
