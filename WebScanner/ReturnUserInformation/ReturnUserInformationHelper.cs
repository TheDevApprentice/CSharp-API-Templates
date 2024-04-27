using Microsoft.AspNetCore.Mvc;
using WebScrapper.DOMAIN;

namespace WebScanner.ReturnUserInformation;

public class ReturnUserInformationHelper : ControllerBase
{
    private IUserService _guestService;
    private IConfiguration _configuration;

    public ReturnUserInformationHelper(IUserService guestService, IConfiguration configuration)
    {
        _guestService = guestService;
        _configuration = configuration;
    }

    public IActionResult ReturnUserRegisteredOK(
       User newUser,
       RegisterationDTO registrationDTO,
       Dictionary<string, object> returnInformation,
       UserRequestHeaderInformation userRequestInformationHeader
    )
    {
        User veryfyGuestExist = null;

        if (!string
            .IsNullOrEmpty(registrationDTO.Token)
        )
        {
            veryfyGuestExist = _guestService
                .VerifyUserExist(registrationDTO.Token);
        }

        if (veryfyGuestExist != null)
        {
            veryfyGuestExist = _guestService
              .CreateUserRegistered(registrationDTO, userRequestInformationHeader);

            newUser = _guestService
                .ModifyUser(veryfyGuestExist);
        }

        ReturnedUserNotConnectedRegistrationOk returnMesage =
            new(newUser);

        returnInformation.Add(
                    "ReturnSucessRegistrationMessage",
                    "Registrated sucessfully");

        returnInformation.Add(
                    "NewUser",
                    newUser);

        returnInformation.Add(
                    "returnMesage",
                    returnMesage);

        return Ok(returnInformation);
    }

    public IActionResult ReturnUserAlreadyExist(
        User newUser,
        Dictionary<string, object> returnInformation
    )
    {
        ReturnedUserNotConnectedRegistrationUserAlreadyExist returnMesage =
            new(newUser);

        returnInformation.Add(
                    "ReturnUserAlreadyExistRegistrationMessage",
                    "User already exist");

        returnInformation.Add(
                    "user",
                    newUser);

        returnInformation.Add(
                    "returnMesage",
                    returnMesage);

        return Ok(returnInformation);
    }

    public void ValidateClientInformation(
        IConfiguration configuration,
        out TokenInfo tokenInfo,
        string token
    )
    {
        tokenInfo = TokenVerify
            .ValidateTokenValidity(
                    configuration,
                    token);
    }

    public IActionResult ReturnLoginError(
     User userToLogin,
     Dictionary<string, object> returnInformation
   )
    {
        ReturnedUserNotConnectedLoginNotOk returnMesageLoginError
            = new(userToLogin);

        returnInformation.Add(
            "ReturnFailedloginMessage",
            "error");

        returnInformation.Add(
            "returnMesage",
            returnMesageLoginError);

        return Ok(returnInformation);
    }

    public IActionResult ReturnLoginOK(
        User veryfyGuestExist,
        Dictionary<string, object> returnInformation
    )
    {
        ReturnedUserConnectedLoginOk returnMesageLoginOk = new(
            veryfyGuestExist,
            _configuration);

        veryfyGuestExist.Token = returnMesageLoginOk.Token;

        veryfyGuestExist = _guestService
            .ModifyUser(veryfyGuestExist);

        returnInformation.Add(
            "ReturnSucessloginMessage",
            "logged sucessfully");

        returnInformation.Add(
            "UserConnected",
            returnMesageLoginOk);

        returnInformation.Add(
            "veryfyGuestExist",
            veryfyGuestExist);

        return Ok(returnInformation);
    }

    public IActionResult ReturnLoginNotOK(
        User userToLogin,
        Dictionary<string, object> returnInformation
    )
    {
        ReturnedUserNotConnectedLoginNotOk returnMesageLoginError
            = new(userToLogin);

        returnInformation.Add(
            "ReturnFailedloginMessage",
            "User not connected login not ok");

        returnInformation.Add(
            "returnMesage",
            returnMesageLoginError);

        return BadRequest(returnInformation);
    }
}
