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
    public class PurchaseRepository : Repository<Purchase> , IPurchaseRepository
    {
        private readonly ApplicationDbContext _db;

        public PurchaseRepository(ApplicationDbContext db):base(db)
        {
            _db = db;
        }

        public bool Update(Purchase purchase)
        {
            var obj = _db.Purchases.FirstOrDefault(x => x.Id == purchase.Id);

            if (obj != null)
            {
                obj.ProductId = purchase.ProductId;
                obj.Quantity = purchase.Quantity;
                obj.UnitPrice = purchase.UnitPrice;
                obj.Tax= purchase.Tax;
                obj.ShppingCost= purchase.ShppingCost;
                obj.OtherCost= purchase.OtherCost;
                obj.TotalCost= purchase.TotalCost;
                obj.CostPerProduct= purchase.CostPerProduct;
                obj.Paid = purchase.Paid;
                obj.Due = purchase.Due;
                obj.ChallanNumber = purchase.ChallanNumber;
                obj.SupplierId = purchase.SupplierId;
                obj.EmployeeId = purchase.EmployeeId;
                obj.Status = purchase.Status;
                obj.Remark= purchase.Remark;
                obj.Time = purchase.Time;

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
            return true;
        }

        public new bool Remove(Guid id)
        {
            try
            {
                var obj= _db.Purchases.Where(x => x.Id == id).FirstOrDefault();
                _db.Purchases.Remove(obj);
                _db.SaveChanges();
                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
