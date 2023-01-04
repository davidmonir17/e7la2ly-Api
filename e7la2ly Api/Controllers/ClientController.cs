using Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e7la2ly_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private readonly IServiceManager service;

        public ClientController(IServiceManager service)
        {
            this.service = service;
        }
        [HttpGet]
        public IActionResult getClients()
        {
            //throw new Exception("Exception");
            var clients = service.Client.GetAllClients(false);
                return Ok(clients);
           
          

        }
    }
}
