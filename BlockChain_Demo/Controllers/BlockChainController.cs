using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlockChain_Demo.Models;
using Microsoft.AspNetCore.Cors;

namespace BlockChain_Demo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlockChainController : ControllerBase
    {
        //private Random _rand = new Random();
        private readonly ILogger<BlockChainController> _logger;

        public BlockChainController(ILogger<BlockChainController> logger)
        {
            _logger = logger;
        }

        [HttpGet]

        public IEnumerable<DataForDisplay> Get()
        {
            //IEnumerable<DataForDisplay> BlockChainData = new DataForDisplay[0]
            DataForDisplay helper = new DataForDisplay();
            return Enumerable.Range(0, 10).Select(i => new DataForDisplay
            {
                //context.getRandom()
                NumOfUsers = i + 2,
                BlockHeight = 1,
                //MerklePath = _rand.Next(i),
                MerklePath = helper.getRandom(),
                BlockName = i==0 ? "Genesis Block" : String.Format("Block {0}", i),

                index = i, // nodes id
                Fx = helper.getRandom(0, 500), //position
                Fy = helper.getRandom(0, 500), //position
                EdgeSource = i, //link source
                //EdgeSource = helper.getRandom(0, 10), //link source
                EdgeTarget = helper.getRandom(0, 10) // link target

            }).ToArray();
        }
    }
}
