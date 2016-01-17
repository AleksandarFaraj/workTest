using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bok.Controllers;
using Bok.Models;
using Bok.BankLogParser.BankParsers;

namespace Bok.BankLogParser.BankParsers
{
    [TestClass]
    public class BankLogTest
    {

        [TestMethod]
        public void TestMethod1()
        {
            string goodString = "Skicka	2015-11-30	2015-11-29	676467	Pension 	-107,00 	457.936,33";
            SEBParser seb = new SEBParser();

            seb.parseNumber("457.936,33");

            
        }
    }
}
