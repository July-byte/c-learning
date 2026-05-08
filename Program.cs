using System;
using System.Collections.Generic;

namespace DataProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите путь к CSV файлу:");
            string path = Console.ReadLine();

            FileService fileService = new FileService();
            List<Person> persons = fileService.ReadFromCsv(path);

            if (persons.Count == 0)
            {
                Console.WriteLine("Нет данных для обработки.");
                return;
            }

            Console.WriteLine($"\nЗагружено записей: {persons.Count}");

            FilterService filterService = new FilterService();

            Console.WriteLine("\nПрименить фильтрацию? (y/n)");
            string applyFilter = Console.ReadLine();

            if (applyFilter?.ToLower() == "y")
            {
                persons = filterService.ApplyFilter(persons);
            }

            Console.WriteLine("\nРезультат:");
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
} 
