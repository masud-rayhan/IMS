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
    public class SupplierRepository : Repository<Supplier> , ISupplierRepository
    {
        private readonly ApplicationDbContext _db;

        public SupplierRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public bool Update(Supplier supplier)
        {
            var obj= _db.Suppliers.FirstOrDefault(x => x.Id == supplier.Id);
            if(obj != null)
            {
                obj.Name = supplier.Name;
                obj.Address = supplier.Address;
                obj.Phone = supplier.Phone;
                obj.Email = supplier.Email;
                obj.OpeningBalance = supplier.OpeningBalance;   

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
            return !_db.Purchases.Where(x => x.SupplierId == id).Any();
        }

        public new bool Remove(Guid id)
        {
            try
            {
                var obj = _db.Suppliers.Where(x => x.Id == id).FirstOrDefault();
                _db.Suppliers.Remove(obj);
                _db.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
