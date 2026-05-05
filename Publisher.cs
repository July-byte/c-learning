using System;
namespace EventDemo
{
  /// <summary>
  /// Класс-издатель, генерирующий события.
  /// </summary>
  public class Publisher
  {
    /// <summary>
    /// События, уведомляющее подписчиков
    /// </summary>
    public event EventHandler<CustomEventArgs>? SomethingHappened;

    /// <summary>
    /// Метод генерации события
    /// </summary>
    public void RaiseEvent(string message)
    {
      Logger.Log($"[Publisher] Генерация события: {message}");
      OnSomethingHappened(new CustomEventArgs(message));
    }
    protected virtual void OnSomethingHappened(CustomEventArgs e)
    {
      SomethingHappened?.Invoke(this e);
    }
  }
}
