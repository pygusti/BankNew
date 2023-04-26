using AutoMapper;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.ViewModel;

namespace BankLayer.Implementaion
{
    public class AppMapper : Profile
    {
        public AppMapper() { }
        public static Mapper config() 
        {  var configuration = new MapperConfiguration(cfg => 
         {
             cfg.CreateMap<UsersViewModel, UsernewModel>();
             cfg.CreateMap<UsernewModel, UsersViewModel>();
         });
            var mapper = new Mapper(configuration); 
            return mapper;
        }
    }
}
