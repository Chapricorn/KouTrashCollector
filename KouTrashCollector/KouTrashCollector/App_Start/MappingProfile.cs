using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using KouTrashCollector.CustomerInfo;
using KouTrashCollector.Models;

namespace KouTrashCollector.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerData>();
            Mapper.CreateMap<CustomerData, Customer>();
        }
    }
}