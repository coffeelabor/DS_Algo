using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockChain_Demo.Models;

namespace BlockChain_Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlockChainController : ControllerBase
    {
        private readonly ILogger<BlockChainController> _logger;

        public BlockChainController(ILogger<BlockChainController> logger)
        {
            _logger = logger;
        }

        [HttpGet]

        public IEnumerable<DataForDisplay> Get()
        {
            return Enumerable.Range(1, 5).Select(i => new DataForDisplay
            {
                TestInt = i + 2,
                BlockHeight = i,
                BlockName = String.Format("Block {0}", i)
            }).ToArray();
        }
    }
}
