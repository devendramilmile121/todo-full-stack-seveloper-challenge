using Domain.Common;

namespace Domain.Entities
{
    public class TodoList: BaseEntity
    {
        public string? Title { get; set; }
        public string Colour { get; set; } = "#FFF";
        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
    }
}
