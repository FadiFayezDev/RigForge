using CPUModule.Application.Repositories.Queries;
using CPUModule.Contracts.DTOs.CPUArchitectures;
using MediatR;

namespace CPUModule.Application.UseCases.CPUArchitectures
{
    public sealed record GetCpuArchitectureByIdQuery(Guid Id) : IRequest<CPUArchitectureDto?>;

    public sealed class GetCpuArchitectureByIdQueryHandler : IRequestHandler<GetCpuArchitectureByIdQuery, CPUArchitectureDto?>
    {
        private readonly ICPUArchitectureQueryRepository _queryRepository;

        public GetCpuArchitectureByIdQueryHandler(ICPUArchitectureQueryRepository queryRepository)
        {
            _queryRepository = queryRepository;
        }

        public async Task<CPUArchitectureDto?> Handle(GetCpuArchitectureByIdQuery request, CancellationToken cancellationToken)
        {
            var id = CPUModule.Domain.Primitives.Identifiers.CPUArchitectureId.FromGuid(request.Id);
            return await _queryRepository.GetCpuArchitectureByIdAsync(id);
        }
    }
}
