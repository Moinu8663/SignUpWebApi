using GraphQL.Types;
using SignupWebApi.Modals;

namespace SignupWebApi.GraphQlType
{
    public class UserType : ObjectGraphType<UserModel>
    {
        public UserType()
        {
            Field(e => e.Id).Description("The Employee Code of the user");
            Field(e => e.FirstName).Description("The first name of the user");
            Field(e => e.LastName).Description("The last name of the user");
            Field(e => e.MobileNo).Description("The MobileNo of the user");
            Field(e => e.Email).Description("The EmailId of the user");
            Field(e => e.DateOfBirth).Description("The Dob of the user");
            Field(e => e.Address).Description("The address of the user");
            Field(e => e.Password).Description("The Password of the user");
            Field(e => e.ConfrimPassword).Description("The ConfrimPassword of the user");
        }
    }
}
