namespace GymPL.ViewModel.Trainer
{
    public class EditTrainerVM
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public IFormFile ImgPath { get; set; }
    }
}
