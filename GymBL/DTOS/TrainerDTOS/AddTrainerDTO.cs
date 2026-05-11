using System;
using System.Collections.Generic;
using System.Text;

namespace GymBL.DTOS.TrainerDTOS
{
    public class AddTrainerDTO
    {
        public int  Id{ get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string ImgPath { get; set; } = string.Empty;

    }
}
