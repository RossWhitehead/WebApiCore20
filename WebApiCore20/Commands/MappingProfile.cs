using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace WebApiCore20.Commands
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer.Create.Command, Data.Customer>();
            CreateMap<Customer.Update.Command, Data.Customer>();
        }
    }
}
