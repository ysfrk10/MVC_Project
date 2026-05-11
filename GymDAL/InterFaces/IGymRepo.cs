using System;
using System.Collections.Generic;
using System.Text;
using GymDAL.Entities;

namespace GymDAL.InterFaces
{
    public interface IGymRepo
    {
        public void AddMember(Member member);
        public List<Member> ViewAllMember();

        public Member GetMember(int id);
        public void EditMember(Member m);
        public void ReomveMember(int id);
    }
}
