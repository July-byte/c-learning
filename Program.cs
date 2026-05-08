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
            SortService sortService = new SortService();

            // --- ФИЛЬТРАЦИЯ ---
            Console.WriteLine("\nПрименить фильтрацию? (y/n)");
            string applyFilter = Console.ReadLine();

            if (applyFilter?.ToLower() == "y")
            {
                persons = filterService.ApplyFilter(persons);
            }

            // --- СОРТИРОВКА ---
            Console.WriteLine("\nПрименить сортировку? (y/n)");
            string applySort = Console.ReadLine();

            if (applySort?.ToLower() == "y")
            {
                persons = sortService.ApplySorting(persons);
            }

            // --- ВЫВОД ---
            Console.WriteLine("\nРезультат обработки:");
            foreach (var person in persons)
            {
                Console.WriteLine(person);
            }

            Console.WriteLine("\nНажмите Enter для выхода...");
            Console.ReadLine();
        }
    }
} 
