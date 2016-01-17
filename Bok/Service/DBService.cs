using Bok.MockDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bok.Service
{
    public class DBService
    {
        private static IDataBase db = new MockDB.MockDB();
        public static IDataBase getDB() { return db; }
    }
}