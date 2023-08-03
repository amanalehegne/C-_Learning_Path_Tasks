using System.Formats.Asn1;
using System.Threading.Tasks;
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
                    Elements.Add(content);
                }

                Console.WriteLine("Content successfully appended to the file: " + FilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while appending to the file: " + ex.Message);
            }
        }

        public async Task ReadFileAsync(bool check)
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
                        if (check) {
                            foreach (string field in fields)
                                Console.WriteLine(field);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading the file: {ex.Message}");
            }
        }

        public async Task UpdateFileAsync(string name, TaskClass task)
        {
            try
            {
                if (Elements == null)
                    await ReadFileAsync(false);

                int size = Elements.Count;
                for (int i = 0; i < size; i++)
                {
                    if (Elements[i].Split('|')[0].Trim() == name)
                    {
                        string? value = "Not Completed";
                        if (task.IsCompleted)
                            value = "Completed";

                        Elements[i] = $"{task.GetCategory} | {task.Name} | {task.Description} | {value},";
                        break;
                    }
                }

                // After the update, write the updated content back to the file
                await WriteUpdatedFileAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the file: " + ex.Message);
            }
        }

        private async Task WriteUpdatedFileAsync()
        {
            try
            {
                if (Elements != null)
                {
                    using (StreamWriter writer = new StreamWriter(FilePath))
                    {
                        foreach (string content in Elements)
                        {
                            await writer.WriteLineAsync(content);
                        }
                    }

                    Console.WriteLine("Content successfully updated in the file: " + FilePath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while updating the file: " + ex.Message);
            }
        }

        public async Task FilterFileAsync(Category category)
        {
            Category available = Category.Avialable;

            if (available.HasFlag(category))
            {
                Console.WriteLine("Filtered By " + category);
                if (Elements == null)
                    await ReadFileAsync(false);

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
