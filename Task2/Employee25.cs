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
        public Employee25(string surname, string name, string patronymic, DateTime yearOfBirdth, string post, int experience) :
            base(surname, name, patronymic, yearOfBirdth)
        {
            Post = post;
            Experience = experience;
        }
        public static Employee25 InputEmployee()
        {
            Console.WriteLine("Input surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Input name:");
            string name = Console.ReadLine();
            Console.WriteLine("Input patronymic:");
            string patronymic = Console.ReadLine();
            Console.WriteLine("Input date of birth:");
            DateTime yearOfBirdth = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Input post:");
            string post = Console.ReadLine();
            Console.WriteLine("Input experience:");
            int experience = int.Parse(Console.ReadLine());
            return new Employee25(surname, name, patronymic, yearOfBirdth, post, experience);
        }
        public string Post
        {
            get { return _post; }
            set
            {
                if (value == null && value.Length == 0)
                    throw new ArgumentException("Error! Post is empty");
                _post = value;
            }
        }
        public int Experience
        {
            get { return _experience; }
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
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine
                + string.Format("- Post: {0}\n" + "- Experience: {1}", Post, Experience);
        }
    }
}
