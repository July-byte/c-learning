using System;
using System.Collections.Generic;
namespace DataProcessor
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Введите путь к CVS-файлу:");
      string path = Console.ReadLine();
      FileService fileService = new FileService();
      List<Person> persons = fileService.ReadFromCvs(path);
      Console.WriteLine($"\nЗагружено записей: {persons.Count}\n");
      foreach (var person in persons)
      {
        Console.WriteLine(person);
      }
      Console.WriteLine("\nНажмите Enter для выхода");
      Console.ReadLine();
    }
  }
}
