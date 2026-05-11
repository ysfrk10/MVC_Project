using System;
using System.Collections.Generic;
using System.Text;
using GymDAL.Entities;

namespace GymBL.DTOS
{
    public class AddDTO
    {
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }
        public int TrainerId { get; set; }
    }
}
