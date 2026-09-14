using CPUModule.Application.Abstractions;
using CPUModule.Application.Repositories.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CPUModule.Application.UseCases.CPUArchitectures
{
    public sealed record DeleteCpuArchitectureCommand(Guid Id) : ICommand<bool>;

    public sealed class DeleteCpuArchitectureCommandHandler : IRequestHandler<DeleteCpuArchitectureCommand, bool>
    {
        private readonly ICPUArchitectureRepository _repository;

        public DeleteCpuArchitectureCommandHandler(ICPUArchitectureRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCpuArchitectureCommand request, CancellationToken cancellationToken)
        {
            var id = CPUModule.Domain.Primitives.Identifiers.CPUArchitectureId.FromGuid(request.Id);
            var arch = await _repository.GetByIdAsync(id);
            if (arch is null)
                return false;

            await _repository.RemoveAsync(arch);
            return true;
        }
    }
}
