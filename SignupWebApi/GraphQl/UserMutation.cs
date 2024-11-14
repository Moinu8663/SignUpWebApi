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
        public UserMutation(Service service, ITokenGenerator tokenGenerator)
        {
            //Field<AuthPayloadType>("LogIn")
            //    .Arguments(new QueryArguments(
            //        new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "mobileNo" },
            //        new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "password" }
            //    ))
            //    .Resolve(context =>
            //    {
            //        var mobileNo = context.GetArgument<string>("empCode");
            //        var password = context.GetArgument<string>("firstName");

            //        // Fetch user details from the repository
            //        var user = service.LoginUser(new UserModel { MobileNo = mobileNo, Password = password });

            //        // Generate JWT token
            //        var token = tokenGenerator.GenerateToken(user);

            //        // Return both the token and the employee code
            //        return new
            //        {
            //            token,
            //            mobileNo = user.MobileNo
            //        };
            //    });

            //Field<UserType>("RegisterUser")
            //    .Arguments(new QueryArguments(
            //        new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }
            //    ))
            //    .Resolve(context =>
            //    {
            //        var user = context.GetArgument<UserModel>("user");
            //        return repo.AddUser(user);
            //    });

            //Field<UserType>("updateUser")
            //    .Arguments(new QueryArguments(
            //        new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" },
            //        new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "empCode" }
            //    ))
            //    .Resolve(context =>
            //    {
            //        var user = context.GetArgument<UserDetailsModel>("user");
            //        var empCode = context.GetArgument<string>("empCode");
            //        return repo.UpdateUser(user, empCode);
            //    });

            //Field<StringGraphType>("deleteUser")
            //    .Arguments(new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "empCode" }))
            //    .Resolve(context =>
            //    {
            //        var empCode = context.GetArgument<string>("empCode");
            //        repo.DeleteUser(empCode);
            //        return $"User with EmpCode {empCode} was deleted.";
            //    });
        }
    }
}
