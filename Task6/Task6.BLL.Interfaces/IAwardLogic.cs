using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;

namespace Task6.BLL.Interfaces
{
    public interface IAwardLogic
    {
        Award Add(Award award);
        Award GetById(int id);
        IEnumerable<Award> GetAll();
        bool RemoveById(int id);
        void AddUserToAward(int awardId, int userId);
        void RemoveUserFromAward(int awardId, int userId);
        IEnumerable<Award> GetAwardsByUserId(int userId);
    }
}
