using Microsoft.AspNetCore.Mvc;
using WebScrapper.DOMAIN;

namespace WebScanner.Controllers;
/// <summary>
/// 
/// </summary>
[ApiController]
[Route("[Controller]")]
internal class EncryptionController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly EncryptionHelper _encryptionHelper;
    /// <summary>
    /// 
    /// </summary>
    /// <param name="configuration"></param>
    public EncryptionController(IConfiguration configuration)
    {
        _configuration = configuration;
        _encryptionHelper = new(_configuration);
    }
    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <param name="plainText"></param>
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
    [HttpPost("encrypt")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Encrypt(string plainText)
    {
        try
        {
            string encryptedText = _encryptionHelper
                                    .HashPassword(plainText);

            return Ok(encryptedText);
        }
        catch (Exception ex)
        {
            return StatusCode(
                    500,
                    new ReturnedErrorMessageInfo(
                        "The Encryption encountered an error... : ",
                        ex.Message));
        }
    }
    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <param name="cipherText"></param>
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
    [HttpPost("decrypt")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Decrypt(string cipherText)
    {
        try
        {
            string decryptedText = _encryptionHelper
                                   .Verify(cipherText);

            return Ok(decryptedText);
        }
        catch (Exception ex)
        {
            return StatusCode(
                500,
                new ReturnedErrorMessageInfo(
                    "The Decryption encountered an error... : ",
                    ex.Message));
        }
    }
}
