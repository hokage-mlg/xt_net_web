using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;

namespace Task6.DAL.Interfaces
{
    public interface IUserDao
    {
        User Add(User user);
        User GetById(int id);
        IEnumerable<User> GetAll();
        bool RemoveById(int id);
        bool GiveAward(int id, Award award);
    }
}
