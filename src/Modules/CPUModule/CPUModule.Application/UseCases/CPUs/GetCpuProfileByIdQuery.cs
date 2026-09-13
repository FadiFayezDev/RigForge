using AutoMapper;
using CPUModule.Application.Repositories.Queries;
using CPUModule.Contracts.DTOs.CPU;
using CPUModule.Domain.Primitives.Identifiers;
using MediatR;

namespace CPUModule.Application.UseCases.CPUs
{
    public sealed record GetCpuProfileByIdQuery(CPUProfileId Id) : IRequest<CPUProfileDto?>;

    public sealed class GetCpuProfileByIdQueryHandler : IRequestHandler<GetCpuProfileByIdQuery, CPUProfileDto?>
    {
        private readonly ICPUProfileQueryRepository _queryRepository;

        public GetCpuProfileByIdQueryHandler(ICPUProfileQueryRepository repository)
        {
            _queryRepository = repository;
        }

        public async Task<CPUProfileDto?> Handle(GetCpuProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var cpu = await _queryRepository.GetCpuProfileByIdAsync(request.Id);
            if (cpu is null)
                throw new ArgumentException($"CPU profile with id {request.Id.Value} not found.");

            return cpu;
        }
    }
}
