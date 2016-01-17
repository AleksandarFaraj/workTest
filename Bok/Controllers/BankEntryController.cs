using Bok.Models;
using Bok.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Bok.Controllers
{
    public class BankEntryController : ApiController
    {
        // GET: api/BankEntry
        public IEnumerable<BankEntry> Get()
        {
            return DBService.getDB().getEntries();
        }



        // POST: api/BankEntry
        public List<BankEntryDTO> Post(List<BankEntryDTO> entries)
        {
            foreach (BankEntryDTO bankEntryDTO in entries)
            {
                DBService.getDB().addEntry(bankEntryDTO.bankEntry);
            }
            return entries;
        }

    }
}
