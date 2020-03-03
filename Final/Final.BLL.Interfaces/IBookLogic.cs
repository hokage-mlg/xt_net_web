using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Entities;

namespace Final.BLL.Interfaces
{
    public interface IBookLogic
    {
        Book Add(Book book);
        Book GetById(int id);
        Book GetByTitle(string title);
        IEnumerable<Book> GetAll();
        bool RemoveById(int id);
        void FilterByGenre(string genre);
        void AddBookToPurchase(int bookId, int purchaseId);
        void RemoveBookFromPurchase(int bookId, int purchaseId);
        IEnumerable<Book> GetBooksByPurchaseId(int purchaseId);
        bool ChangeCount(int bookId, int count);
        bool ChangePrice(int bookId, decimal price);
        bool Update(Book book);
    }
}
