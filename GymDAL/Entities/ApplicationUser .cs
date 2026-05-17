namespace GymDAL.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Member> MemberItems { get; set; }
        public virtual ICollection<Trainer> TrainerItems { get; set; }
        public virtual ICollection<MemberShip> MemberShipItems { get; set; }
        public virtual ICollection<Attendance> AttendanceItems { get; set; }

    }
}
