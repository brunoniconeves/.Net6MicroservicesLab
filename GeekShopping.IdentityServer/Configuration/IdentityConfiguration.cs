using Duende.IdentityServer;
using Duende.IdentityServer.Models;

namespace GeekShopping.IdentityServer.Configuration
{
  public static class IdentityConfiguration
  {
      public const string Admin = "Admin";
      public const string Customer = "Customer";

      public static IEnumerable<IdentityResource> IdentityResources =>
          new List<IdentityResource>
          {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile(),
            new IdentityResource("roles", "Your role(s)", new List<string>() {"role"}),
            new IdentityResource("location", "Your location", new List<string>() {"location"})
          };

      public static IEnumerable<ApiScope> ApiScopes => 
          new List<ApiScope>
          {
              new ApiScope("geek_shopping", "GeekShopping Server"),
              new ApiScope("read", "Read data."),
              new ApiScope("write", "Write data."),
              new ApiScope("delete", "Delete data."),
          };

      public static IEnumerable<Client> Clients =>
          new List<Client>
          {
              new Client {
                  ClientId = "client",
                  ClientSecrets = { new Secret("my_super_secret".Sha256())},
                  AllowedGrantTypes = GrantTypes.ClientCredentials,
                  AllowedScopes = {"read", "write", "profile","geek_shopping" }
              }, 
              new Client {
                  ClientId = "geek_shopping",
                  ClientSecrets = { new Secret("my_super_secret".Sha256())},
                  AllowedGrantTypes = GrantTypes.Code,
                  RedirectUris = {"http://localhost:8440/signin-oidc"},
                  PostLogoutRedirectUris = {"http://localhost:8440/signout-callback-oidc"},
                  AllowedScopes = new List<string>
                  {
                      IdentityServerConstants.StandardScopes.OpenId,
                      IdentityServerConstants.StandardScopes.Email,
                      IdentityServerConstants.StandardScopes.Profile,
                      "geek_shopping"
                  }
              }        
          };    

      


  }
}
