namespace CarDealership.SecondaryFunctions
{
    public class AccessFile
    {
        public string[]? Lines { get; set; }
        public string? FilePath { get; set; }

        public AccessFile(string fileName, string directoryPath)
        {
            string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, directoryPath));
            string filePath = Path.Combine(projectPath, fileName);
            Lines = File.ReadAllLines(filePath);
            FilePath = filePath;
        }
        
        public static AccessFile GetAccessToFile(string fileName, string directoryPath)
        {
            return new AccessFile(fileName, directoryPath);
        }
    }
}
