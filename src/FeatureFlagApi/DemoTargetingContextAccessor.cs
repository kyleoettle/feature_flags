using Microsoft.FeatureManagement.FeatureFilters;

namespace FeatureFlagApi
{
    public class DemoTargetingContextAccessor : ITargetingContextAccessor
    {
        private readonly IUserService _userService;

        public DemoTargetingContextAccessor(IUserService userService)
        {
            _userService = userService;
        }

        public ValueTask<TargetingContext> GetContextAsync()
        {
            var user = _userService.GetCurrentUser();
            var targetingContext = new TargetingContext
            {
                UserId = user.Name.ToString(),
                Groups = user.Companies.Select(x => x.Name.ToString())
            };

            return new ValueTask<TargetingContext>(targetingContext);
        }
    }
}

