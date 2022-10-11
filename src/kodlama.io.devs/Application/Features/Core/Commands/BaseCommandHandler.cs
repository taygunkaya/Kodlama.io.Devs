using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Core.Commands
{
    public class BaseCommandHandler<TRepository, BusinessRules>
    {
        protected TRepository _repository;
        protected IMapper _mapper;
        protected BusinessRules _businessRules;

        public BaseCommandHandler(TRepository repository, IMapper mapper, BusinessRules businessRules)
        {
            _repository = repository;
            _mapper = mapper;
            _businessRules = businessRules;
        }
    }
}
