using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TODOWebApp.Models
{
    public class TodoTaskViewModel
    {
        [Key]
        public Guid TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; } = DateTime.Now;
        [DisplayName("Finished?")]
        public bool IsCompleted { get; set; }
        //Foreign Key
        public Guid UserId { get; set; }
        //Navigation Property: Many to One. Many tasks, one user.
        public UserViewModel User { get; set; }
    }
}
