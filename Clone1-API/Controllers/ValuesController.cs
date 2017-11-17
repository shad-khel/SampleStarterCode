using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Serilog;

namespace ExampleAPI.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly ILogger _logger;
        public ValuesController(ILogger logger)
        {
            _logger = logger;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            _logger.Verbose("Get called");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            _logger.Verbose($"{id}");
            throw new Exception("custom");
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
