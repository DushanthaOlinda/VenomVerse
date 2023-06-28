namespace TodoApi.Models;

public class TaskItem{
    public long ID { get; set; }
    public string? Name { get; set; }

    public string? Description { get; set; }
    public bool IsComplete { get; set; }
}