using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdFenix.InfrastructureNetCore;
using AdFenix.RabbitmqNetCore;
using Microsoft.AspNetCore.Mvc;

namespace PublicationService.Controllers
{
    [Route("api/po")]
    public class PublicationOwner : Controller
    {
        private IRabbitmqProducerService rabbitmqProducerService;

        public PublicationOwner(IRabbitmqProducerService rabbitmqProducerService)
        {
            this.rabbitmqProducerService = rabbitmqProducerService;
        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult Get()
        {
            
            return Ok("PublicationOwner listing page:");
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpGet("add")]
        public ActionResult Add()
        {
            var publisherCommmand = new AddPublicationOwnerCommand()
            {
                Name = "Test Name " + new Random().Next(100),
                HostUrl = "test.com"
            };

            this.rabbitmqProducerService.SetExchange(RabbitmqConfig.ExchangeBasicEvent, RabbitmqExchangeType.Direct);
            this.rabbitmqProducerService.BasicPublish(RabbitmqConfig.ExchangeBasicEvent, publisherCommmand, RabbitmqConfig.RoutingKeyBasicEventAddPublisher);

            return Ok(publisherCommmand);

        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
