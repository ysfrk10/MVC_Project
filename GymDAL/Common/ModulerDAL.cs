using System.Collections.Generic;
using System.Text;
using GymDAL.Repos.Implmention;
using Microsoft.Extensions.DependencyInjection;

namespace GymDAL.Common
{
    public static class ModulerDAL
    {
        public static IServiceCollection AddMemberRepoInDAL(this IServiceCollection service)
        {
            service.AddScoped<IGymRepo, GymRepo>();
            return service;
        }
        public static IServiceCollection AddTrainerRepoInDAL(this IServiceCollection service)
        {
            service.AddScoped<ITrainerRepo, TrainerRepo>();
            return service;
        }
    }
}
