using MotherboardModule.Application.Repositories.Queries;
using MotherboardModule.Contracts.DTOs;
using MediatR;

namespace MotherboardModule.Application.UseCases.Chipsets
{
    public sealed record GetChipsetProfileByNameQuery(string Name) : IRequest<ChipsetProfileDto?>;

    public sealed class GetChipsetProfileByNameQueryHandler : IRequestHandler<GetChipsetProfileByNameQuery, ChipsetProfileDto?>
    {
        private readonly IChipsetProfileQueryRepository _queryRepository;

        public GetChipsetProfileByNameQueryHandler(IChipsetProfileQueryRepository repository)
        {
            _queryRepository = repository;
        }

        public async Task<ChipsetProfileDto?> Handle(GetChipsetProfileByNameQuery request, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetChipsetProfileByNameAsync(request.Name);
        }
    }
}
