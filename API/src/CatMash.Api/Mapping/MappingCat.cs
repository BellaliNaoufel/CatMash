using AutoMapper;
using CatMash.Api.Models;
using CatMash.Api.Models.Requests;
using CatMash.Api.Models.Responses;
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
            CreateMap<Cat, CatResponseModel>();
            CreateMap<CatResponseModel, Cat>();

            CreateMap<Cat, CatRequestModel>();
            CreateMap<CatRequestModel, Cat>();
        }
    }
}
