using Core.DateTimeService;

namespace Core.IO
{
    public interface IWriter
    {
        Task<bool> WriteData(List<string> data);
    }

    public class WriteToFile: IWriter
    {
        public WriteToFile(IDateTimeProvider dateTime)
        {
            _dateTime = dateTime;
        }

        IDateTimeProvider _dateTime;

        public async Task<bool> WriteData(List<string> data)
        {
            try
            {
                FileHelper helper = new FileHelper();
                string fullPath = helper.GetFullPath(_dateTime.GetTomorrow());

                await File.WriteAllLinesAsync(fullPath, data);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
