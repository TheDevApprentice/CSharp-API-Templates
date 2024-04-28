using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace WebScanner.Controllers;
/// <summary>
/// 
/// </summary>
[Route("[Controller]")]
[AutoValidateAntiforgeryToken]
[ApiController]
public class VersionController : ControllerBase
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="configuration"></param>
    public VersionController(IConfiguration configuration)
    {
        _configuration = configuration;
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
    /// 
    [HttpGet("getversion")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    //[ValidateAntiForgeryToken]
    public string GetVersion()
    {
        return Assembly.GetEntryAssembly().GetName().Version.ToString();
    }
}