namespace SignupWebApi.Exceptions
{
    public class UserAlreadyExistsException : FormatException
    {
        public UserAlreadyExistsException(string massage) : base(massage) { }
    }
    public class UserNotFoundException : FormatException
    {
        public UserNotFoundException(string message) : base(message) { }
    }
}
