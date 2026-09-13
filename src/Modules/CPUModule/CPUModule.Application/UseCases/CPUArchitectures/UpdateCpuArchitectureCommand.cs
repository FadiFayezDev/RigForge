using CPUModule.Application.Abstractions;
using CPUModule.Application.Repositories.Commands;
using CPUModule.Domain.Primitives.Identifiers;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CPUModule.Application.UseCases.CPUArchitectures
{
    public sealed record UpdateCpuArchitectureCommand(
        CPUArchitectureId Id,
        string Name,
        int ProcessNodeNM,
        string? Description
    ) : ICommand<Unit>;

    public sealed class UpdateCpuArchitectureCommandHandler : IRequestHandler<UpdateCpuArchitectureCommand, Unit>
    {
        private readonly ICPUArchitectureRepository _repository;

        public UpdateCpuArchitectureCommandHandler(ICPUArchitectureRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateCpuArchitectureCommand request, CancellationToken cancellationToken)
        {
            var arch = await _repository.GetByIdAsync(request.Id);
            if (arch is null)
                throw new ArgumentException($"Architecture with id {request.Id} not found.");

            arch.UpdateName(request.Name);
            arch.UpdateProcessNode(request.ProcessNodeNM);
            arch.UpdateDescription(request.Description);

            await _repository.UpdateAsync(arch);
            return Unit.Value;
        }
    }
}
