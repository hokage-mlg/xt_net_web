using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Entities;

namespace Final.BLL.Interfaces
{
    public interface IUserLogic
    {
        User AddUser(string name, string password);
        User[] GetAll();
        bool AddUserRole(string login, string role);
        bool RemoveUserRole(string login, string role);
        User GetById(int id);
        bool RemoveById(int id);
        bool MakePurchase(int id, int purchaseId);
        bool CancelPurchase(int id, int purchaseId);
        bool Update(User user);
    }
}
