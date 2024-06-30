using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class TodoItem: BaseEntity
    {
        public int ListId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public PriorityLevel Priority { get; set; }
        public DateTime? DueDate { get; set; }

        public TodoList List { get; set; } = null!;
    }
}
