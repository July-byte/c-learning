using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace DataProcessor
{
  public class FileService
  {
    public List<Person> ReadFromCvs(string path)
    {
      var persons = new List<Person>();
      if (!File.Exists(path))
      {
        Console.WriteLine("Файл не найден");
        return persons;
      }
      try
      {
        using (var reader = new StreamReader(path, Encoding.UTF8))
        {
          string? line;
          bool isFirstLine = true;
          while ((line = reader.ReadLine()) != null)
          {
            if (isFirstLine)
            {
              isFirstLine = false;
              continue;
            }
            var parts = line.Split(',');
            if (parts.Length != 6)
            {
              Console.WriteLine($"Некорректная строка: {line}");
              continue;
            }
            try
            {
              var person = new Person
              {
                Id = int.Parse(parts[0]),
                Name = parts[1],
                Age = int.Parse(parts[2]),
                Category = parts[3],
                Salary = decimal.Parse(parts[4], CultureInfo.InvariantCulture),
                RegistrationDate = DateTime.Parse[5])
                };
              persons.Add(person);
              {
                catch
                {
                  Console.WriteLine($"Ошибка обработки строки: {line}");
                }
              }
            }
          }
          catch (Exception ex)
          {
            Console.WriteLine("Ошибка чтения файла: " + ex.Message);
          }
          return persons;
        }
      }
    }
    
