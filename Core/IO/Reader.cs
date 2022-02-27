using Core.DateTimeService;

namespace Core.IO
{
    public interface IReader
    {
        List<string> ReadData();
    }

    public class ReadFromFile : IReader
    {
        IDateTimeProvider _dateTime;

        public ReadFromFile(IDateTimeProvider dateTime)
        {
            _dateTime = dateTime;
        }

        public List<string> ReadData()
        {
            FileHelper helper = new FileHelper();
            string filePath = helper.GetFullPath(_dateTime.GetToday());

            List<string> data = File.ReadAllLines(filePath).ToList();

            return data;
        }
    }
}
