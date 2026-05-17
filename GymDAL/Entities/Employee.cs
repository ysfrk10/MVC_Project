using Microsoft.IdentityModel.Tokens;

namespace GymDAL.Entities
{
    public class Employee
    {
        public Employee(string name, decimal salary, string createby)
        {
            Name = name;
            Salary = salary;
            CreateBy = createby;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Salary { get; private set; }
        public string? CreateBy { get; private set; }
        public string? updateby { get; private set; }

        public DateTime Createdt { get; private set; }
        public DateTime? updatedt { get; private set; }
        public DateTime? Deletedt { get; private set; }

        public bool Update(string name, decimal salary, string UserModifeid)
        {
            if (!string.IsNullOrWhiteSpace(UserModifeid))
            {
                Name = name;
                Salary = salary;
                updatedt = DateTime.Now;
                updateby = UserModifeid;
                return true;
            }
            return false;
        }

    }
}
