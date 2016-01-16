using System.Collections.Generic;
using Bok.Models;

namespace Bok.BankLogParser.BankParsers
{
    public interface BankParser
    {
        bool identify(string bankLogString);
        IEnumerable<BankEntry> parse(string bankLogString);
    }
}