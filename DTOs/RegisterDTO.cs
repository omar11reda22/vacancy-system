namespace paysky_task.DTOs
{
    public class RegisterDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string Confirmpassword { get; set; } = string.Empty;
    }
}
