namespace GymBL.DTOS
{
    public class GetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }
        //public string? trainer { set; get; } = "Still Without Trainer";
        public List<Attendance> AttDays { get; set; }
    }
}
