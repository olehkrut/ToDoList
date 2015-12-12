using System;

namespace DataAccess.Entities
{
	public class ToDoItem
	{
		public int ToDoItemId { get; set; }
		public string ToDoContent { get; set; }
		public byte Priority { get; set; }
		public DateTime? DueDate { get; set; }
		public int UserId { get; set; }

		public virtual ApplicationUser User { get; set; }

		//public virtual ApplicationUser Owner { get; set; }
		//public virtual string OwnerId { get; set; }
	}
}
