using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebScrapper.DOMAIN;

namespace WebScanner.Controllers;
/// <summary>
/// 
/// </summary>
[ApiController]
[AutoValidateAntiforgeryToken]
[Authorize(Roles = "Administrator")]
[Route("[Controller]")]
public class AdministratorController : UserController
{
    private readonly IUserService _administratorService;

    private EncryptionHelper _encryptionHelper;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userService"></param>
    /// <param name="configuration"></param>
    public AdministratorController(IUserService userService, IConfiguration configuration = null) : base(userService, configuration)
    {
        _administratorService = userService;
        _encryptionHelper = new(configuration);
    }

    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
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
    [HttpGet("findUsers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[ValidateAntiForgeryToken]
    public IActionResult FindUsers()
    {
        try
        {
            Dictionary<string, object> returnInformation = new() {
                {
                  "ReturnSucessConnectionMessage",
                  "Logged in sucessfully"
                }
            };

            return Ok(returnInformation);
        }
        catch (Exception e)
        {
            ReturnedErrorMessageInfo returnedErrorMessage = new(
                                        "Not able to login... : ",
                                        e.Message);

            return StatusCode(
                500,
                returnedErrorMessage);
        }
    }

    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
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

    [HttpPost("getUsers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[ValidateAntiForgeryToken]
    public IActionResult GetAllUser()
    {
        try
        {
            Dictionary<string, object> returnInformation =
                new();

            TokenInfo tokenInfo =
                new();

            UserRequestHeaderInformation clientInformationScanner =
                InformationCollector.ClientHeaderInformationRecolter(
                    HttpContext,
                    Request,
                    out returnInformation
                );

            List<User> userToLogin =
                _administratorService.GetAllUsers();

            return Ok(userToLogin);

        }
        catch (Exception e)
        {
            ReturnedErrorMessageInfo returnedErrorMessage = new(
                "Not able to login... : ",
                e.Message);

            return StatusCode(500, returnedErrorMessage);
        }
    }
}