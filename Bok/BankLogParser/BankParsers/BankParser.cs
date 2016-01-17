using System.Collections.Generic;
using Bok.Models;

namespace Bok.BankLogParser.BankParsers
{
    public interface BankParser
    {
        bool identify(string bankLogString);
        List<BankEntryDTO> parse(string bankLogString);
    }
}