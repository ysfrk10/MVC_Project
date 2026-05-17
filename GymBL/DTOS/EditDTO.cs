namespace GymBL.DTOS
{
    public class EditDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }
        //public string TrainerName { get; set; }=string.Empty;
    }
}
