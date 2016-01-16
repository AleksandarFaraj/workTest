using Bok.BankLogParser.BankParsers;
using Bok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bok.BankLogParser
{
    public class Parser
    {
        private List<BankParser> bankParsers;
        public Parser()
        {
            bankParsers = new List<BankParser>();
            bankParsers.Add(new SEBParser());
            bankParsers.Add(new HandelsbankenParser());
        }
       
        public IEnumerable<BankEntry> parse(BankLog bankLog) {
            BankParser bankParser = identifyBank(bankLog.BankLogString);
            return bankParser.parse(bankLog.BankLogString);
        }

        protected BankParser identifyBank(string bankLogString)
        {   
            foreach(BankParser bankParser in bankParsers)
            {
                if (bankParser.identify(bankLogString)) { return bankParser; };
            }
            throw new NotImplementedException();
        }
    }
}