using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;

namespace Task6.BLL.Interfaces
{
    public interface IUserLogic
    {
        User Add(User user);
        User GetById(int id);
        IEnumerable<User> GetAll();
        bool RemoveById(int id);
        bool GiveAward(int id, Award award);
        bool TakeAwayAward(int id, int awardId);
    }
}
