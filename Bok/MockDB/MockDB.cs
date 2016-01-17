using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bok.Models;

namespace Bok.MockDB
{
    public class MockDB : IDataBase
    {
        private List<BankEntry> entryList;

        public MockDB()
        {
            this.entryList = new List<BankEntry>();
        }
      
        public void addEntry(BankEntry bankEntry)
        {
            entryList.Add(bankEntry);
        }

        public IList<BankEntry> getEntries()
        {
            return entryList.AsReadOnly();
        }
    }
}