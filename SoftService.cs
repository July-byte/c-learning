using System;
using System.Collections.Generic;
using System.Linq;

namespace DataProcessor
{
    public class SortService
    {
        public List<Person> ApplySorting(List<Person> persons)
        {
            Console.WriteLine("\nВыберите поле для сортировки:");
            Console.WriteLine("1 - Имя");
            Console.WriteLine("2 - Возраст");
            Console.WriteLine("3 - Зарплата");
            Console.WriteLine("4 - Дата регистрации");

            string fieldChoice = Console.ReadLine();

            Console.WriteLine("Выберите порядок:");
            Console.WriteLine("1 - По возрастанию");
            Console.WriteLine("2 - По убыванию");

            string orderChoice = Console.ReadLine();
            bool descending = orderChoice == "2";

            IEnumerable<Person> sorted;

            switch (fieldChoice)
            {
                case "1":
                    sorted = descending
                        ? persons.OrderByDescending(p => p.Name)
                        : persons.OrderBy(p => p.Name);
                    break;

                case "2":
                    sorted = descending
                        ? persons.OrderByDescending(p => p.Age)
                        : persons.OrderBy(p => p.Age);
                    break;

                case "3":
                    sorted = descending
                        ? persons.OrderByDescending(p => p.Salary)
                        : persons.OrderBy(p => p.Salary);
                    break;

                case "4":
                    sorted = descending
                        ? persons.OrderByDescending(p => p.RegistrationDate)
                        : persons.OrderBy(p => p.RegistrationDate);
                    break;

                default:
                    Console.WriteLine("Неверный выбор.");
                    return persons;
            }

            return sorted.ToList();
        }
    }
}
