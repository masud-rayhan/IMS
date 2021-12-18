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
    public class ColorRepository : Repository<Color>, IColorRepository
    {
        private readonly ApplicationDbContext _db;

        public ColorRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public bool Update(Color color)
        {
            var obj = _db.Colors.FirstOrDefault(x => x.Id == color.Id);
            if (obj != null)
            {
                obj.Name = color.Name;
                obj.RGB = color.RGB;

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
