using CPUModule.Application.Abstractions;
using CPUModule.Application.Repositories.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CPUModule.Application.UseCases.CPUs
{
    public sealed record DeleteCpuCommand(Guid Id) : ICommand<bool>;

    public sealed class DeleteCpuCommandHandler : IRequestHandler<DeleteCpuCommand, bool>
    {
        private readonly ICPUProfileRepository _repository;

        public DeleteCpuCommandHandler(ICPUProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteCpuCommand request, CancellationToken cancellationToken)
        {
            var id = CPUModule.Domain.Primitives.Identifiers.CPUProfileId.FromGuid(request.Id);
            var cpu = await _repository.GetByIdAsync(id);
            if (cpu is null)
                return false;

            await _repository.RemoveAsync(cpu);
            return true;
        }
    }
}
