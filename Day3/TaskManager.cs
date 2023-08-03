using System.Formats.Asn1;
using System.Xml.Linq;

namespace TaskManagerProject
{
    class TaskManager
    {
        public string? FilePath { get; set; }
        private List<string> Elements;

        public async Task WriteToFileAsync(TaskClass task)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(FilePath, true))
                {
                    string? value = "Not Completed";
                    if (task.IsCompleted)
                        value = "Completed";

                    string content = $"{task.GetCategory} | {task.Name} | {task.Description} | {value},";
                    await writer.WriteAsync(content);
                }

                Console.WriteLine("Content successfully appended to the file: " + FilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while appending to the file: " + ex.Message);
            }
        }

        public async Task ReadFileAsync()
        {
            try
            {
                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        string[] fields = line.Split(',');
                        Elements = new List<string>(fields);
                        foreach (string field in fields)
                            Console.WriteLine(field);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }
        }

        public async Task FilterFileAsync(Category category)
        {
            Category available = Category.Avialable;

            if (available.HasFlag(category))
            {
                Console.WriteLine("Filtered By " + category);
                if (Elements == null)
                    await ReadFileAsync();

                var filteredElements = Elements.Where(task => task.Split('|')[0].Trim() == category.ToString());

                foreach (var element in filteredElements)
                    Console.WriteLine(element);
            }
            else
            {
                Console.WriteLine("No Such Category");
            }
        }
    }
}
