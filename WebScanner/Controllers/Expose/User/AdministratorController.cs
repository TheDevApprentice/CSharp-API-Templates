using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebScrapper.DOMAIN;

namespace WebScanner.Controllers;

/// <summary>
/// Controller authentificated by OAuth Token and Basic Auth
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
    /// <returns>Test</returns>
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
    [ProducesResponseType(typeof(IEnumerable<string>), 200)]

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
    /// <returns>Test</returns>
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
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

    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <returns>Test</returns>
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

    [HttpGet("getUser/{name}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetUser(string name)
    {
        try
        {
            User user = _administratorService.GetUserByUsernName(name);
            if (user == null)
            {
                return NotFound($"User with name {user} not found.");
            }
            return Ok(user);
        }
        catch (Exception e)
        {
            ReturnedErrorMessageInfo returnedErrorMessage = new(
                "Error retrieving user.",
                e.Message);
            return StatusCode(500, returnedErrorMessage);
        }
    }


    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <returns>Test</returns>
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
    [HttpPost("createUser")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult CreateUser([FromBody] User newUser)
    {
        try
        {
            // You might want to perform validation on newUser before creating it
            _administratorService.AddUser(newUser);
            return StatusCode(201, "User created successfully.");
        }
        catch (Exception e)
        {
            ReturnedErrorMessageInfo returnedErrorMessage = new(
                "Error creating user.",
                e.Message);
            return StatusCode(500, returnedErrorMessage);
        }
    }

    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <returns>Test</returns>
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
    [HttpPut("updateUser/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult UpdateUser(int userId, [FromBody] User updatedUser)
    {
        try
        {
            if (userId != updatedUser.UserId)
            {
                return BadRequest("User ID mismatch.");
            }

            User userExists = _administratorService.ModifyUser(updatedUser);
            if (userExists != null)
            {
                return NotFound($"User with ID {userId} not found.");
            }

            // You might want to perform validation on updatedUser before updating it
            //_administratorService./*UpdateUser*/(updatedUser);
            return Ok(userExists);
        }
        catch (Exception e)
        {
            ReturnedErrorMessageInfo returnedErrorMessage = new(
                "Error updating user.",
                e.Message);
            return StatusCode(500, returnedErrorMessage);
        }
    }

    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <returns>Test</returns>
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
    [HttpDelete("deleteUser/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult DeleteUser(int userId)
    {
        try
        {
            //bool userExists = _administratorService.UserExists(userId);
            //if (!userExists)
            //{
            //    return NotFound($"User with ID {userId} not found.");
            //}

            //_administratorService.DeleteUser(userId);
            return NoContent();
        }
        catch (Exception e)
        {
            ReturnedErrorMessageInfo returnedErrorMessage = new(
                "Error deleting user.",
                e.Message);
            return StatusCode(500, returnedErrorMessage);
        }
    }
}