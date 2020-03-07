using System.Collections.Generic;
using Final.Entities;

namespace Final.DAL.Interfaces
{
    public interface IPurchaseDao
    {
        void AddPurchaseToUser(int purchaseId, int userId);
        void RemovePurchaseFromUser(int purchaseId, int userId);
        Purchase Add(Purchase purchase);
        Purchase GetById(int id);
        IEnumerable<Purchase> GetAll();
        IEnumerable<Purchase> GetPurchasesByUserId(int userId);
        bool RemoveById(int id);
        bool ChangeFullname(int purchaseId, string fullname);
        bool ChangePhoneNumber(int purchaseId, string phoneNumber);
        bool ChangeAddress(int purchaseId, string address);
        bool Update(Purchase purchase);
    }
}
