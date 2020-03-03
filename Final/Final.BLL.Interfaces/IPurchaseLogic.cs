using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Entities;

namespace Final.BLL.Interfaces
{
    public interface IPurchaseLogic
    {
        Purchase Add(Purchase purchase);
        Purchase GetById(int id);
        IEnumerable<Purchase> GetAll();
        void AddPurchaseToUser(int purchaseId, int userId);
        void RemovePurchaseFromUser(int purchaseId, int userId);
        bool Update(Purchase purchase);
    }
}
