using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bok.Controllers
{
    public class BankLogController : ApiController
    {
        public class BankLogDTO
        {
            public String BankLog { get; set; }
        }
        // GET: api/BankLog
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/BankLog/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/BankLog
        public BankLogDTO Post(BankLogDTO bankLogDTO)
        {
            return bankLogDTO;
        }

        // PUT: api/BankLog/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BankLog/5
        public void Delete(int id)
        {
        }
    }
}
