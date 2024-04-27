using Microsoft.AspNetCore.Mvc;
using WebScrapper.DOMAIN;

namespace WebScanner.Controllers;

/// <summary>
/// 
/// </summary>
[ApiController]
[Route("[Controller]")]
internal class RoleController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IRoleService _roleService;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="roleService"></param>
    /// <param name="configuration"></param>
    public RoleController(
        IRoleService roleService,
        IConfiguration configuration
    )
    {
        _roleService = roleService;
        _configuration = configuration;
    }

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
    /// <response code="500">If the item is null</response>
    [HttpPost("userRoles")]
    [ValidateAntiForgeryToken]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public List<Role> GetUserRoles()
    {
        List<Role> userRoles = _roleService
                                .GetUserRoles();

        return userRoles;
    }
}