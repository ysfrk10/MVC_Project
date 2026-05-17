namespace GymBL.Services.Interfaces
{
    public interface ITrainerService
    {
        public void AddTrainer(AddTrainerDTO trainer);
        public List<AddTrainerDTO> ViewAllTrainers();
        public AddTrainerDTO GetTrainers(int id);
        public void EditTrainer(AddTrainerDTO m);
        public void ReomveTrainer(int id);
    }
}
