using MotherboardModule.Application.Repositories.Queries;
using MotherboardModule.Contracts.DTOs;
using MediatR;

namespace MotherboardModule.Application.UseCases.Chipsets
{
    public sealed record GetAllChipsetProfilesQuery() : IRequest<IEnumerable<ChipsetProfileDto>>;

    public sealed class GetAllChipsetProfilesQueryHandler : IRequestHandler<GetAllChipsetProfilesQuery, IEnumerable<ChipsetProfileDto>>
    {
        private readonly IChipsetProfileQueryRepository _queryRepository;

        public GetAllChipsetProfilesQueryHandler(IChipsetProfileQueryRepository repository)
        {
            _queryRepository = repository;
        }

        public async Task<IEnumerable<ChipsetProfileDto>> Handle(GetAllChipsetProfilesQuery request, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetAllChipsetProfilesAsync();
        }
    }
}
