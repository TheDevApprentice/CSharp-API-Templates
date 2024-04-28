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
    [HttpPost("userRoles")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public List<Role> GetUserRoles()
    {
        List<Role> userRoles = _roleService
                                .GetUserRoles();

        return userRoles;
    }
}