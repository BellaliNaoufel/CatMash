using AutoMapper;
using CatMash.Api.Models;
using CatMash.Domain.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMash.Api.Mapping
{
    public class MappingCat : Profile
    {
        public MappingCat()
        {
            CreateMap<Cat, CatModel>();
            CreateMap<CatModel, Cat>();
        }
    }
}
