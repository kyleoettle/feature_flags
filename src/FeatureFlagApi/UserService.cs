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
            var modules = new List<Modules>
            {
                new Modules(new Guid("9079E1C6-39C4-4B10-BBAD-09EDD6B73AF7"), "module1"),
                new Modules(new Guid("E750CF3B-0A68-4EC5-B938-540AB2686ED8"), "module2"),
                new Modules(new Guid("9D2AFB05-8FCB-4929-84FA-6F196BA60452"), "module99")
            };
            return new User(new Guid("41EAA244-9939-48D4-9820-B0B41F716F81"), "MockUser", groups, modules);
        }
    }

    public record User(Guid ID, string Name, List<Companies> Companies, List<Modules> Modules);
    public record Companies(Guid ID, string Name);
    public record Modules(Guid ID, string Name);


}
