using GraphQL.Types;

namespace SignupWebApi.GraphQlType
{
    public class AuthPayloadType : ObjectGraphType
    {
        public AuthPayloadType()
        {
            Field<StringGraphType>("token").Description("JWT token");
            Field<StringGraphType>("mobileNo").Description("User Mobile No");
        }
    }
}
