using Microsoft.AspNetCore.Mvc;

namespace AnimeList.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("/version")]
    public string GetVersion()
    {
        return "1.0.0";
    }
}
