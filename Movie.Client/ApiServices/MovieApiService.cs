using IdentityModel.Client;

namespace Movie.Client.ApiServices
{
    public class MovieApiService : IMovieApiService
    {
        public async Task<List<Models.Movie>> GetMovies()
        {

            //1. retrieve our api credentials. This must be registered on Identity Server!
            var apiClientCerentials = new ClientCredentialsTokenRequest
            { 
            Address = "https://localhost:5005/connect/token",
             ClientId = "movieClient",
              ClientSecret = "secret",
              Scope = "movieAPI"
            };

            //creates a new HttpClient to talk to our IdentityServer
            var client = new HttpClient();

            //just checks  if we can reach the Discovery document. Not 100% needed but ...
            var discon = await client.GetDiscoveryDocumentAsync("https://localhost:5005");
            if (discon.IsError)
            {
                return null;
            }

            //2. Authencticates and get  an access token from identity Server
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(apiClientCerentials);
            if (tokenResponse.IsError)
            {
                return null;
            }

            //Another HttpClient for talking now with our Protected API
            var apiClient = new HttpClient();

            //3. Set the access_token in the request Authorization : Bearer <token>
            client.SetBearerToken(tokenResponse.AccessToken);

           
        }
    }
}
