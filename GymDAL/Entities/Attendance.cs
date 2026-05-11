using System;
using System.Collections.Generic;
using System.Text;

namespace GymDAL.Entities
{
    public class Attendance
    {
        public int id { set; get; }

        public DateTime Date { set; get; }


        //Relationships
        public int? MemberId { set; get; }
        public Member? member { set; get; }
    }
}
