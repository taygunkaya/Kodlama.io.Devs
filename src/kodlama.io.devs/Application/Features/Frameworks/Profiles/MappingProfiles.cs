using Application.Features.Frameworks.Commands.CreateFramework;
using Application.Features.Frameworks.Commands.DeleteFramework;
using Application.Features.Frameworks.Commands.UpdateFramework;
using Application.Features.Frameworks.Dtos;
using Application.Features.Frameworks.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Frameworks.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Framework, FrameworkListDto>().ForMember(f =>
            f.LanguageName, opt => opt.MapFrom(c => c.Language.Name))
                .ReverseMap();
            CreateMap<IPaginate<Framework>, FrameworkListModel>().ReverseMap();


            CreateMap<Framework, CreateFrameworkCommand>().ReverseMap();
            CreateMap<Framework, CreatedFrameworkDto>().ReverseMap();


            CreateMap<Framework, DeleteFrameworkCommand>().ReverseMap();
            CreateMap<Framework, DeletedFrameworkDto>().ReverseMap();


            CreateMap<Framework, UpdateFrameworkCommand>().ReverseMap();
            CreateMap<Framework, UpdatedFrameworkDto>().ReverseMap();

        }
    }
}
