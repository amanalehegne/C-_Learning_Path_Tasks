namespace TaskManagerProject;

class Program
{
    static async Task Main(string[] args)
    {
        TaskClass task = new TaskClass { Name = "Task4", Description = "Lorem Ibsem", GetCategory = (Category)0, IsCompleted = true };
        TaskManager manager = new TaskManager { FilePath = "/Users/amanuelwubete/Desktop/file.csv"};

        //await manager.WriteToFileAsync(task);
        await manager.ReadFileAsync();
        await manager.FilterFileAsync((Category)10);

    }
}

