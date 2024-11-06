using System.ComponentModel.DataAnnotations;

namespace TODOWebApp.DTO.TodoTaskFolderDTO
{
    public class CreateTodoTaskDTO
    {
        [Key]
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid UserId { get; set; }
        // Add any other fields needed by the Web API’s endpoint
    }
}
