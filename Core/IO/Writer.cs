using Core.DateTimeService;

namespace Core.IO
{
    public interface IWriter
    {
        Task<bool> WriteData();
    }

    public class WriteToFile: IWriter
    {
        public WriteToFile(IDateTimeProvider dateTime, List<string> data)
        {
            _dateTime = dateTime;
            _data = data;
        }

        IDateTimeProvider _dateTime;
        List<string> _data;

        public async Task<bool> WriteData()
        {
            try
            {
                FileHelper helper = new FileHelper();
                string fullPath = helper.GetFullPath(_dateTime.GetTomorrow());

                await File.WriteAllLinesAsync(fullPath, _data);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
