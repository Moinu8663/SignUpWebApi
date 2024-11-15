using GraphQL;
using GraphQL.Types;
using SignupWebApi.Data;
using SignupWebApi.GraphQlType;

namespace SignupWebApi.GraphQl
{
    public class UserQuery : ObjectGraphType
    {
        public UserQuery(IService service)
        {
            Field<ListGraphType<UserType>>("getAllUsers")
                .Resolve(context => service.GetAllUser());

            Field<UserType>("getUserByMobileNo")
                .Arguments(new QueryArguments(new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "mobileNo" }))
                .Resolve(context =>
                {
                    var mobileNo = context.GetArgument<string>("mobileNo");
                    return service.GetUserByMobileNo(mobileNo);
                });
        }
    }
}
