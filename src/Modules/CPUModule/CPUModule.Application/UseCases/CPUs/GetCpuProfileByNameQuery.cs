using CPUModule.Application.Repositories.Queries;
using CPUModule.Contracts.DTOs.CPU;
using MediatR;

namespace CPUModule.Application.UseCases.CPUs
{
    public sealed record GetCpuProfileByNameQuery(string Name) : IRequest<CPUProfileDto?>;

    public sealed class GetCpuProfileByNameQueryHandler : IRequestHandler<GetCpuProfileByNameQuery, CPUProfileDto?>
    {
        private readonly ICPUProfileQueryRepository _repository;

        public GetCpuProfileByNameQueryHandler(ICPUProfileQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<CPUProfileDto?> Handle(GetCpuProfileByNameQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCpuProfileByNameAsync(request.Name);
        }
    }
}
