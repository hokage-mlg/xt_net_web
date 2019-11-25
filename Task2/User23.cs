using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class User23
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public DateTime YearOfBirdth { get; set; }
        public int UserAge { get { return GetAge(YearOfBirdth); } }
        public User23()
        {
            Console.WriteLine("Input surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Input name:");
            string name = Console.ReadLine();
            Console.WriteLine("Input patronymic:");
            string patronymic = Console.ReadLine();
            Console.WriteLine("Input bthDay:");
            DateTime yearOfBirdth = DateTime.Parse(Console.ReadLine());
            Surname = surname;
            Name = name;
            Patronymic = patronymic;
            YearOfBirdth = yearOfBirdth;
        }
        public static int GetAge(DateTime birthDate)
        {
            var now = DateTime.Today;
            return now.Year - birthDate.Year - 1 +
                ((now.Month > birthDate.Month || now.Month == birthDate.Month && now.Day >= birthDate.Day) ? 1 : 0);
        }
        public override string ToString()
        {
            return (string.Format("User:\n" +
                "- Surname: {0}\n" +
                "- Name: {1}\n" +
                "- Patronymic: {2}\n" +
                "- YearOfBirdth: {3}\n" +
                "- Age: {4}", Surname, Name, Patronymic, YearOfBirdth.ToString("MM/dd/yyyy"), UserAge));
        }
    }
}
