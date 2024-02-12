using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers;

[EnableCors]
[ApiController]
public class AuthenticationController(
    AuthenticationService authenticationService
    ) : ControllerBase
{

    [HttpPost]
    [Route("/signUp")]
    public async Task<User?> SignUp(Credential credential)
    {
        await authenticationService.SignUp(credential);
        return await authenticationService.SignIn(credential);
    }

    [HttpPost]
    [Route("/signIn")]
    public async Task<User?> SignIn(Credential credential)
    {
        return await authenticationService.SignIn(credential);
    }  
    
    [Authorize]
    [HttpPost]
    [Route("/signOut")]
    public new async Task SignOut()
    {
        await authenticationService.SignOut();
    }




}