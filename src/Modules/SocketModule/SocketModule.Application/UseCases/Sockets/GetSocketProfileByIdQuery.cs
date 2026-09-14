using SocketModule.Application.Repositories.Queries;
using SocketModule.Contracts.DTOs;
using SocketModule.Domain.Primitives.Identifiers;
using MediatR;

namespace SocketModule.Application.UseCases.Sockets
{
    public sealed record GetSocketProfileByIdQuery(SocketProfileId Id) : IRequest<SocketProfileDto?>;

    public sealed class GetSocketProfileByIdQueryHandler : IRequestHandler<GetSocketProfileByIdQuery, SocketProfileDto?>
    {
        private readonly ISocketProfileQueryRepository _queryRepository;

        public GetSocketProfileByIdQueryHandler(ISocketProfileQueryRepository repository)
        {
            _queryRepository = repository;
        }

        public async Task<SocketProfileDto?> Handle(GetSocketProfileByIdQuery request, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetSocketProfileByIdAsync(request.Id);
        }
    }
}
