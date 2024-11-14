using GraphQL.Types;

namespace SignupWebApi.GraphQlType
{
    public class AuthPayloadType : ObjectGraphType
    {
        public AuthPayloadType()
        {
            Field<StringGraphType>("token", description: "JWT token");
            Field<StringGraphType>("mobileNo", description: "User Mobile No");
        }
    }
}
