namespace FeatureFlagApi
{
    public class UserService : IUserService
    {
        public User GetCurrentUser()
        {
            //Get user based on your identity provider.

            var groups = new List<Companies>
            {
                new Companies(new Guid("A9726B81-F306-450B-B26B-0EB061700633"), "CompanyA"),
                new Companies(new Guid("5A1230AD-48FC-461A-B44F-1D3477974664"), "CompanyB"),
                new Companies(new Guid("835DAB0A-8378-44D2-8F93-9FC49D3D7849"), "CompanyX")
            };
            return new User(new Guid("41EAA244-9939-48D4-9820-B0B41F716F81"), "MockUser", groups);
        }
    }

    public record User(Guid ID, string Name, List<Companies> Companies);
    public record Companies(Guid ID, string Name);


}
