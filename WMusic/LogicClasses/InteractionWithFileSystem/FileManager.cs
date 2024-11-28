using WMusic.GlobalUsageClasses;
using WMusic.LogicClasses.InteractionWithLog;

namespace WMusic.LogicClasses.InteractionWithFileSystem
{
    internal class FileManager
    {
        public static void SearchInDirectory(string pathToDirectory, params IFileFormat[] fileFormats)
        {
            try
            {
                var files = Directory.GetFiles(pathToDirectory);

                foreach(var fileFormat  in fileFormats)
                    MusicContainer.MusicFiles.AddRange(files.Where(file => file.EndsWith(fileFormat.GetFormat(), StringComparison.OrdinalIgnoreCase)));                
            }
            catch(Exception ex) 
            {
                MyLogger.Log(ex.Message, new ErrorLogger()); 
            }
        }

        public static void SearchInDirectoryRecursive(string pathToDirectory, params IFileFormat[] fileFormats)
        {
            try
            {
                var files = Directory.GetFiles(pathToDirectory);
                var directories = Directory.GetDirectories(pathToDirectory);

                foreach(var fileFormat in fileFormats)
                    MusicContainer.MusicFiles.AddRange(files.Where(file => file.EndsWith(fileFormat.GetFormat(), StringComparison.OrdinalIgnoreCase)));

                foreach (var dir in directories)
                    SearchInDirectoryRecursive(dir, fileFormats);
            }
            catch (Exception ex)
            {
                MyLogger.Log(ex.Message, new ErrorLogger());
            }
        }
    }
}
