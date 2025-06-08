using SystemRejestracjiIncydentów.Enums;

namespace SystemRejestracjiIncydentów.Dtos
{
    public class ReportResultDto
    {
        public int TotalIncidents { get; set; }
        public int ResolvedIncidents { get; set; }
        public Dictionary<PriorityLevel, TimeSpan> AvgTimePerPriority { get; set; } = new();
    }
}
