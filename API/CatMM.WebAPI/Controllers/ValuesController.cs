using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CatMM.WebAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        [HttpPut]
        // PUT api/values/5
        public void Update(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
