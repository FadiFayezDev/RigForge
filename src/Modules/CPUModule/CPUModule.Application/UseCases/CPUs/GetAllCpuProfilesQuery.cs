using CPUModule.Application.Repositories.Queries;
using CPUModule.Contracts.DTOs.CPU;
using MediatR;

namespace CPUModule.Application.UseCases.CPUs
{
    public sealed record GetAllCpuProfilesQuery() : IRequest<IEnumerable<CPUProfileDto>>;

    public sealed class GetAllCpuProfilesQueryHandler : IRequestHandler<GetAllCpuProfilesQuery, IEnumerable<CPUProfileDto>>
    {
        private readonly ICPUProfileQueryRepository _repository;

        public GetAllCpuProfilesQueryHandler(ICPUProfileQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CPUProfileDto>> Handle(GetAllCpuProfilesQuery request, CancellationToken cancellationToken)
        {
            // Dapper already returns CPUProfileDto — no AutoMapper round-trip needed.
            return await _repository.GetAllCpuProfilesAsync();
        }
    }
}
