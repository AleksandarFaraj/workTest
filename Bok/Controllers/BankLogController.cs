using Bok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Bok.BankLogParser;
using Bok.Service;

namespace Bok.Controllers
{
    public class BankLogController : ApiController
    {
        private Parser parser = new Parser();
        private List<BankEntry> bankEntries= new List<BankEntry>();
       
        // POST: api/BankLog
        public List<BankEntryDTO> Post(BankLog bankLog)
        {
            List<BankEntryDTO> bankEntriesDTO = parser.parse(bankLog);
            List<BankEntryDTO> verifiedBankEntriesDTO = Validator.Validator.Validate(bankEntriesDTO, DBService.getDB());

            return verifiedBankEntriesDTO;
        }
     
    }
}
