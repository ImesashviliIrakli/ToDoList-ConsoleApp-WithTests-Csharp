using System;
using System.Collections.Generic;

#nullable disable

namespace ToDoListApplication.Domain
{
    public partial class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Status { get; set; }
    }
}
