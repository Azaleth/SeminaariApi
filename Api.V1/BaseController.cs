using Api.Entities.ModelValidators;
using LogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace Api.V1
{
    [ApiController]
    [Route("api/[controller]")]
    [ValidationFilter]
    public class BaseController : Controller
    {
        protected const int DEFAULT_SKIP = 0;
        protected const int DEFAULT_TAKE = 20;
        protected HandlerFactory HandlerFactory => new HandlerFactory();    
    }
}
