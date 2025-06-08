using SystemRejestracjiIncydentów.Dtos;
using SystemRejestracjiIncydentów.Repositories;

namespace SystemRejestracjiIncydentów.Services
{
    public class ReportService : IReportService
    {

        private readonly IIncidentRepository _repository;

        public ReportService(IIncidentRepository repository)
        {
            _repository = repository;
        }

        public async Task<ReportResultDto> GenerateReportAsync(ReportRequestDto request)
        {
            var incidents = await _repository.GetAllAsync();

            if (request.To == null) request.To = DateTime.Now;
            if (request.From == null) request.From = DateTime.MinValue;

            var filtered = incidents
                .Where(i => i.LocationId == request.LocationId &&
                            i.OccurredAt >= request.From &&
                            i.OccurredAt <= request.To)
                .ToList();

            var resolved = filtered.Where(i => i.ResolvedAt.HasValue).ToList();

            var avgResolution = resolved
                .GroupBy(i => i.Priority)
                .ToDictionary(
                    g => g.Key,
                    g => TimeSpan.FromMinutes(g.Average(i =>
                        i.ResolvedAt.HasValue ? (i.ResolvedAt.Value - i.OccurredAt).TotalMinutes : 0))
                );

            return new ReportResultDto
            {
                TotalIncidents = filtered.Count,
                ResolvedIncidents = resolved.Count,
                AvgTimePerPriority = avgResolution
            };
        }
    }
}
