namespace Core.DateTimeService
{
    public interface IDateTimeProvider
    {
        string GetToday();
        string GetTomorrow();
    }

    public class DateTimeProvider : IDateTimeProvider
    {
        public string GetToday()
        {
            DateTime dt = DateTime.Now;
            return dt.ToString("dd-MM-yyyy");
        }

        public string GetTomorrow()
        {
            DateTime dt = DateTime.Now.AddDays(1);
            return dt.ToString("dd-MM-yyyy");
        }
    }
}
