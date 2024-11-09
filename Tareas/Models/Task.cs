
namespace Tareas.Models
{
	public class Task
	{
		public int Id { get; set; }
		public string Description { get; set; } = string.Empty;
		public bool IsCompleted { get; set; }

		public Task(int id, string description, bool isCompleted = false)
		{
			Id = id;
			Description = description;
			IsCompleted = isCompleted;
		}
	}
}
