using Microsoft.AspNetCore.Mvc;
using QueueDemo.Core;
using QueueDemo.Model.Dto;

namespace QueueDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RSAController : ControllerBase
    {
        [HttpPost("generate-key-pair")]
        public GenerateResponse GenerateKeyPair()
        {
            RSAProcessing.GenerateKeys(out string publicKey, out string pricateKey);
            return new GenerateResponse(publicKey, pricateKey);
        }
    }
}
