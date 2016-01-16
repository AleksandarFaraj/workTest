using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bok.Models;
using System.Globalization;

namespace Bok.BankLogParser.BankParsers
{
    public class SEBParser : BankParser
    {
        
        public bool identify(String bankLogString) { return bankLogString.Contains("Betala & överföra\nKonto & kort"); }

        public IEnumerable<BankEntry> parse(string bankLogString)
        {
            string lastLineBeforeTransactions = "Saldo";
            var lines = bankLogString.Split("\n".ToCharArray());
            int indexOfLastLineBeforeTransactions = Array.IndexOf(lines, lastLineBeforeTransactions);

            //compensate for empty line
            indexOfLastLineBeforeTransactions += 2;

            return parseLines(lines, indexOfLastLineBeforeTransactions);
        }
        public IEnumerable<BankEntry> parseLines(string[] lines, int start)
        {
            List<BankEntry> bankEntries = new List<BankEntry>();
            for (int i = start; !lines[i].Equals(""); i++)
            {

                bankEntries.Add(parseLine(lines[i]));
            }
            return bankEntries;
        }
        protected BankEntry parseLine(string line)
        {
            CultureInfo provider = CultureInfo.InvariantCulture;
            string[] columns = line.Split("\t".ToArray());
            string dateFormat = "yyyy-MM-dd";
            int ignoreSend = 0;
            if (columns.Length>6) {
              ignoreSend = 1;
            };

            DateTime dateTime = DateTime.ParseExact(columns[0+ignoreSend],dateFormat,provider); ;
            string account = columns[3 + ignoreSend];
            string change = columns[4 + ignoreSend];
            string balance = columns[5 + ignoreSend];
            return new BankEntry(dateTime,account,change,balance);
        }
    }
}