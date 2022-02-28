namespace Core.IO
{
    public interface IFileHelper
    {
        string GetFullPath(string filename);
    }

    public class FileHelper : IFileHelper
    {
        public string GetFullPath(string filename)
        {
            string currentWorkingDir = AppDomain.CurrentDomain.BaseDirectory;
            string file 
                = Path.Combine(currentWorkingDir, String.Format(@"..\Reports\{0}.txt", filename));
            return Path.GetFullPath(file);
        }
    }
}
