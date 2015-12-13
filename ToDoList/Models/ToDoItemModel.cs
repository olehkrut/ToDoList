using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
	public class ToDoItemModel
	{
		public string ToDoContent { get; set; }
		public int ToDoItemId { get; set; }
		public DateTime? DueDate { get; set; }
		public int UserId { get; set; }
		public byte Priority { get; set; }
	}
}