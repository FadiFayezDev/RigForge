using MotherboardModule.Application.Repositories.Queries;
using MotherboardModule.Contracts.DTOs;
using MediatR;

namespace MotherboardModule.Application.UseCases.Motherboards
{
    public sealed record GetMotherboardProfileByNameQuery(string Name) : IRequest<MotherboardProfileDto?>;

    public sealed class GetMotherboardProfileByNameQueryHandler : IRequestHandler<GetMotherboardProfileByNameQuery, MotherboardProfileDto?>
    {
        private readonly IMotherboardProfileQueryRepository _queryRepository;

        public GetMotherboardProfileByNameQueryHandler(IMotherboardProfileQueryRepository repository)
        {
            _queryRepository = repository;
        }

        public async Task<MotherboardProfileDto?> Handle(GetMotherboardProfileByNameQuery request, CancellationToken cancellationToken)
        {
            return await _queryRepository.GetMotherboardProfileByNameAsync(request.Name);
        }
    }
}
