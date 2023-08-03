namespace TaskManagerProject;

class Program
{
    static async Task Main(string[] args)
    {
        
        TaskClass task = new TaskClass { Name = "Task69", Description = "Lorem Ibsem", GetCategory = (Category)4, IsCompleted = false };
        TaskManager manager = new TaskManager { FilePath = "/Users/amanuelwubete/Desktop/file.csv"};

        // await manager.WriteToFileAsync(task);
        await manager.ReadFileAsync(true);
        await manager.UpdateFileAsync("Task0", task);
        await manager.FilterFileAsync((Category)1)
        await manager.ReadFileAsync(true);
    }
}

