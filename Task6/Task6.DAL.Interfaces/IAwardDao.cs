using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;

namespace Task6.DAL.Interfaces
{
    public interface IAwardDao
    {
        Award Add(Award award);
        Award GetById(int id);
        IEnumerable<Award> GetAll();
        bool RemoveById(int id);
        event Action<int> DeleteAward;
        void AddUserToAward(int awardId, int userId);
        void RemoveUserFromAward(int awardId, int userId);
        void OnDeleteUserHandler(int userId);
        IEnumerable<Award> GetAwardsByUserId(int userId);
    }
}
