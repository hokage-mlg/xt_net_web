using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task6.Entities;
namespace Task6.BLL.Interfaces
{
    public interface IUserWebLogic
    {
        UserWeb[] GetAll();
        UserWeb AddUser(string name, string password);
        bool AddUserRole(string login, string role);
    }
}
