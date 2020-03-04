using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.DAL.Interfaces;
using Final.Entities;
using System.Data;
using System.Data.SqlClient;

namespace FinalDAL
{
    public class BookDao : IBookDao
    {
        public event Action<int> DeleteBook;
        private static string _con_str = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        public Book Add(Book book)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_InsertBook", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Author", book.Author);
                cmd.Parameters.AddWithValue("Title", book.Title);
                cmd.Parameters.AddWithValue("Genre", book.Genre);
                cmd.Parameters.AddWithValue("BookImage", Convert.ToBase64String(book.BookImage));
                cmd.Parameters.AddWithValue("ReleaseDate", book.ReleaseDate);
                cmd.Parameters.AddWithValue("Price", book.Price);
                cmd.Parameters.AddWithValue("Quantity", book.Count);
                int mod = (int)cmd.ExecuteScalar();
                book.Id = mod;
            }
            return book;
        }
        public void AddBookToPurchase(int bookId, int purchaseId)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_AddBookToPurchase", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdBook", bookId);
                cmd.Parameters.AddWithValue("IdPurchase", purchaseId);
                var res = cmd.ExecuteNonQuery();
            }
        }
        public bool ChangeCount(int bookId, int count)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_ChangeQuantity", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", bookId);
                cmd.Parameters.AddWithValue("Quantity", count);
                var res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
        public bool ChangePrice(int bookId, decimal price)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_ChangePrice", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", bookId);
                cmd.Parameters.AddWithValue("Price", price);
                var res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
        public void FilterByGenre(string genre)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Book> GetAll()
        {
            using (var connect = new SqlConnection(_con_str))
            {
                List<Book> books = new List<Book>();
                connect.Open();
                var cmd = new SqlCommand("procedure_GetAllBooks", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    books.Add(new Book
                    {
                        Id = (int)res["Id"],
                        Author = (string)res["Author"],
                        Title = (string)res["Title"],
                        Genre = (string)res["Genre"],
                        BookImage = Convert.FromBase64String((string)res["BookImage"]),
                        ReleaseDate = (int)res["ReleaseDate"],
                        Price = (decimal)res["Price"],
                        Count = (int)res["Quantity"]
                    });
                }
                return books;
            }
        }
        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                List<Book> books = new List<Book>();
                connect.Open();
                var cmd = new SqlCommand("procedure_GetBookByAuthor", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Author", author);
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    books.Add(new Book
                    {
                        Id = (int)res["Id"],
                        Author = (string)res["Author"],
                        Title = (string)res["Title"],
                        Genre = (string)res["Genre"],
                        BookImage = Convert.FromBase64String((string)res["BookImage"]),
                        ReleaseDate = (int)res["ReleaseDate"],
                        Price = (decimal)res["Price"],
                        Count = (int)res["Quantity"]
                    });
                }
                return books;
            }
        }
        public IEnumerable<Book> GetBooksByGenre(string genre)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                List<Book> books = new List<Book>();
                connect.Open();
                var cmd = new SqlCommand("procedure_GetBookByGenre", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Genre", genre);
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    books.Add(new Book
                    {
                        Id = (int)res["Id"],
                        Author = (string)res["Author"],
                        Title = (string)res["Title"],
                        Genre = (string)res["Genre"],
                        BookImage = Convert.FromBase64String((string)res["BookImage"]),
                        ReleaseDate = (int)res["ReleaseDate"],
                        Price = (decimal)res["Price"],
                        Count = (int)res["Quantity"]
                    });
                }
                return books;
            }
        }
        public IEnumerable<Book> GetBooksByPurchaseId(int purchaseId)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                List<Book> books = new List<Book>();
                connect.Open();
                var cmd = new SqlCommand("procedure_GetBooksByPurchaseId", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", purchaseId);
                var res = cmd.ExecuteReader();
                while (res.Read())
                {
                    books.Add(new Book
                    {
                        Id = (int)res["Id"],
                        Author = (string)res["Author"],
                        Title = (string)res["Title"],
                        Genre = (string)res["Genre"],
                        BookImage = Convert.FromBase64String((string)res["BookImage"]),
                        ReleaseDate = (int)res["ReleaseDate"],
                        Price = (decimal)res["Price"],
                        Count = (int)res["Quantity"]
                    });
                }
                return books;
            }
        }
        public Book GetById(int id)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_GetBookById", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);
                var res = cmd.ExecuteReader();
                if (res.Read())
                {
                    return new Book
                    {
                        Id = (int)res["Id"],
                        Author = (string)res["Author"],
                        Title = (string)res["Title"],
                        Genre = (string)res["Genre"],
                        BookImage = Convert.FromBase64String((string)res["BookImage"]),
                        ReleaseDate = (int)res["ReleaseDate"],
                        Price = (decimal)res["Price"],
                        Count = (int)res["Quantity"]
                    };
                }
                return null;
            }
        }
        public Book GetByTitle(string title)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_GetBookByTitle", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Title", title);
                var res = cmd.ExecuteReader();
                if (res.Read())
                {
                    return new Book
                    {
                        Id = (int)res["Id"],
                        Author = (string)res["Author"],
                        Title = (string)res["Title"],
                        Genre = (string)res["Genre"],
                        BookImage = Convert.FromBase64String((string)res["BookImage"]),
                        ReleaseDate = (int)res["ReleaseDate"],
                        Price = (decimal)res["Price"],
                        Count = (int)res["Quantity"]
                    };
                }
                return null;
            }
        }
        public void RemoveBookFromPurchase(int bookId, int purchaseId)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_RemoveBookFromPurchase", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("IdBook", bookId);
                cmd.Parameters.AddWithValue("IdPurchase", purchaseId);
                var res = cmd.ExecuteNonQuery();
            }
        }
        public bool RemoveById(int id)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_RemoveBookById", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Id", id);
                var res = cmd.ExecuteNonQuery();
                return res != 0;
            }
        }
        public bool Update(Book book)
        {
            using (var connect = new SqlConnection(_con_str))
            {
                connect.Open();
                var cmd = new SqlCommand("procedure_UpdateBook", connect);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Author", book.Author);
                cmd.Parameters.AddWithValue("@Title", book.Title);
                cmd.Parameters.AddWithValue("@Genre", book.Genre);
                cmd.Parameters.AddWithValue("@AwardImage", Convert.ToBase64String(book.BookImage));
                cmd.Parameters.AddWithValue("@ReleaseDate", book.ReleaseDate);
                cmd.Parameters.AddWithValue("@Price", book.Price);
                cmd.Parameters.AddWithValue("@Quantity", book.Count);
                var res = cmd.ExecuteNonQuery();
                return res != 0 ? true : false;
            }
        }
        #region Not Implemented
        public void OnDeletePurchaseHandler(int purchaseId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
