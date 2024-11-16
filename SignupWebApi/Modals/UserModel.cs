namespace SignupWebApi.Modals
{
    public class UserModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public string ConfrimPassword { get; set; }
    }
}
