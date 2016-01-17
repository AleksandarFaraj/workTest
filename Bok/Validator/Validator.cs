using Bok.MockDB;
using Bok.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bok.Validator
{
    public class Validator
    {
        public static List<BankEntryDTO> Validate(List<BankEntryDTO> bankEntries, IDataBase db)
        {
            IList<BankEntry> allEntriesInTimeInterval = db.getEntries();

            //a preferable solution would be
            //SortEntriesByDate()
            //GetEntriesInDateInterval()

            //Naive looping
            foreach (BankEntryDTO bankEntryDTO in bankEntries)
            {
                markAsFine(bankEntryDTO);
                markDuplicate(bankEntryDTO, allEntriesInTimeInterval);
            }

            return bankEntries;
        }

        private static void markAsFine(BankEntryDTO bankEntryDTO)
        {
            if (bankEntryDTO.bankEntry == null)
                bankEntryDTO.state = BankEntryDTO.StateEnum.BROKEN;
            else
                bankEntryDTO.state = BankEntryDTO.StateEnum.FINE;
            
        }

        protected static BankEntryDTO markDuplicate(BankEntryDTO bankEntryDTO, IList<BankEntry> allEntries)
        {
            foreach (BankEntry bankEntry in allEntries)
            {
                if (bankEntry.Equals(bankEntryDTO.bankEntry)) //...... This isn't working for some strange reason.
                {
                    bankEntryDTO.state = BankEntryDTO.StateEnum.DUPLICATE;
                };
            }
            return bankEntryDTO;
        }
    }
}