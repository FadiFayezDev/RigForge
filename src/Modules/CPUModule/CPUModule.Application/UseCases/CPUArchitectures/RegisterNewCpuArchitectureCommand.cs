using CPUModule.Application.Abstractions;
using CPUModule.Application.Repositories.Commands;
using CPUModule.Domain.Primitives.Identifiers;
using Domain.Entities.CPU;
using MediatR;

namespace CPUModule.Application.UseCases.CPUArchitectures
{
    public sealed record RegisterNewCpuArchitectureCommand(
        string Name,
        int ProcessNodeNM,
        string? Description
    ) : ICommand<CPUArchitectureId>;

    public sealed class RegisterNewCpuArchitectureCommandHandler : IRequestHandler<RegisterNewCpuArchitectureCommand, CPUArchitectureId>
    {
        private readonly ICPUArchitectureRepository _repository;

        public RegisterNewCpuArchitectureCommandHandler(ICPUArchitectureRepository repository)
        {
            _repository = repository;
        }

        public async Task<CPUArchitectureId> Handle(RegisterNewCpuArchitectureCommand request, CancellationToken cancellationToken)
        {
            var arch = CPUArchitecture.Create(request.Name, request.ProcessNodeNM, request.Description);
            await _repository.AddAsync(arch);
            return arch.Id;
        }
    }
}
