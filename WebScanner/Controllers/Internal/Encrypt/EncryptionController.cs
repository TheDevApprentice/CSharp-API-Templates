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
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [HttpPost("encrypt")]
    [ValidateAntiForgeryToken]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="500">If the item is null</response>
    [HttpPost("decrypt")]
    [ValidateAntiForgeryToken]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
