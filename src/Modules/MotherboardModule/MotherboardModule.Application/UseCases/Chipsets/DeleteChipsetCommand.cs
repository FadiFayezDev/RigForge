using MediatR;
using MotherboardModule.Application.Abstractions;
using MotherboardModule.Application.Repositories.Commands;

namespace MotherboardModule.Application.UseCases.Chipsets
{
    public sealed record DeleteChipsetCommand(Guid Id) : ICommand<bool>;

    public sealed class DeleteChipsetCommandHandler : IRequestHandler<DeleteChipsetCommand, bool>
    {
        private readonly IChipsetProfileRepository _repository;

        public DeleteChipsetCommandHandler(IChipsetProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteChipsetCommand request, CancellationToken cancellationToken)
        {
            var id = MotherboardModule.Domain.Primitives.Identifiers.ChipsetProfileId.FromGuid(request.Id);
            var chipset = await _repository.GetByIdAsync(id);
            if (chipset is null)
                return false;

            await _repository.RemoveAsync(chipset);
            return true;
        }
    }
}
