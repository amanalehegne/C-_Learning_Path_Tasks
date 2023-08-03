using System.Formats.Asn1;

namespace TaskManagerProject;

class TaskClass
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Category GetCategory { get; set; }
    public bool IsCompleted { get; set; }
}


