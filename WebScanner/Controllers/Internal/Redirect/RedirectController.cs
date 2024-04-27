using Microsoft.AspNetCore.Mvc;
namespace WebScanner.Controllers;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("[Controller]")]
internal class RedirectController : ControllerBase
{
    /// <summary>
    /// 
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
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    [HttpGet("redirect-url")]
    [ValidateAntiForgeryToken]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult RedirectUrl()
    {
        return Redirect("http://google.com");
    }

    /// <summary>
    /// Creates a TodoItem.
    /// </summary>
    /// <param name="ipAddress"></param>
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
    [HttpGet("redirect-ip")]
    [ValidateAntiForgeryToken]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult RedirectIP(string ipAddress)
    {
        return Redirect($"http://{ipAddress}");
    }
}
