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
    public class MeasurementUnitRepository : Repository<MeasurementUnit> ,IMeasurementUnitRepository
    {
        private readonly ApplicationDbContext _db;

        public MeasurementUnitRepository(ApplicationDbContext db):base(db)
        {
            _db= db;
        }

        public bool Update(MeasurementUnit measurementUnit)
        {
            var obj = _db.MeasurementUnits.FirstOrDefault(x => x.Id == measurementUnit.Id);
            if (obj != null)
            {
                obj.UnitName = measurementUnit.UnitName;

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
            return _db.Products.Where(x => x.MeasurementUnitId == id).Any();
        }

        public new bool Remove(Guid id)
        {
            try
            {
                var obj = _db.MeasurementUnits.Where(x =>x.Id==id).FirstOrDefault();
                _db.MeasurementUnits.Remove(obj);

                return true;

            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
