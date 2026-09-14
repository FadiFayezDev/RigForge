using CPUModule.Application.Repositories.Queries;
using CPUModule.Contracts.DTOs.CPUArchitectures;
using MediatR;

namespace CPUModule.Application.UseCases.CPUArchitectures
{
    public sealed record GetAllCpuArchitecturesQuery() : IRequest<IEnumerable<CPUArchitectureDto>>;

    public sealed class GetAllCpuArchitecturesQueryHandler : IRequestHandler<GetAllCpuArchitecturesQuery, IEnumerable<CPUArchitectureDto>>
    {
        private readonly ICPUArchitectureQueryRepository _queryRepository;

        public GetAllCpuArchitecturesQueryHandler(ICPUArchitectureQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<IEnumerable<CPUArchitectureDto>> Handle(GetAllCpuArchitecturesQuery request, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetAllCpuArchitecturesAsync();
        }
    }
}
