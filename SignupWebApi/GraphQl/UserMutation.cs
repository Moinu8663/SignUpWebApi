using GraphQL;
using GraphQL.Types;
using SignupWebApi.Data;
using SignupWebApi.GraphQlType;
using SignupWebApi.Modals;
using SignupWebApi.Token;

namespace SignupWebApi.GraphQl
{
    public class UserMutation : ObjectGraphType
    {
        public UserMutation(IService service, ITokenGenerator tokenGenerator)
        {
            Field<UserType>("registerUser")
                .Arguments(new QueryArguments(new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }))
                .Resolve(context =>
                {
                    var user = context.GetArgument<UserModel>("user");

                    service.RegisterUser(user);
                    return user;
                });

            Field<AuthPayloadType>("loginUser")
                .Arguments(new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "mobileNo" },
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" }
                ))
                .Resolve(context =>
                {
                    var mobileNo = context.GetArgument<string>("mobileNo");
                    var password = context.GetArgument<string>("password");

                    // Fetch user details from the repository
                    var user = service.LoginUser(new UserModel { MobileNo = mobileNo, Password = password });

                    // Generate JWT token
                    var token = tokenGenerator.GenerateToken(user);

                    // Return both the token and the employee code
                    return new
                    {
                        token,
                        mobileNo = user.MobileNo
                    };
                });

            Field<StringGraphType>("deleteUser")
                .Arguments(new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "mobileNo" }))
                .Resolve(context =>
                {
                    var mobileNo = context.GetArgument<string>("mobileNo");
                    service.DeleteUser(mobileNo);
                    return $"User with mobile number {mobileNo} deleted successfully.";
                });

            Field<UserType>("updateUser")
                .Arguments(new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "mobileNo" },
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }
                ))
                .Resolve(context =>
                {
                    var mobileNo = context.GetArgument<string>("mobileNo");
                    var user = context.GetArgument<UserModel>("user");
                    service.UpdateUser(mobileNo, user);
                    return user;
                });
        }
    }
}
