using System;
using System.Collections.Generic;
namespace GymDAL.Repos.InterFaces
{
    public interface ITrainerRepo
    {
        public void AddTrainer(Trainer trainer);
        public List<Trainer> ViewAllTrainers();

        public Trainer GetTrainers(int id);
        public void EditTrainer(Trainer m);
        public void ReomveTrainer(int id);
    }
}
