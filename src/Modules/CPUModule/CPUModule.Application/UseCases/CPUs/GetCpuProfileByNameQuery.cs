using AutoMapper;
using CPUModule.Application.Repositories.Commands;
using CPUModule.Application.Repositories.Queries;
using CPUModule.Contracts.DTOs.CPU;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
            var cpu = await _repository.GetCpuProfileByNameAsync(request.Name);
            if (cpu is null)
                throw new ArgumentException($"CPU profile with name '{request.Name}' not found.");

            return cpu;
        }
    }
}
