using Microsoft.AspNetCore.Mvc;
using WebScanner.ReturnUserInformation;
using WebScrapper.DOMAIN;
using WebScrapper.DOMAIN.DTO;
using WebScrapper.DOMAIN.Models.Helper.TokenHelper;

namespace WebScanner.Controllers;

/// <summary>
/// Controller non authenficated | /
/// </summary>
[ApiController]
[AutoValidateAntiforgeryToken]
[Route("[Controller]")]
public class RootController : UserController
{
    private readonly IUserService _guestService;
    private readonly IConfiguration? _configuration;
    //private readonly IChallengeService? _challengeService;
    //private readonly ITeamService? _teamService;

    private AdministratorController _administratorController;
    private TokenGenerator _tokenGenerator;
    private EncryptionHelper _encryptionHelper;
    private ReturnUserInformationHelper _returnUserInformation;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="userService"></param>
    /// <param name="configuration"></param>
    public RootController(
        IUserService userService,
        IConfiguration configuration
        //IChallengeService? challengeService,
        //ITeamService? teamService
        ) : base(userService, configuration)
    {
        //_challengeService = challengeService;
        _guestService = userService;
        _configuration = configuration;
        //this._teamService = teamService;

        _administratorController = new(
                userService,
                configuration
                );

        _tokenGenerator = new(
            configuration
            );

        _encryptionHelper =
            new(configuration
            );

        _returnUserInformation = new(userService, configuration);
    }

    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <param name="userInformationsForloginDto"></param>
    /// <returns></returns>
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
    [HttpPost("signIn")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[ValidateAntiForgeryToken]
    //[Authorize(Roles = "Guest")]
    public IActionResult SignIn(
        [FromBody]
        LoginDTO userInformationsForloginDto
    )
    {
        try
        {
            Dictionary<string, object> returnInformationsFromUserLoginRequest =
                new();

            UserRequestHeaderInformation collectedUserRequestInformationHeader =
                InformationCollector.ClientHeaderInformationRecolter(
                    HttpContext,
                    Request,
                    out returnInformationsFromUserLoginRequest
                );

            #region TyeFirst_TokenVerification

            User userToConnect_TryFirstByToken = _guestService
                .VerifyUserExist(userInformationsForloginDto.Token);

            if (userToConnect_TryFirstByToken != null)
            {
                if (_guestService
                .VerifyPassword(userToConnect_TryFirstByToken, userInformationsForloginDto))
                {
                    return _returnUserInformation.ReturnLoginOK(
                         _guestService.CreateUserRegisteredLogin(
                            userInformationsForloginDto,
                            collectedUserRequestInformationHeader,
                            userToConnect_TryFirstByToken
                          ),
                         returnInformationsFromUserLoginRequest
                    );
                }
            }

            #endregion

            #region IF Token Verification failed Try Username

            User ifTokenIsInvalidOrDeletedWeValidateTheUserByEmail = _guestService
               .GetUserByUsernName(userInformationsForloginDto.UserName);

            if (ifTokenIsInvalidOrDeletedWeValidateTheUserByEmail != null)
            {
                if (ifTokenIsInvalidOrDeletedWeValidateTheUserByEmail.UserName == userInformationsForloginDto.UserName)
                {
                    if (_guestService
                        .VerifyPassword(userToConnect_TryFirstByToken, userInformationsForloginDto))
                    {
                        return _returnUserInformation.ReturnLoginOK(
                             _guestService.CreateUserRegisteredLogin(
                                userInformationsForloginDto,
                                collectedUserRequestInformationHeader,
                                userToConnect_TryFirstByToken
                              ),
                             returnInformationsFromUserLoginRequest
                        );
                    }
                }
                else
                {
                    return _returnUserInformation.ReturnLoginError(
                        userToConnect_TryFirstByToken,
                        returnInformationsFromUserLoginRequest
                    );
                }
            }

            #endregion

            #region Return an Login Error If All Validation Failed

            return _returnUserInformation.ReturnLoginError(
                userToConnect_TryFirstByToken,
                returnInformationsFromUserLoginRequest
                );

            #endregion
        }
        catch (Exception e)
        {
            ReturnedErrorMessageInfo returnedErrorMessage = new(
                "Not able to login... : ",
                e.Message);

            return StatusCode(500,
                              returnedErrorMessage);
        }
    }

    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <param name="userRegirastingInformationsFromDTO"></param>
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
    [HttpPost("signUp")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[ValidateAntiForgeryToken]
    public IActionResult SignUp(
        [FromBody]
        RegisterationDTO userRegirastingInformationsFromDTO
    )
    {
        try
        {
            Dictionary<string, object> returnInformationsFromUserRegistration = new();

            UserRequestHeaderInformation collectedUserRequestInformationHeader =
                InformationCollector
                .ClientHeaderInformationRecolter(
                    HttpContext,
                    Request,
                    out returnInformationsFromUserRegistration);

            #region TyeFirst_TokenVerification

            User ifTokenIsInvalidOrDeletedWeValidateTheUserByEmail = _guestService
                .GetUserByEmail(userRegirastingInformationsFromDTO.Email);

            if (ifTokenIsInvalidOrDeletedWeValidateTheUserByEmail != null)
            {
                return _returnUserInformation.ReturnUserAlreadyExist(
                       ifTokenIsInvalidOrDeletedWeValidateTheUserByEmail,
                       returnInformationsFromUserRegistration
                    );
            }

            #endregion

            #region TyeFirst_TokenVerification

            User userToConnect_TryFirstByToken = _guestService
                .VerifyUserExist(userRegirastingInformationsFromDTO.Token);

            if (userToConnect_TryFirstByToken != null)
            {
                if (userToConnect_TryFirstByToken.Email == userRegirastingInformationsFromDTO.Email)
                {
                    return _returnUserInformation.ReturnUserAlreadyExist(
                        userToConnect_TryFirstByToken,
                        returnInformationsFromUserRegistration
                     );
                }
                if (userToConnect_TryFirstByToken.UserName == userRegirastingInformationsFromDTO.UserName)
                {
                    return _returnUserInformation.ReturnUserAlreadyExist(
                        userToConnect_TryFirstByToken,
                        returnInformationsFromUserRegistration
                     );
                }
                else
                {
                    return _returnUserInformation.ReturnUserRegisteredOK(
                           userToConnect_TryFirstByToken,
                           userRegirastingInformationsFromDTO,
                           returnInformationsFromUserRegistration,
                           collectedUserRequestInformationHeader
                        );
                }
            }

            #endregion

            returnInformationsFromUserRegistration.Add(
                "ReturnErrorRegistrationMessage",
                "Registration gone wrong...");

            return StatusCode(
                   500,
                   returnInformationsFromUserRegistration);

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
    /// <param name="token"></param>
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
    [HttpGet("handshake")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[ValidateAntiForgeryToken]
    public IActionResult Hello(string token = null)
    {
        try
        {
            Dictionary<string, object> returnInformation = new();
            UserRequestHeaderInformation userRequestInformationHeader = new();
            TokenInfo tokenInfo = new();

            _returnUserInformation.ValidateClientInformation(
                _configuration,
                out tokenInfo,
                token
            );

            userRequestInformationHeader =
                InformationCollector
                .ClientHeaderInformationRecolter(
                    HttpContext,
                    Request,
                    out returnInformation);

            switch (tokenInfo.UniqueName)
            {
                case nameof(Administrator):
                    return _administratorController
                        .LogInFromCookie(tokenInfo);

                case nameof(Guest):
                    return Ok(tokenInfo);

                case null or "":
                    CreateUserGuestModel createUserModel =
                        new CreateUserGuestModel(
                            _configuration,
                            _guestService,
                            userRequestInformationHeader,
                            out returnInformation
                    );

                    return Ok(returnInformation);
            }
            return Ok(returnInformation);
        }
        catch (Exception e)
        {
            ReturnedErrorMessageInfo returnedErrorMessage = new(
                        "Hanskake Encounter an error... : ",
                        e.Message);

            return StatusCode(
                   500,
                   returnedErrorMessage);
        }
    }
}