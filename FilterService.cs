using System;
using System.Collections.Generic;
using System.Linq;

namespace DataProcessor
{
    public class FilterService
    {
        public List<Person> ApplyFilter(List<Person> persons)
        {
            Console.WriteLine("\nВыберите поле для фильтрации:");
            Console.WriteLine("1 - Возраст");
            Console.WriteLine("2 - Категория");
            Console.WriteLine("3 - Зарплата");
            Console.WriteLine("4 - Дата регистрации");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return FilterByAge(persons);

                case "2":
                    return FilterByCategory(persons);

                case "3":
                    return FilterBySalary(persons);

                case "4":
                    return FilterByDate(persons);

                default:
                    Console.WriteLine("Неверный выбор.");
                    return persons;
            }
        }

        private List<Person> FilterByAge(List<Person> persons)
        {
            Console.WriteLine("Введите минимальный возраст:");
            if (int.TryParse(Console.ReadLine(), out int minAge))
            {
                var result = persons
                    .Where(p => p.Age >= minAge)
                    .ToList();

                ShowResultCount(result);
                return result;
            }

            Console.WriteLine("Некорректный ввод.");
            return persons;
        }

        private List<Person> FilterByCategory(List<Person> persons)
        {
            Console.WriteLine("Введите категорию (contains):");
            string category = Console.ReadLine();

            var result = persons
                .Where(p => p.Category.Contains(category, StringComparison.OrdinalIgnoreCase))
                .ToList();

            ShowResultCount(result);
            return result;
        }

        private List<Person> FilterBySalary(List<Person> persons)
        {
            Console.WriteLine("Введите минимальную зарплату:");
            if (decimal.TryParse(Console.ReadLine(), out decimal minSalary))
            {
                var result = persons
                    .Where(p => p.Salary >= minSalary)
                    .ToList();

                ShowResultCount(result);
                return result;
            }

            Console.WriteLine("Некорректный ввод.");
            return persons;
        }

        private List<Person> FilterByDate(List<Person> persons)
        {
            Console.WriteLine("Введите дату регистрации (yyyy-MM-dd):");

            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                var result = persons
                    .Where(p => p.RegistrationDate >= date)
                    .ToList();

                ShowResultCount(result);
                return result;
            }

            Console.WriteLine("Некорректный ввод.");
            return persons;
        }

        private void ShowResultCount(List<Person> result)
        {
            if (!result.Any())
                Console.WriteLine("По заданным критериям ничего не найдено.");
            else
                Console.WriteLine($"Найдено записей: {result.Count}");
        }
    }
} 
