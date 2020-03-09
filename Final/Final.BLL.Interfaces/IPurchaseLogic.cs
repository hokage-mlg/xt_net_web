using System.Collections.Generic;
using Final.Entities;

namespace Final.BLL.Interfaces
{
    public interface IPurchaseLogic
    {
        void AddPurchaseToUser(int purchaseId, int userId);
        void RemovePurchaseFromUser(int purchaseId, int userId);
        Purchase Add(Purchase purchase);
        Purchase GetById(int id);
        IEnumerable<Purchase> GetAll();
        IEnumerable<Purchase> GetPurchasesByUserId(int userId);
        bool ChangeFullname(int purchaseId, string fullname);
        bool ChangePhoneNumber(int purchaseId, string phoneNumber);
        bool ChangeAddress(int purchaseId, string address);
        bool RemoveAll();
        bool RemoveById(int id);
        bool Update(Purchase purchase);
    }
}