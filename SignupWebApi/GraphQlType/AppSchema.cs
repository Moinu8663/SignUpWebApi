using GraphQL.Types;
using SignupWebApi.GraphQl;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SignupWebApi.GraphQlType
{
    public class AppSchema : Schema
    {
        public AppSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<UserQuery>();
            Mutation = provider.GetRequiredService<UserMutation>();
        }
    }
}
