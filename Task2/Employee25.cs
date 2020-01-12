using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Employee25 : User23
    {
        private string _post;
        private int _experience;
        public Employee25(string Surname, string Name, string Patronymic, DateTime YearOfBirdth, string Post, int Experience) :
            base(Surname, Name, Patronymic, YearOfBirdth)
        {
            this.Post = Post;
            this.Experience = Experience;
        }
        public static Employee25 InputEmployee()
        {
            try
            {
                Console.WriteLine("Input surname:");
                var surname = Console.ReadLine();
                Console.WriteLine("Input name:");
                var name = Console.ReadLine();
                Console.WriteLine("Input patronymic:");
                var patronymic = Console.ReadLine();
                Console.WriteLine("Input date of birth:");
                var yearOfBirdth = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Input post:");
                var post = Console.ReadLine();
                Console.WriteLine("Input experience:");
                var experience = int.Parse(Console.ReadLine());
                return new Employee25(surname, name, patronymic, yearOfBirdth, post, experience);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Incorrect input:\n", e.Message);
            }
        }
        public string Post
        {
            get => _post;
            set
            {
                if (value == null && value.Length == 0)
                    throw new ArgumentException("Error! Post is empty");
                _post = value;
            }
        }
        public int Experience
        {
            get => _experience;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Error! Experience cannot be < 0");
                else if (value >= UserAge)
                    throw new ArgumentException("Error! Experience cannot be bigger than age");
                else
                    _experience = value;
            }
        }
        public override string ToString() =>
            base.ToString() + Environment.NewLine
                + string.Format($"- Post: {Post}\n- Experience: {Experience}");
    }
}
