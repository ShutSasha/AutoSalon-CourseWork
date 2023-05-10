namespace CarDealership.MainFunctions.OrderF
{
    public class TextFileReader
    {
       public static string[] GetLinesFromFile(string fileName, string directoryPath, int index, int count)
        {
            AccessFile accessFile = AccessFile.GetAccessToFile(fileName, directoryPath);
            string[] lines = accessFile.Lines;
            string[] result = new string[count];
            for (int i = 0; i < count; i++)
            {
                string[] line = lines[index + i].Split(',');
                result[i] = string.Join(", ", line);
            }
            return result;
        }
    }
}
