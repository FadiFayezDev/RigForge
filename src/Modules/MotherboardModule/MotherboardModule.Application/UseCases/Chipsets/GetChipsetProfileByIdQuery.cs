using MotherboardModule.Application.Repositories.Queries;
using MotherboardModule.Contracts.DTOs;
using MotherboardModule.Domain.Primitives.Identifiers;
using MediatR;

namespace MotherboardModule.Application.UseCases.Chipsets
{
    public sealed record GetChipsetProfileByIdQuery(ChipsetProfileId Id) : IRequest<ChipsetProfileDto?>;

    public sealed class GetChipsetProfileByIdQueryHandler : IRequestHandler<GetChipsetProfileByIdQuery, ChipsetProfileDto?>
    {
        private readonly IChipsetProfileQueryRepository _queryRepository;

        public GetChipsetProfileByIdQueryHandler(IChipsetProfileQueryRepository repository)
        {
            _queryRepository = repository;
        }

        public async Task<ChipsetProfileDto?> Handle(GetChipsetProfileByIdQuery request, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetChipsetProfileByIdAsync(request.Id);
        }
    }
}
