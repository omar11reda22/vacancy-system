using System.ComponentModel.DataAnnotations.Schema;

namespace paysky_task.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateTime startdate { get; set; }
        public int vacancyid { get; set; }
        [ForeignKey("vacancyid")]
        public virtual Vacancy Vacancy { get; set; } = default!;

    }
}
