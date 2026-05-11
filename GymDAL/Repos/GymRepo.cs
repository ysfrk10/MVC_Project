using System;
using System.Collections.Generic;
using System.Text;
using GymDAL.Data;
using GymDAL.Entities;
using GymDAL.InterFaces;

namespace GymDAL.Repos
{
    public class GymRepo : IGymRepo
    {
        #region De Injection
        private readonly AppDbContext _context;
        public GymRepo(AppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region AddMember
        public void AddMember(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
        }
        #endregion

        #region GetMember
        public Member GetMember(int id)
        {
            return _context.Members.Find(id);
        }
        #endregion

        #region ViewAllMember
        public List<Member> ViewAllMember()
        {
            return _context.Members.ToList();
        }
        #endregion

        #region EditMember
        public void EditMember(Member member)
        {
            _context.Members.Update(member);
            _context.SaveChanges();
        }
        #endregion

        #region Remove Member
        public void ReomveMember(int id)
        {
            var member = _context.Members.Find(id);
            _context.Members.Remove(member);
            _context.SaveChanges();
        }
        #endregion

    }
}