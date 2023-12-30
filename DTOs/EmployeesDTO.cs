namespace paysky_task.DTOs
{
    public class EmployeesDTO
    {
        [Required]
        [MaxLength(250)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        public int Salary { get; set; }
        [Required]
        [MaxLength(250)]
        public string City { get; set; } = string.Empty;


    }
}
