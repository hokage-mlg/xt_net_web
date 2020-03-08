using System;
using System.Collections.Generic;
namespace Final.Entities
{
    public class Book
    {
        public Book()
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                BookImage = webClient.DownloadData("https://pics.clipartpng.com/Brown_Book_PNG_Clipart-1051.png");
            }
        }
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public byte[] BookImage { get; set; }
        public int ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public IList<int> Purchases { get; } = new List<int>();
        public override string ToString() => $"Id: {Id}. Author: {Author}. " +
            $"Title: {Title}. Genre: {Genre}. Release date: {ReleaseDate}. Price:{Price}. Count:{Count}.";
    }
}