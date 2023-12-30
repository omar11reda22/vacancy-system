namespace paysky_task.Models
{
    public class Vacancy
    {
        public Vacancy()
        {
            IsActive = true;
        }
        [Key]
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
        [Required]
        public bool IsActive { get; set; }
        public virtual ICollection<Applicant> applicants { get; set; } = new List<Applicant>();


    }
}
