namespace SystemRejestracjiIncydentów.Dtos
{
    public class ReportRequestDto
    {
        public int LocationId { get; set; }
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
