using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.DataAccess.Repository.IRepository
{
    public interface IBrandRepository : IRepository<Brand>
    {
        new bool Remove(Guid id);
        bool IsDeletable(Guid id);
        bool Update(Brand brand);
    }
}
