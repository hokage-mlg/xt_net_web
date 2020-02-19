using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Task6.Entities
{
    public class User
    {
        public User()
        {
            using (System.Net.WebClient webClient = new System.Net.WebClient())
            {
                UserImage = webClient.DownloadData("https://i.pinimg.com/originals/51/f6/fb/51f6fb256629fc755b8870c801092942.png");
            }
            _awards = new Dictionary<int, Award>();
        }
        public Dictionary<int, Award> _awards;
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] UserImage { get; set; }
        
        public Dictionary<int, Award> Awards
        {
            get { return _awards; }
            set { _awards = value; }
        }
        public int Age
        {
            get
            {
                DateTime nowDate = DateTime.Today;
                int age = nowDate.Year - DateOfBirth.Year;
                if (DateOfBirth > nowDate.AddYears(-age)) age--;
                return age;
            }
        }
        public bool AddAward(Award award)
        {
            try
            {
                Awards.Add(award.Id, award);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override string ToString()
        {
            StringBuilder userSB = new StringBuilder();
            userSB.Append($"ID: {Id}.\n Name: {Name}.\n " +
                $"Date of birth: {DateOfBirth.ToShortDateString()}.\n Age: {Age}.\n");
            if (Awards.Count != 0)
            {
                userSB.Append("Awards:\n");
                foreach (var i in Awards)
                    userSB.Append($" {i.Value.Title}\n");
            }
            return userSB.ToString();
        }
    }
}
