using SystemRejestracjiIncydentów.Enums;

namespace SystemRejestracjiIncydentów.Dtos
{
    public class IncidentCreateDto
    {
        public int LocationId { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime? OccurredAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public PriorityLevel Priority { get; set; }
        public IncidentStatus Status { get; set; }
    }
}
