using System;
using System.Collections.Generic;
using Bok.BankLogParser.BankParsers;
using Bok.Models;

namespace Bok.BankLogParser
{
    public class HandelsbankenParser : BankParser
    {
        public bool identify(string bankLogString)
        {
            return false;
        }

        public List<BankEntryDTO> parse(string bankLogString)
        {
            throw new NotImplementedException();
        }
    }
}