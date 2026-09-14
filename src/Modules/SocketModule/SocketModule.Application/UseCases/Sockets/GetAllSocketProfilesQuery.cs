using SocketModule.Application.Repositories.Queries;
using SocketModule.Contracts.DTOs;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SocketModule.Application.UseCases.Sockets
{
    public sealed record GetAllSocketProfilesQuery() : IRequest<IEnumerable<SocketProfileDto>>;

    public sealed class GetAllSocketProfilesQueryHandler : IRequestHandler<GetAllSocketProfilesQuery, IEnumerable<SocketProfileDto>>
    {
        private readonly ISocketProfileQueryRepository _repository;

        public GetAllSocketProfilesQueryHandler(ISocketProfileQueryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<SocketProfileDto>> Handle(GetAllSocketProfilesQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllSocketProfilesAsync();
        }
    }
}
