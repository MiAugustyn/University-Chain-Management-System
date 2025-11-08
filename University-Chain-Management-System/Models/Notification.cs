using System.ComponentModel.DataAnnotations;
using University_Chain_Management_System.Data.Enums;
using University_Chain_Management_System.ModelsValidations;

namespace University_Chain_Management_System.Models
{
    public class Notification
    {
        [Key]
        public int Id { get; set; }
        public NotificationType NotificationType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [CreationDateValidation]
        public DateTime PublishDate { get; set; }
    }
}