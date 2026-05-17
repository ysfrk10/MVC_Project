namespace GymBL.Services.Interfaces
{
    public interface IGymService
    {
        public void AddMember(AddDTO dto);
        public List<GetDTO> ViewAllMember();
        public GetDTO GetMember(int id);
        public void EditMember(EditDTO m);
        public void ReomveMember(int id);


    }
}
