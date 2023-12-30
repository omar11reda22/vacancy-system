
namespace paysky_task.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(250)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public int Salary { get; set; }
        [Required]
        public string City { get; set; } = string.Empty;
    }
}
