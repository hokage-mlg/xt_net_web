using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6.Entities
{
    public class Award
    {
        public Award()
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                AwardImage = webClient.DownloadData("https://i.pinimg.com/236x/85/65/02/856502a5f264883834fb0707fa68b4f6.jpg");
            }
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public IList<int> Users { get; } = new List<int>();
        public byte[] AwardImage { get; set; }
        public override string ToString() => $"ID: {Id}. Title: {Title}.";
    }
}
