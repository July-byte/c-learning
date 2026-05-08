using System;
namespace DataProcessor
{
  ///<summary>
  /// Модель данных, представляющая запись из файла.
  ///</summary>

  public class Person
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Category { get; set; }
    public decimal Salary { get; set; }
    public DateTime RegistrationDate { get; set; }

    public override string ToString()
    {
      return $"{Id}, {Name}, {Age}, {Category}, {Salary}, {RegistrationDate:yyyy-MM-dd}";
    }
  }
}
