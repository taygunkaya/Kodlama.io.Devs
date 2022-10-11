using Application.Features.Frameworks.Dtos;
using Application.Features.Frameworks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Frameworks.Commands.CreateFramework
{
    public class CreateFrameworkCommand : IRequest<CreatedFrameworkDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class CreateFrameworkCommandHandler : IRequestHandler<CreateFrameworkCommand, CreatedFrameworkDto>
        {
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly IMapper _mapper;
            private readonly FrameworkBusinessRules _businessRules;

            public CreateFrameworkCommandHandler(IFrameworkRepository frameworkRepository, IMapper mapper, FrameworkBusinessRules businessRules)
            {
                _frameworkRepository = frameworkRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<CreatedFrameworkDto> Handle(CreateFrameworkCommand request, CancellationToken cancellationToken)
            {
                Framework framework = _mapper.Map<Framework>(request);
                Framework addedFramework = await _frameworkRepository.AddAsync(framework);
                CreatedFrameworkDto createdFrameworkDto = _mapper.Map<CreatedFrameworkDto>(addedFramework);

                return createdFrameworkDto;
            }
        }
    }
}
