namespace CarDealership.MainFunctions
{
    public class AccessFile
    {
        public string[] Lines { get; set; }
        public string FilePath { get; set; }

        public static AccessFile GetAccessToFile(string fileName, string directoryPath)
        {
            string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directoryPath));
            string filePath = Path.Combine(projectPath, fileName);
            return new AccessFile { Lines = File.ReadAllLines(filePath), FilePath = filePath };
        }
    }
}
