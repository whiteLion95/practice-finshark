using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos;
using api.Models;
using AutoMapper;

namespace api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Stock, ReadStockDto>();
            CreateMap<CreateStockDto, Stock>();
        }
    }
}