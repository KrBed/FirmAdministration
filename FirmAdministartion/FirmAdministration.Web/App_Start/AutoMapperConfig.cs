using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using FirmAdministartion.Data.Identity;
using FirmAdministration.Web.Models.ViewModels;

namespace FirmAdministration.Web.App_Start
{
    public  class AutoMapperConfig :Profile
    {
        public AutoMapperConfig()
        {
            Mapper.Initialize(x => x.CreateMap<ApplicationUser, UserViewModel>());
            Mapper.Initialize(x => x.CreateMap<IList<ApplicationUser>,IList<UserViewModel>>());
        }

        
       
    }
}