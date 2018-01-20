using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace WebApiCore20.Queries
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Data.Customer, Queries.Customer.GetAll.QueryResult.Customer>();
            CreateMap<Data.Customer, Queries.Customer.Get.QueryResult>();
        }
    }
}
