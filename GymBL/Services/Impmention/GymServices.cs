namespace GymBL.Services.Impmention
{
    public class GymServices : IGymService
    {
        #region Depandancy injection
        private readonly IGymRepo _repo;
        public GymServices(IGymRepo repo)
        {
            _repo = repo;
        }
        #endregion

        #region AddMember
        public void AddMember(AddDTO member)
        {
            _repo.AddMember(new Member()
            {
                Name = member.Name,
                PhoneNumber = member.PhoneNumber,
                JoinDate = member.JoinDate,
                //TrainerId = member.TrainerId,
            });
        }
        #endregion

        #region EditMember
        public void EditMember(EditDTO m)
        {
            var exist = _repo.GetMember(m.Id);
            exist.Name = m.Name;
            exist.PhoneNumber = m.PhoneNumber;
            exist.JoinDate = m.JoinDate;
            //exist.Trainer?.Name = m.TrainerName;
            _repo.EditMember(exist);
        }
        #endregion

        #region GetById
        public GetDTO GetMember(int id)
        {
            var member = _repo.GetMember(id);

            if (member == null)
            {
                return null;
            }

            var newMember = new GetDTO()
            {
                Name = member.Name,
                PhoneNumber = member.PhoneNumber,
                Id = member.Id,
                JoinDate = member.JoinDate,
                //trainer = member.Trainer?.Name ?? "Still Without Trainer",  // null coalescing
                AttDays = member.AttDays ?? new List<Attendance>()  // لو AttDays ممكن يكون null
            };

            return newMember;
        }


        #endregion

        #region ViewAllMember
        public List<GetDTO> ViewAllMember()
        {
            var members = _repo.ViewAllMember();
            var MemberDtos = new List<GetDTO>();
            return members.Select(m =>
            new GetDTO()
            {
                Id = m.Id,
                Name = m.Name,
                PhoneNumber = m.PhoneNumber,
                JoinDate = m.JoinDate,
                //trainer = m.Trainer?.Name,
                AttDays = m.AttDays,
            }).ToList();
        }
        #endregion

        #region ReomveMember
        public void ReomveMember(int id)
        {
            _repo.ReomveMember(id);
        }
        #endregion



    }

}
