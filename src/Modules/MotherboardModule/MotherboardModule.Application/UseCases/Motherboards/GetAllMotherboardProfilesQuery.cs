using MotherboardModule.Application.Repositories.Queries;
using MotherboardModule.Contracts.DTOs;
using MediatR;

namespace MotherboardModule.Application.UseCases.Motherboards
{
    public sealed record GetAllMotherboardProfilesQuery() : IRequest<IEnumerable<MotherboardProfileDto>>;

    public sealed class GetAllMotherboardProfilesQueryHandler : IRequestHandler<GetAllMotherboardProfilesQuery, IEnumerable<MotherboardProfileDto>>
    {
        private readonly IMotherboardProfileQueryRepository _queryRepository;

        public GetAllMotherboardProfilesQueryHandler(IMotherboardProfileQueryRepository repository)
        {
            _queryRepository = repository;
        }

        public async Task<IEnumerable<MotherboardProfileDto>> Handle(GetAllMotherboardProfilesQuery request, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetAllMotherboardProfilesAsync();
        }
    }
}
