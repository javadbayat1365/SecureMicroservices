using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServer
{
    public class Config
    {
        private const string _movieApi = "movieAPI";
        public static IEnumerable<Client> Clients =>
            new Client[] {
            new Client{
             ClientId = "movieClient",
             AllowedGrantTypes = GrantTypes.ClientCredentials,
             ClientSecrets ={
                new Secret("secret".Sha256())
                },
             AllowedScopes={ _movieApi }
            }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[] {
             new ApiScope(_movieApi,"Movie API")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[] { };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[] { };

        public static List<TestUser> TestUsers =>
            new List<TestUser> { };
    }
}
