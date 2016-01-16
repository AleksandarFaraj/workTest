using Bok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bok.BankLogParser;
namespace Bok.Controllers
{
    public class BankLogController : ApiController
    {
        private Parser parser = new Parser();
        private List<BankEntry> bankEntries= new List<BankEntry>();
        // GET: api/BankLog
        public IEnumerable<BankEntry> Get()
        {
            return bankEntries;
        }

        // GET: api/BankLog/5
        public BankEntry Get(int id)
        {
            return bankEntries[id];
        }

        // POST: api/BankLog
        public IEnumerable<BankEntry> Post(BankLog bankLog)
        {
            return parser.parse(bankLog);
        }

        // PUT: api/BankLog/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BankLog/5
        public void Delete(int id)
        {
            bankEntries.RemoveAt(id);
        }
    }
}
