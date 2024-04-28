using Microsoft.AspNetCore.Mvc;
using WebScrapper.DOMAIN;
using WebScrapper.DOMAIN.Models.Helper.TokenHelper;

namespace WebScanner.Controllers;

[ApiController]
[Route("[Controller]")]
public abstract class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IConfiguration? _configuration;
    private EncryptionHelper _encryptionHelper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userService"></param>
    /// <param name="configuration"></param>
    public UserController(
        IUserService userService,
        IConfiguration configuration
    )
    {
        _userService = userService;
        _configuration = configuration;
        _encryptionHelper = new EncryptionHelper(configuration);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userid"></param>
    /// <returns></returns>
    /// 
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    [HttpGet("logout")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public virtual IActionResult Logout(string userid)
    {
        try
        {
            //userid = _encryptionHelper
            //         .Verify(userid);

            return Ok("Logged out successfully");
        }
        catch (Exception e)
        {
            ReturnedErrorMessageInfo returnedErrorMessage = new(
                "Loggout encountered an error...",
                e.Message);

            return StatusCode(
                   500,
                   returnedErrorMessage);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userToken"></param>
    /// <returns></returns>
    /// 
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /Todo
    ///     {
    ///        "id": 1,
    ///        "name": "Item #1",
    ///        "isComplete": true
    ///     }
    ///
    /// </remarks>
    [HttpPost("loginFromCookie")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult LogInFromCookie(TokenInfo userToken = null)
    {
        try
        {
            if (!string.IsNullOrEmpty(userToken.Token))
            {
                if (TokenValidator
                    .IsTokenValid(
                        userToken.Token,
                        _configuration["Jwt:Key"],
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audiance"]))
                {
                    Dictionary<string, object> returnInformation = new();
                    var informationFromTokenToVerify = TokenParser
                        .ParseToken(userToken.Token);

                    ReturnedUserConnectedInfo returnedUserConnected = new();
                    returnedUserConnected.IsTokenValid = true;
                    returnedUserConnected.IsUserConnected = true;
                    returnedUserConnected.Token = userToken.Token;
                    returnedUserConnected.UserType = informationFromTokenToVerify["unique_name"];

                    returnInformation.Add(
                        "userConnectedInformationConfirmation",
                        returnedUserConnected);

                    return Ok(returnInformation);
                }
            }

            return BadRequest("Invalid token.");
        }
        catch (Exception e)
        {
            ReturnedErrorMessageInfo returnedErrorMessage = new(
                "login From Cookie Encountered an error...",
                e.Message);
            return StatusCode(
                   500,
                   returnedErrorMessage);
        }
    }
}
