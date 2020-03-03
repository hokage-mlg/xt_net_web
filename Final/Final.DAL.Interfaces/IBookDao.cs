using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Entities;

namespace Final.DAL.Interfaces
{
    public interface IBookDao
    {
        Book Add(Book book);
        Book GetById(int id);
        Book GetByTitle(string title);
        IEnumerable<Book> GetAll();
        bool RemoveById(int id);
        event Action<int> DeleteBook;
        void FilterByGenre(string genre);
        void AddBookToPurchase(int bookId, int purchaseId);
        void RemoveBookFromPurchase(int bookId, int purchaseId);
        void OnDeletePurchaseHandler(int purchaseId);
        IEnumerable<Book> GetBooksByPurchaseId(int purchaseId);
        bool ChangeCount(int bookId, int count);
        bool ChangePrice(int bookId, decimal price);
        bool Update(Book book);
    }
}
