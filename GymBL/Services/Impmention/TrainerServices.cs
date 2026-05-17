using AutoMapper;

namespace GymBL.Services.Impmention
{
    public class TrainerServices : ITrainerService
    {
        #region De Injection
        private readonly ITrainerRepo _repo;
        private readonly IMapper _mapper;
        public TrainerServices(ITrainerRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        #endregion

        #region AddTrainer
        public void AddTrainer(AddTrainerDTO dto)
        {
            _repo.AddTrainer(new Trainer()
            {
                PhoneNumber = dto.PhoneNumber,
                Name = dto.Name,
                ImgPath = dto.ImgPath,
            });

        }

        #endregion

        #region GetByID
        public AddTrainerDTO GetTrainers(int id)
        {
            var trainer = _repo.GetTrainers(id);
            var dto = new AddTrainerDTO();
            _mapper.Map<Trainer>(dto);
            return dto;
        }
        #endregion

        #region ViewAllTrainers
        public List<AddTrainerDTO> ViewAllTrainers()
        {
            var trainers = _repo.ViewAllTrainers();
            var dtos = new List<AddTrainerDTO>();
            return trainers.Select(x => new AddTrainerDTO()
            {
                Id = x.Id,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                ImgPath = x.ImgPath,
            }).ToList();
        }
        #endregion

        #region  EditTrainer
        public void EditTrainer(AddTrainerDTO m)
        {
            var current = _repo.GetTrainers(m.Id);
            if (current == null)
            {
                throw new Exception("Trainer Not Found");
            }

            current.Name = m.Name;
            current.PhoneNumber = m.PhoneNumber;
            _repo.EditTrainer(current);
        }

        #endregion

        #region ReomveTrainer
        public void ReomveTrainer(int id)
        {
            _repo.ReomveTrainer(id);
        }


        #endregion
    }
}
