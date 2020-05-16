using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace Business
{
    public class DBFunctions
    {

        public void EndDbAction(OleDbDataReader reader)
        {
            ObjectCache.DBFunctions.GetInstance().EndDbAction();
        }
    }
}
