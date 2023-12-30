namespace paysky_task.DTOs
{
    public class applyvacancyDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateTime startdate { get; set; }
        public int vacancyid { get; set; }
    }
}
