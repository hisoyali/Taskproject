using Task = Tareas.Models.Task;

namespace Tareas.Services
{
	public class TaskService
	{
		private List<Task> tasks = new List<Task>();
		private int nextId = 1;
		public int completadas { get; private set; }
		public int pendientes { get; private set; }

		public List<Task> GetTasks()
		{
			return tasks;
		}

		public void AddTask(string description)
		{
			Task newTask = new Task(nextId, description, false)
			{
				Id = nextId++
			};
			tasks.Add(newTask);
			pendientes++;
		}


		// Eliminar tarea
		public void RemoveTask(int id)
		{
			var taskToRemove = tasks.FirstOrDefault(t => t.Id == id);

			if (taskToRemove != null)
			{
				if (taskToRemove.IsCompleted)
				{
					completadas--;
				}
				else
				{
					pendientes--;
				}

				tasks.Remove(taskToRemove);

				int newId = 1;
				foreach (var task in tasks)
				{
					task.Id = newId++;
				}

				nextId = newId;
			}
		}

		// Editar tarea
		public void UpdateTask(int id, string description)
		{
			var taskToUpdate = tasks.FirstOrDefault(t => t.Id == id);

			if (taskToUpdate != null)
			{
				taskToUpdate.Description = description;
			}
		}

		// Cambiar estado de completada o no completada
		public void ToggleTaskCompletion(int id)
		{
			var taskToToggle = tasks.FirstOrDefault(t => t.Id == id);

			if (taskToToggle != null)
			{
				if (taskToToggle.IsCompleted)
				{
					completadas--;
					pendientes++;
				}
				else
				{
					completadas++;
					pendientes--;
				}
				taskToToggle.IsCompleted = !taskToToggle.IsCompleted;
			}
		}
	}
}
