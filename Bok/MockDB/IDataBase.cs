using Bok.Models;
using System.Collections.Generic;

namespace Bok.MockDB
{
    public interface IDataBase
    {
        void addEntry(BankEntry bankEntry);
        IList<BankEntry> getEntries();
    }
}