using SocketModule.Application.Repositories.Queries;
using SocketModule.Contracts.DTOs;
using MediatR;

namespace SocketModule.Application.UseCases.Sockets
{
    public sealed record GetSocketProfileByNameQuery(string Name) : IRequest<SocketProfileDto?>;

    public sealed class GetSocketProfileByNameQueryHandler : IRequestHandler<GetSocketProfileByNameQuery, SocketProfileDto?>
    {
        private readonly ISocketProfileQueryRepository _repository;

        public GetSocketProfileByNameQueryHandler(ISocketProfileQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<SocketProfileDto?> Handle(GetSocketProfileByNameQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSocketProfileByNameAsync(request.Name);
        }
    }
}
