using Microsoft.AspNetCore.Mvc;

namespace ProductApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
    }
}
