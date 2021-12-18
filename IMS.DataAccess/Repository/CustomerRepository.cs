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
    public class CustomerRepository : Repository<Customer> , ICustomerRepository
    {
        private readonly ApplicationDbContext _db;

        public CustomerRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public bool Update(Customer customer)
        {
            var obj= _db.Customers.FirstOrDefault(x => x.Id == customer.Id);
            if (obj != null)
            {
                obj.Name = customer.Name;
                obj.Phone = customer.Phone;
                obj.Address = customer.Address;
                obj.Email = customer.Email;
                obj.OpeningBalance = customer.OpeningBalance;

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
