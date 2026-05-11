using System;
using System.Collections.Generic;
using System.Text;

namespace GymDAL.Entities
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string ImgPath { get; set; } = string.Empty;

        //Relationships
        public List<Member>? Trainees { get; set; }

    }
}
