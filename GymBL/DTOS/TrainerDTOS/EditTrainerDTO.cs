using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace GymBL.DTOS.TrainerDTOS
{
    public class EditTrainerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public IFormFile ImgPath { get; set; }


    }
}
