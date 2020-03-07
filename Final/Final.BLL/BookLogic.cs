using System.Collections.Generic;
using Final.DAL.Interfaces;
using Final.BLL.Interfaces;
using Final.Entities;

namespace Final.BLL
{
    public class BookLogic : IBookLogic
    {
        private IBookDao _bookDao;
        public BookLogic(IBookDao bookDao) { _bookDao = bookDao; }
        public void AddBookToPurchase(int bookId, int purchaseId)
        {
            _bookDao.AddBookToPurchase(bookId, purchaseId);
        }
        public void RemoveBookFromPurchase(int bookId, int purchaseId)
        {
            _bookDao.RemoveBookFromPurchase(bookId, purchaseId);
        }
        public Book Add(Book book) => _bookDao.Add(book);
        public Book GetById(int id) => _bookDao.GetById(id);
        public Book GetByTitle(string title) => _bookDao.GetByTitle(title);
        public IEnumerable<Book> GetAll() => _bookDao.GetAll();
        public IEnumerable<Book> GetBooksByAuthor(string author) => _bookDao.GetBooksByAuthor(author);
        public IEnumerable<Book> GetBooksByGenre(string genre) => _bookDao.GetBooksByGenre(genre);
        public IEnumerable<Book> GetBooksByPurchaseId(int purchaseId) => _bookDao.GetBooksByPurchaseId(purchaseId);
        public bool ChangeCount(int bookId, int count) => _bookDao.ChangeCount(bookId, count);
        public bool ChangePrice(int bookId, decimal price) => _bookDao.ChangePrice(bookId, price);
        public bool RemoveById(int id) => _bookDao.RemoveById(id);
        public bool Update(Book book) => _bookDao.Update(book);
    }
}
