using SystemRejestracjiIncydentów.Enums;

namespace SystemRejestracjiIncydentów.Entities
{
    public class Incident
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; } = null!;
        public string Description { get; set; } = string.Empty;
        public DateTime OccurredAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public PriorityLevel Priority { get; set; }
        public IncidentStatus Status { get; set; }
    }
}
