using GraphQL.Types;
using SignupWebApi.GraphQlType;

namespace SignupWebApi.GraphQl
{
    public class UserQuery : ObjectGraphType
    {

        /*public UserQuery(Repository repo)
        {
            Field<ListGraphType<UserType>>("users")
                .Resolve(context => repo.GetAllUser());

            Field<UserType>("user")
                .Arguments(new QueryArguments(new QueryArgument<StringGraphType> { Name = "empCode" }))
                .Resolve(context =>
                {
                    var empCode = context.GetArgument<string>("empCode");
                    return repo.GetUserByEmpcode(empCode);
                });
        }*/
    }
}
