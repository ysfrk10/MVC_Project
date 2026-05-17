
using AutoMapper;

namespace GymBL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Trainer, AddTrainerDTO>().ReverseMap();
        }
    }
}
