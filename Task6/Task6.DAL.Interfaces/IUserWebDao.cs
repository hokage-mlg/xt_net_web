using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.DAL.Interfaces
{
    public interface IUserWebDao
    {
        bool Add(Entities.UserWeb user);
        IEnumerable<Entities.UserWeb> GetAll();
        bool AddUserRole(string login, string role);
    }
}
