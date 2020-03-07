using System.Collections.Generic;
using Final.Entities;

namespace Final.BLL.Interfaces
{
    public interface IBookLogic
    {
        void AddBookToPurchase(int bookId, int purchaseId);
        void RemoveBookFromPurchase(int bookId, int purchaseId);
        Book Add(Book book);
        Book GetById(int id);
        Book GetByTitle(string title);
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetBooksByAuthor(string author);
        IEnumerable<Book> GetBooksByGenre(string genre);
        IEnumerable<Book> GetBooksByPurchaseId(int purchaseId);
        bool RemoveById(int id);
        bool ChangeCount(int bookId, int count);
        bool ChangePrice(int bookId, decimal price);
        bool Update(Book book);
    }
}
