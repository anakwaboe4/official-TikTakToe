namespace TikTakToe.Core
{
    public static class Globals
    {
        public static class AppSettings
        {
            public const string ClientId = "AzureAd:ClientId";              // Client ID of the app registration in Azure AD
            public const string ClientAppUri = "AzureAd:ClientAppUri";      // URI of the client app in Azure AD
            public const string TenantId = "AzureAd:TenantId";              // Tenant ID of the Azure AD
            public const string Instance = "AzureAd:Instance";              // https://login.microsoftonline.com/
        }

        public static class Engines
        {
            public static readonly List<string> EnginesDisplayNames = new List<string>
            {
                "Player",
                "PerfectOptemism",
            };
        }
    }
}