using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
	public class ToDoItem
	{
		public int ToDoItemId { get; set; }
		public string ToDoContent { get; set; }
		public byte Priority { get; set; }
		public DateTime? DueDate { get; set; }

		public virtual ApplicationUser Owner { get; set; }
		public virtual string OwnerId { get; set; }
	}
}
