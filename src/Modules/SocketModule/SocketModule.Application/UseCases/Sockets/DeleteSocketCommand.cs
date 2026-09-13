using SocketModule.Application.Abstractions;
using SocketModule.Application.Repositories.Commands;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SocketModule.Application.UseCases.Sockets
{
    public sealed record DeleteSocketCommand(Guid Id) : ICommand<bool>;

    public sealed class DeleteSocketCommandHandler : IRequestHandler<DeleteSocketCommand, bool>
    {
        private readonly ISocketProfileRepository _repository;

        public DeleteSocketCommandHandler(ISocketProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteSocketCommand request, CancellationToken cancellationToken)
        {
            var id = SocketModule.Domain.Primitives.Identifiers.SocketProfileId.FromGuid(request.Id);
            var socket = await _repository.GetByIdAsync(id);
            if (socket is null)
                return false;

            await _repository.RemoveAsync(socket);
            return true;
        }
    }
}
