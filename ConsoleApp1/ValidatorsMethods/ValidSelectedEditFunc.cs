namespace CarDealership.ValidatorsMethods
{
    internal class ValidSelectedEditFunc
    {
        
        public static void ValidSelectedInput(int selectedNumber, string filePath)
        {
            if(selectedNumber > FindMaxIdMethod(filePath) || selectedNumber < 1)
            {
                Console.WriteLine("Error");
            }
        }

        public static int FindMaxIdMethod(string filePath)
        {
            
            int maxId = 0;
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                int id = Convert.ToInt32(values[0]);
                if (id > maxId)
                {
                    maxId = id;
                }
            }
            return maxId;
        }
    }
}
