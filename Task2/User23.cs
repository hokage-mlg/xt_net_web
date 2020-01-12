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
        public int UserAge { get => GetAge(YearOfBirdth); }
        public User23(string Surname, string Name, string Patronymic, DateTime YearOfBirdth)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.Patronymic = Patronymic;
            this.YearOfBirdth = YearOfBirdth;
        }
        public static User23 InputUser()
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
                return new User23(surname, name, patronymic, yearOfBirdth);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Incorrect input:\n", e.Message);
            }
        }
        public static int GetAge(DateTime birthDate)
        {
            var now = DateTime.Today;
            return now.Year - birthDate.Year - 1 +
                ((now.Month > birthDate.Month || now.Month == birthDate.Month && now.Day >= birthDate.Day) ? 1 : 0);
        }
        public override string ToString() =>
            string.Format($"User:\n" +
                $"- Surname: {Surname}\n" +
                $"- Name: {Name}\n" +
                $"- Patronymic: {Patronymic}\n" +
                $"- Date of birth: {YearOfBirdth.ToString("MM/dd/yyyy")}\n" +
                $"- Age: {UserAge}");
    }
}
