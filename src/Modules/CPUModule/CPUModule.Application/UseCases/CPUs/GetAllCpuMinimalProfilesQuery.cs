using CPUModule.Application.Repositories.Queries;
using CPUModule.Contracts.DTOs.CPU;
using MediatR;

namespace CPUModule.Application.UseCases.CPUs
{
    public sealed record GetAllCpuMinimalProfilesQuery() : IRequest<IEnumerable<CPUMiniProfileDto>>;

    public sealed class GetAllCpuMinimalProfilesQueryHandler : IRequestHandler<GetAllCpuMinimalProfilesQuery, IEnumerable<CPUMiniProfileDto>>
    {
        private readonly ICPUProfileQueryRepository _repository;

        public GetAllCpuMinimalProfilesQueryHandler(ICPUProfileQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CPUMiniProfileDto>> Handle(GetAllCpuMinimalProfilesQuery request, CancellationToken cancellationToken)
        {
            // Dapper already returns CPUMiniProfileDto — no AutoMapper round-trip needed.
            return await _repository.GetAllCpuMinimalProfilesAsync();
        }
    }
}
