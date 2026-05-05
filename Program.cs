using System;
namespace EventDemo
{
  class Program
  {
    static void Main(string[] args)
    {
      Publisher publisher = new Publisher();
      int handledCount = 0;
      EventHandler<CustomEventArgs> handler1 = (sender, eventArgs) =>
      {
        handledCount++; //замыкание
        Logger.Log($"[Subscriber 1] Получено сообщение: {eventArgs.Message}");
      };
      EventHandler<CustomEventArgs> handler2 = (sender, eventArgs) =>
      {
        Logger.Log($"[Subscriber 2] Время события: {eventArgs.Timestamp}");
      };

      // подписка
      publisher.SomethingHappened += handler1;
      publisher.SomethingHappened += handler2;
      publisher.RaiseEvent("Событие №1");
      publisher.RaiseEvent("Событие №2");

      Console.WriteLine($"\nОбработано событий первым подписчиком: {handledCount}");

      //отписка
      publisher.SomrthingHappened -= handler2;
      Console.WriteLine("\nОтписали второго подписчика.\n");

      publisher.RaiseEvent("Событие №3");
      Console.WriteLine($"\nОбработано событий первым подписчиком: {handledCount}");
      Console.ReadLine();
    }
  }
}

                        
                        
                        
      
