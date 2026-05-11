using System;
using System.Collections.Generic;
using System.Text;
using GymBL.DTOS.TrainerDTOS;
using GymDAL.Entities;

namespace GymBL.Interfaces
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
