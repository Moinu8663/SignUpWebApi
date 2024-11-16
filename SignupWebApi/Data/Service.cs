using SignupWebApi.Exceptions;
using SignupWebApi.Modals;

namespace SignupWebApi.Data
{
    public class Service : IService
    {
        private readonly IRepo repo;
        public Service(IRepo repo)
        {
            this.repo = repo;
        }
        public void DeleteUser(string Mobile_No)
        {
            var us = GetUserByMobileNo(Mobile_No);
            if (us == null)
            {
                throw new UserNotFoundException($"user with mobile no {Mobile_No} not found");
            }
            else
            {
                repo.DeleteUser(Mobile_No);
            }
        }

        public List<UserModel> GetAllUser()
        {
            return repo.GetAllUser();
        }

        public UserModel GetUserByMobileNo(string Mobile_No)
        {
            if (Mobile_No != null)
            {
                return repo.GetUserByMobileNo(Mobile_No);

            }
            else
            {
                throw new UserNotFoundException("User Not Found");
            }
        }

        public UserModel LoginUser(UserModel user)
        {
            if (user != null)
            {
                return repo.LoginUser(user);
            }
            else
            {
                throw new UserNotFoundException("User Not Found");
            }
        }

        public void RegisterUser(UserModel user)
        {
            if (user != null)
            {
                repo.RegisterUser(user);
            }
            else
            {
                throw new UserAlreadyExistsException("User already exists");
            }
        }

        public void UpdateUser(string Mobile_No, UserModel user)
        {
            var us = GetUserByMobileNo(Mobile_No);
            if (us == null)
            {
                throw new UserNotFoundException($"user with mobile no {Mobile_No} not found");
            }
            else
            {
                repo.UpdateUser(Mobile_No, user);
            }
        }
    }
    public interface IService
    {
        void RegisterUser(UserModel user);
        public List<UserModel> GetAllUser();
        public UserModel GetUserByMobileNo(string Mobile_No);
        public void UpdateUser(string Mobile_No, UserModel user);
        public void DeleteUser(string Mobile_No);
        UserModel LoginUser(UserModel user);
    }
}
