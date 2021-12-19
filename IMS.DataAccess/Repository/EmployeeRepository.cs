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
    public class EmployeeRepository : Repository<Employee> ,IEmployeeRepository
    {
        private readonly ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public bool Update(Employee employee)
        {
            var obj = _db.Employees.FirstOrDefault(x => x.Id == employee.Id);
            if (obj != null)
            {
                obj.FirstName = employee.FirstName;
                obj.LastName = employee.LastName;
                obj.DOB = employee.DOB;
                obj.Gender = employee.Gender;
                obj.DesignationId = employee.DesignationId;
                obj.Phone = employee.Phone;
                obj.Address = employee.Address;
                obj.Email = employee.Email;
                obj.Password = employee.Password;

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
            return (!_db.Products.Where(x =>x.EmployeeId==id).Any()  
                    &&  !_db.Purchases.Where(x =>x.EmployeeId==id).Any() 
                    &&  !_db.Sells.Where(x =>x.EmployeeId==id).Any()   );
        }


        public new bool Remove(Guid id)
        {
            try
            {
                var obj = _db.Employees.Where(x => x.Id == id).FirstOrDefault();
                _db.Employees.Remove(obj);
                _db.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
