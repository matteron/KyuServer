using KyuApi.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KyuApi.Controllers.Abstract
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class CustomController : ControllerBase
    {
        
    }
}