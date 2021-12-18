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
    public class SellRepository : Repository<Sell> ,ISellRepository
    {
        private readonly ApplicationDbContext _db;

        public SellRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public bool Update(Sell sell)
        {
            var obj = _db.Sells.FirstOrDefault(x => x.Id == sell.Id);

            if (obj != null)
            {
                obj.ProductId = sell.ProductId;
                obj.UnitPrice = sell.UnitPrice;
                obj.TotalPrice = sell.TotalPrice;
                obj.Discount = sell.Discount; 
                obj.Paid =sell.Paid;
                obj.Due = sell.Due;
                obj.EmployeeId = sell.EmployeeId;
                obj.CustomerId = sell.CustomerId;
                obj.Status = sell.Status;
                obj.Remark = sell.Remark;
                obj.Time = sell.Time;

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
