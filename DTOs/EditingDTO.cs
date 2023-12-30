namespace paysky_task.DTOs
{
    public class EditingDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(2500)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public DateTime ExpireDae { get; set; }
        [Required]
        public int MaxApplications { get; set; }

    }
}
