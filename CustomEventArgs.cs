using System;
namespace EventDemo
{
  /// <summary>
  /// Аргументы события.
  /// </summary>
  public class CustomEventArgs : EventArgs
  {
      public string Message { get; }
      public DateTime Timestamp { get; }
      public CustomEventArgs(stringMessage)
      {
          Message = message;
          Timestamp = DateTime.Now;
      }
  }
}
