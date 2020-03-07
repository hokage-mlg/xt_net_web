using System.Collections.Generic;
using Final.Entities;

namespace Final.DAL.Interfaces
{
    public interface IUserDao
    {
        User GetById(int id);
        User GetByLogin(string login);
        IEnumerable<User> GetAll();
        IEnumerable<User> GetUsersByPurchaseId(int purchaseId);
        bool Add(User user);
        bool AddUserRole(string login, string role);
        bool RemoveUserRole(string login, string role);
        bool RemoveById(int id);
        bool MakePurchase(int id, int purchaseId);
        bool CancelPurchase(int id, int purchaseId);
        bool ChangePassword(int userId, string password);
        bool Update(User user);
    }
}
