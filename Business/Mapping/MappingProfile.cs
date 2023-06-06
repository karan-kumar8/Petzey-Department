using AutoMapper;
using Domain.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping_Profile
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Departments,DepartmentDto>().ReverseMap();
        }
    }
}
