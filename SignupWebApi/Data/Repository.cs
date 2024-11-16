using SignupWebApi.Modals;

namespace SignupWebApi.Data
{
    public class Repository : IRepo
    {
        private readonly UserContext dbcontext;

        public Repository(UserContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        public void DeleteUser(string Mobile_No)
        {
            var us = GetUserByMobileNo(Mobile_No);
            dbcontext.UserModels.Remove(us);
            dbcontext.SaveChanges();
        }   

        public List<UserModel> GetAllUser()
        {
            return dbcontext.UserModels.ToList();
        }

        public UserModel GetUserByMobileNo(string Mobile_No)
        {
            return dbcontext.UserModels.Where(u => u.MobileNo == Mobile_No).FirstOrDefault();
        }

        public UserModel LoginUser(UserModel user)
        {
            var userobj = dbcontext.UserModels.Where(u => u.MobileNo == user.MobileNo && u.Password == user.Password).FirstOrDefault();
            return userobj;
        }

        public void RegisterUser(UserModel user)
        {
            dbcontext.UserModels.Add(user);
            dbcontext.SaveChanges();
        }

        public void UpdateUser(string Mobile_No, UserModel user)
        {
            var us = GetUserByMobileNo(Mobile_No);           
            us.Email = user.Email;
            us.FirstName = user.FirstName;
            us.LastName = user.LastName;
            us.Address =user.Address;
            us.Password = user.Password;
            us.ConfrimPassword = user.ConfrimPassword;
            us.DateOfBirth = user.DateOfBirth;
            dbcontext.SaveChanges();
        }
    }
    public interface IRepo
    {
        void RegisterUser(UserModel user);
        public List<UserModel> GetAllUser();
        public UserModel GetUserByMobileNo(string Mobile_No);
        public void UpdateUser(string Mobile_No, UserModel user);
        public void DeleteUser(string Mobile_No);
        UserModel LoginUser(UserModel user);
    }
}
