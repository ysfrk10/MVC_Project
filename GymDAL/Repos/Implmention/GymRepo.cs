namespace GymDAL.Repos.Implmention
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
            try
            {
                _context.Members.Add(member);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
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
            try
            {
                return _context.Members.ToList();
            }
            catch (Exception)
            {
                throw;
            }

        }
        #endregion

        #region EditMember
        public void EditMember(Member member)
        {
            try
            {
                _context.Members.Update(member);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

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