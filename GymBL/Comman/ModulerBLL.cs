using System;
using System.Collections.Generic;
using System.Text;
using GymBL.Mapper;
using GymBL.Services.Impmention;
using GymDAL.Repos.Implmention;
using Microsoft.Extensions.DependencyInjection;

namespace GymBL.Comman
{
    public static class ModulerBLL
    {
        public static IServiceCollection AddMemberBusnissToBLL(this IServiceCollection Services)
        {
            Services.AddScoped<IGymService, GymServices>();
            Services.AddAutoMapper(e => e.AddProfile(new DomainProfile()));
            return Services;
        }
        public static IServiceCollection AddTrainerBusnissToBLL(this IServiceCollection Services)
        {
            Services.AddScoped<ITrainerService, TrainerServices>();
            return Services;
        }

    }
}
