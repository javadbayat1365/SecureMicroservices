using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

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
             ClientSecrets ={new Secret("secret".Sha256())},
             AllowedScopes={ _movieApi }
            },
            new Client{
             ClientId="movies_mvc_client",
             ClientName="Movies MVC Web App",
             AllowedGrantTypes= GrantTypes.Code,
             AllowRememberConsent = false,
             RedirectUris = new List<string>(){
                 "https://localhost:5002/signin-oidc"
             },
             PostLogoutRedirectUris = new List<string>(){
                 "https://localhost:5002/signout-callback-oidc"
             },
             ClientSecrets = new List<Secret>{
                 new Secret("secret".Sha256())
             },
             AllowedScopes=new List<string>
             {
                 IdentityServerConstants.StandardScopes.OpenId,
                 IdentityServerConstants.StandardScopes.Profile
             }
            }
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[] {
             new ApiScope(_movieApi,"Movie API")
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[] { };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[] {
            new IdentityResources.OpenId(),
            new IdentityResources.Profile()
            };

        public static List<TestUser> TestUsers =>
            new List<TestUser> {
            new TestUser
            {
                 SubjectId ="HGF74YTR-0JHY-E5E5-JHG67UY543ED",
                 Username="javad",
                 Password="javad",
                 Claims = new List<Claim>
                 {
                     new Claim(JwtClaimTypes.GivenName,"javad"),
                     new Claim(JwtClaimTypes.FamilyName,"bayat"),
                 }
            }
            };
    }
}
