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
    public class DesignationRepository : Repository<Designation>, IDesignationRepositoy
    {
        private readonly ApplicationDbContext _db;

        public DesignationRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
        public bool Update(Designation designation)
        {
            var obj= _db.Designations.FirstOrDefault(x => x.Id == designation.Id);
            if (obj != null)
            {
                obj.Name = designation.Name;

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
            return !_db.Employees.Where(x => x.DesignationId == id).Any();
        }

        public new bool Remove(Guid id)
        {
            try
            {
                var obj = _db.Designations.Where(x => x.Id == id).FirstOrDefault();
                _db.Designations.Remove(obj);
                _db.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }

    }
}
