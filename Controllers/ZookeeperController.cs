using Microsoft.AspNetCore.Mvc;
using ZooManagement;
using ZooManagement.Models.Request;
using ZooManagement.Repositories;
using ZooManagement.Models.Database;
using ZooManagement.Models.Response;
using NLog;
using NLog.Config;
using NLog.Targets;
// using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;



namespace ZooManagement.Controllers
{
    [ApiController]
    [Route("/zookeepers")]

    public class ZookeeperController : ControllerBase
    {
        private readonly IAnimalRepo _animals;
        private readonly IAnimalTypeRepo _animaltypes;

        private readonly IEnclosureRepo _enclosures;

        private readonly IZookeeperRepo _zookeepers;

        // private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
       // private readonly ILogger<AnimalController> _logger;

        // public AnimalController(ILogger<AnimalController> logger)
        // {
        //     _logger = logger;
        //     _logger.LogDebug(1, "NLog injected into AnimalController");
        // }

        public ZookeeperController(IAnimalRepo animals, IAnimalTypeRepo animaltypes, IEnclosureRepo enclosures,IZookeeperRepo zookeepers )
        {
            _animals = animals;
            _animaltypes = animaltypes;
            _enclosures = enclosures;
            _zookeepers = zookeepers;
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CreateZookeeperRequest zookeeper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          var zookeepercreated = _zookeepers.CreateZookeeper(zookeeper);

                if (zookeepercreated == null)
                {
                    return StatusCode(401);
                }
                else
                {
                    return StatusCode(200);
                }
       
        }


        [HttpGet("{id}")]
        public ActionResult<ZookeeperResponse> GetZookeeper([FromRoute] int id)
        {
            return _zookeepers.GetZookeeper(id);
        }


}
}




