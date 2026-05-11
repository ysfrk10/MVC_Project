using System;
using System.Collections.Generic;
using System.Text;

namespace GymDAL.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime JoinDate { get; set; }

        //RelationShips
        public int? MemberShipId { get; set; }
        public MemberShip? MeShip { set; get; }
        public int? TrainerId { get; set; }
        public Trainer? Trainer { set; get; }
        public List<Attendance> AttDays { get; set; }

    }
}
