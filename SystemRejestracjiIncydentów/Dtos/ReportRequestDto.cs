using System.ComponentModel.DataAnnotations;

namespace SystemRejestracjiIncydentów.Dtos
{
    public class ReportRequestDto
    {
        [Required]
        public int? LocationId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
