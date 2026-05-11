using System;
using System.Collections.Generic;
using System.Text;

namespace GymDAL.Entities
{
    public class MemberShip
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double price { get; set; }
        public int DurationMonthes { get; set; }

        //Relationships
        public List<Member>? Subscribers { get; set; }

    }
}
