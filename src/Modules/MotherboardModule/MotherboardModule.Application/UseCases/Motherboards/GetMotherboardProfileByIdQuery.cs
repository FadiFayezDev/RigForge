using MotherboardModule.Application.Repositories.Queries;
using MotherboardModule.Contracts.DTOs;
using MotherboardModule.Domain.Primitives.Identifiers;
using MediatR;

namespace MotherboardModule.Application.UseCases.Motherboards
{
    public sealed record GetMotherboardProfileByIdQuery(MotherboardProfileId Id) : IRequest<MotherboardProfileDto?>;

    public sealed class GetMotherboardProfileByIdQueryHandler : IRequestHandler<GetMotherboardProfileByIdQuery, MotherboardProfileDto?>
    {
        private readonly IMotherboardProfileQueryRepository _queryRepository;

        public GetMotherboardProfileByIdQueryHandler(IMotherboardProfileQueryRepository repository)
        {
            _queryRepository = repository;
        }

        public async Task<MotherboardProfileDto?> Handle(GetMotherboardProfileByIdQuery request, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetMotherboardProfileByIdAsync(request.Id);
        }
    }
}
