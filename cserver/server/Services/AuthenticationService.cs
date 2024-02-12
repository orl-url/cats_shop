using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using server.Models;

namespace server.Services;

public class AuthenticationService(
   IHttpContextAccessor contextAccessor,
   UsersService usersService)
{

   public async Task<User?> SignIn(Credential credential)
   {
      var credentialIsValid = await VerifyCredential(credential);

      if (credentialIsValid)
      {
         var principal = await CreatePrincipal(credential);
         await AddCookiesToRequest(principal);

         var user = await usersService.GetUserByName(credential.Name);
         return user;
      }

      return null;
   }

   public async Task SignUp(Credential credential)
   {
      var newUser = new User
      {
         Name = credential.Name,
         Password = credential.Password
      };
      
      var createdUser = await usersService.CreateUserAsync(newUser);
   }

   public async Task SignOut()
   {
      await removeCookiesToRequest();
   }
   
   public async Task<bool> VerifyCredential(Credential credential)   
   {
      var user = await usersService.GetUserByName(credential.Name);
      
      if (user == null)
      {
         return false;
      }

      if (credential.Name == user.Name && credential.Password == user.Password)
      {
         return true;
      }

      return false;
   }

   public async Task<ClaimsPrincipal> CreatePrincipal(Credential credential)
   {
      var claims = new List<Claim>
      {
         new Claim(ClaimTypes.Name, credential.Name)
      };

      var identity = new ClaimsIdentity(claims, "CookieAuth");
      var principal = new ClaimsPrincipal(identity);
      
      return principal;
   }

   public async Task AddCookiesToRequest(ClaimsPrincipal principal)
   {
      await contextAccessor.HttpContext!.SignInAsync("CookieAuth", principal);
   }

     public async Task removeCookiesToRequest()
   {
      await contextAccessor.HttpContext!.SignOutAsync("CookieAuth");
   }

   
}