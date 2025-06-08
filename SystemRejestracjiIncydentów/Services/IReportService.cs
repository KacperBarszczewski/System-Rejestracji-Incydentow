using SystemRejestracjiIncydentów.Dtos;

namespace SystemRejestracjiIncydentów.Services
{
    public interface IReportService
    {
        Task<ReportResultDto> GenerateReportAsync(ReportRequestDto request);
    }
}
