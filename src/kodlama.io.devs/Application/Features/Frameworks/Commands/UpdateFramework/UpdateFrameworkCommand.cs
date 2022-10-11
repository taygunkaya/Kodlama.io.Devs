using Application.Features.Frameworks.Dtos;
using Application.Features.Frameworks.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Frameworks.Commands.UpdateFramework
{
    public class UpdateFrameworkCommand : IRequest<UpdatedFrameworkDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class UpdateFrameworkCommandHandler : IRequestHandler<UpdateFrameworkCommand, UpdatedFrameworkDto>
        {
            private readonly IFrameworkRepository _frameworkRepository;
            private readonly IMapper _mapper;
            private readonly FrameworkBusinessRules _businessRules;

            public UpdateFrameworkCommandHandler(IFrameworkRepository frameworkRepository, IMapper mapper, FrameworkBusinessRules businessRules)
            {
                _frameworkRepository = frameworkRepository;
                _mapper = mapper;
                _businessRules = businessRules;
            }

            public async Task<UpdatedFrameworkDto> Handle(UpdateFrameworkCommand request, CancellationToken cancellationToken)
            {
                Framework? framework = await _frameworkRepository.GetAsync(f => f.Id == request.Id);

                _businessRules.FrameworkShouldExistWhenRequested(framework);

                framework.Name = request.Name;
                framework.LanguageId = request.ProgrammingLanguageId;

                Framework frameworkToUpdate = await _frameworkRepository.UpdateAsync(framework);
                UpdatedFrameworkDto updatedFrameworkDto = _mapper.Map<UpdatedFrameworkDto>(frameworkToUpdate);

                return updatedFrameworkDto;
            }
        }
    }
}
