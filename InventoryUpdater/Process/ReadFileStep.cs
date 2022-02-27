using Core.DateTimeService;
using Core.IO;

namespace InventoryUpdater.Process
{
    public class ReadFileStep
    {
        private readonly IReader _reader;

        public ReadFileStep(IReader reader)
        {
            _reader = reader;
        }

        public List<string> ReadFile()
        {
            List<string> extractedToStrings;

            try
            {
                extractedToStrings = _reader.ReadData();
                return extractedToStrings;
            }
            catch
            {
                IDateTimeProvider dt = new DateTimeProvider();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(String.Format(
                    "{0}.txt cannot be found \r\n" +
                    "Ensure the file is in the format (DD-MM-YYYY) \r\n" +
                    "and placed in the reports folder", dt.GetToday()));
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
                return null;
            }
        }
    }
}
