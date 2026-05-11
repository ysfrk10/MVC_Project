using System;
using System.Collections.Generic;
using System.Text;
using GymDAL.Data;
using GymDAL.Entities;
using GymDAL.InterFaces;

namespace GymDAL.Repos
{
    public class TrainerRepo : ITrainerRepo
    {
        #region Depandancy inject
        private readonly AppDbContext _Context;

        public TrainerRepo(AppDbContext context)
        {
            _Context = context;
        }
        #endregion

        #region AddTrainer
        public void AddTrainer(Trainer trainer)
        {
            _Context.Trainers.Add(trainer);
            _Context.SaveChanges();
        }
        #endregion

        #region GetByID
        public Trainer GetTrainers(int id)
        {
            var t = _Context.Trainers.Find(id);
            return t;
        }
        #endregion

        #region ViewAllTrainers
        public List<Trainer> ViewAllTrainers()
        {
            return _Context.Trainers.ToList();
        }
        #endregion

        #region  EditTrainer
        public void EditTrainer(Trainer m)
        {
            _Context.Trainers.Update(m);
            _Context.SaveChanges();
        }
        #endregion

        #region ReomveTrainer
        public void ReomveTrainer(int id)
        {
            var trainer = _Context.Trainers.Find(id);
            _Context.Trainers.Remove(trainer);
            _Context.SaveChanges();
        }
        #endregion

    }
}
