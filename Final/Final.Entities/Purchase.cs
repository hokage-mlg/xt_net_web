using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.Entities
{
    public class Purchase
    {
        public Purchase() { _books = new Dictionary<int, Book>(); }
        private Dictionary<int, Book> _books;
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public IList<int> Users { get; } = new List<int>();
        public Dictionary<int, Book> Books
        {
            get { return _books; }
            set { _books = value; }
        }
        public bool AddBook(Book book)
        {
            try
            {
                Books.Add(book.Id, book);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override string ToString()
        {
            var purchaseSB = new StringBuilder();
            purchaseSB.Append($"Id:{Id}. Full name: {FullName}. " +
                $"Phone number: {PhoneNumber}. Adress: {Address}.");
            if (Books.Count != 0)
            {
                purchaseSB.Append("Books:\n");
                foreach (var i in Books)
                    purchaseSB.Append($"{i.Value}\n");
            }
            return purchaseSB.ToString();
        }
    }
}
