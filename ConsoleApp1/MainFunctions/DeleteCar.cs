namespace CarDealership.MainFunctions
{
    internal class DeleteCar
    {
        public void DeleteCarMethod(int idToDelete)
        {
            // Зчитуємо всі рядки з файлу
            string fileName = "File.txt";
            string projectPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\MainFunctions"));
            string filePath = Path.Combine(projectPath, fileName);

           
            string[] lines = File.ReadAllLines(filePath);

            // Пошук індексу рядка з айді, який потрібно видалити
            int indexToDelete = -1;
            for (int i = 0; i < lines.Length; i++)
            {
                string[] values = lines[i].Split(',');
                int id = int.Parse(values[0]);

                if (id == idToDelete)
                {
                    indexToDelete = i;
                    break;
                }
            }

            if (indexToDelete == -1)
            {
                Console.WriteLine($"Машина з айді {idToDelete} не знайдена в файлі.");
                return;
            }

            // Видаляємо рядок з файлу
            List<string> newLines = lines.ToList();
            newLines.RemoveAt(indexToDelete);
            lines = newLines.ToArray();

            // Перезаписуємо файл
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = lines.Length - 1; i >= 0; i--)
                {
                    writer.WriteLine(lines[i]);
                }
            }

            Console.WriteLine($"Машина з айді {idToDelete} успішно видалена з файлу.");

            List<Car> cars = new List<Car>();
            foreach (string line in lines)
            {
                string[] fields = line.Split(',');
                int id = int.Parse(fields[0]);
                string brand = fields[1];
                int year = int.Parse(fields[2]);
                string model = fields[3];
                string color = fields[4];
                string condition = fields[5];
                int price = int.Parse(fields[6]);
                Car car = new Car(id, brand, year, model, color, condition, price);
                cars.Add(car);
            }

            // Сортуємо машини за айдішником
            cars = cars.OrderBy(car => car.Id).ToList();

            // Перезаписуємо файл
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                foreach (Car car in cars)
                {
                    string line = $"{car.Id},{car.Brand},{car.Year},{car.Model},{car.Color},{car.Condition},{car.Price}";
                    sw.WriteLine(line);
                }
            }

            Array.Sort(lines, (a, b) => int.Parse(a.Split(',')[0]).CompareTo(int.Parse(b.Split(',')[0])));

            // Перезаписуємо файл з відсортованими рядками та новими айді
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                int newId = 1;

                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    parts[0] = newId.ToString();
                    writer.WriteLine(string.Join(',', parts));
                    newId++;
                }
            }

        }
    }
}
