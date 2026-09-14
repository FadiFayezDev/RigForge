using AutoMapper;
using CPUModule.Application.Repositories.Commands;
using CPUModule.Application.Repositories.Queries;
using CPUModule.Contracts.DTOs.CPU;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CPUModule.Application.UseCases.CPUs
{
    public sealed record GetAllCpuMinimalProfilesQuery() : IRequest<IEnumerable<CPUMiniProfileDto>>;

    public sealed class GetAllCpuMinimalProfilesQueryHandler : IRequestHandler<GetAllCpuMinimalProfilesQuery, IEnumerable<CPUMiniProfileDto>>
    {
        private readonly ICPUProfileQueryRepository _repository;
        private readonly IMapper _mapper;

        public GetAllCpuMinimalProfilesQueryHandler(ICPUProfileQueryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CPUMiniProfileDto>> Handle(GetAllCpuMinimalProfilesQuery request, CancellationToken cancellationToken)
        {
            var all = await _repository.GetAllCpuMinimalProfilesAsync();
            return _mapper.Map<IEnumerable<CPUMiniProfileDto>>(all);
        }
    }
}
