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

        public List<BankEntryDTO> parse(string bankLogString)
        {
            string lastLineBeforeTransactions = "Saldo";
            var lines = bankLogString.Split("\n".ToCharArray());
            int indexOfLastLineBeforeTransactions = Array.IndexOf(lines, lastLineBeforeTransactions);

            //compensate for empty line
            indexOfLastLineBeforeTransactions += 2;

            return parseLines(lines, indexOfLastLineBeforeTransactions);
        }
        public List<BankEntryDTO> parseLines(string[] lines, int start)
        {
            List<BankEntryDTO> bankEntries = new List<BankEntryDTO>();
            for (int i = start; !lines[i].Equals(""); i++)
            {
                string line =  lines[i];
                BankEntry bankEntry = parseLine(lines[i]);
                bankEntries.Add(new BankEntryDTO(BankEntryDTO.StateEnum.UNVERIFIED,bankEntry,line));
            }
            return bankEntries;
        }
        public BankEntry parseLine(string line) 
        {
            try
            {
                string[] columns = line.Split("\t".ToArray());

                //quick fix
                int ignoreSend = 0;
                if (columns.Length > 6)
                {
                    ignoreSend = 1;
                };

                DateTime dateTime = parseTransactionDate(columns[0 + ignoreSend]);
                string account = columns[3 + ignoreSend].Trim();
                string change = columns[4 + ignoreSend].Trim();
                string balance = columns[5 + ignoreSend].Trim();

                return new BankEntry(dateTime, account, change, balance);

            } catch (Exception)
            {
                return null;
            }
        }
        public double parseNumber(string value)
        {
            //I tried making the values into doubles but couldn't figure out how in a timely fashion.
            CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("fr-FR");
            NumberStyles numberStyles = NumberStyles.Number ;
            return Double.Parse(value, cultureInfo);
        }
        protected DateTime parseTransactionDate(string date)
        {
                CultureInfo provider = CultureInfo.InvariantCulture;
                string dateFormat = "yyyy-MM-dd";
            return DateTime.ParseExact(date, dateFormat, provider);
        }
    }
}