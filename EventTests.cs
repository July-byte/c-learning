//упрощенная проверка

using System;
namespace EventDemo
{
  public static class EventTests
  {
    public static void Run()
    {
      Publisher publisher = new Publisher();
      int callCount = 0;
      EventHandler<CustomEventArgs> handler = (s, e) =>
      {
        callCount++;
      }
      publisher.SomrthingHappened += handler;
      publisher.RaiseEvent("Test");
      if (callCount != 1)
        throw new Exception("Ошибка подписки");
      publisher.SomethingHappened -= handler;
      publisher.RaiseEvent("Test2");
      if (callCount != 1)
        throw new Exception("Ошибка отписки");
    }
  }
}
