namespace ParcelApi.Helpers;

public static class DateHelpers
{
  public static bool IsDateInPast(DateTime date)
  {
    return date < DateTime.Now;
  }
}
