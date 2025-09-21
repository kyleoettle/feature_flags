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
            var userId = user.ID;
            var groups = user.Companies;
            var targetingContext = new TargetingContext
            {
                UserId = user.ID.ToString(),
                Groups = user.Companies.Select(x => x.ID.ToString())
            };

            return new ValueTask<TargetingContext>(targetingContext);
        }
    }
}

