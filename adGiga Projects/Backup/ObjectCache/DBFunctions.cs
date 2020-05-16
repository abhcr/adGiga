using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;
using System.Data.Common;

namespace ObjectCache
{
    public class DBFunctions
    {
        private DBFunctions()
        {

        }
        static DBFunctions instance = new DBFunctions();
        public static DBFunctions GetInstance()
        {
            return instance;
        }
        private OleDbConnection connection;

        public void OpenConnection()
        {
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
        }
        public void CloseConnection()
        {
            if (connection.State != System.Data.ConnectionState.Closed)
            {
                connection.Close();
            }
        }
        private OleDbCommand command;
        public OleDbCommand GetCommand(string commandText)
        {
            if (reader != null)
            {
                reader.Close();
                reader.Dispose();
            }
            command.Parameters.Clear();
            command.CommandText = commandText;
            return command;
        }
        private OleDbDataReader reader;
        public OleDbDataReader GetReader(string commandText)
        {
            command.CommandText = commandText;
            return this.GetReader(command);
        }
        public OleDbDataReader GetReader(OleDbCommand command)
        {
            if (reader != null)
            {
                if (!reader.IsClosed)
                {
                    reader.Close();
                }
            }
            if (connection.State != System.Data.ConnectionState.Open)
            {
                connection.Open();
            }
            reader = command.ExecuteReader();
            return reader;
        }

        public void EndDbAction()
        {
            if (reader != null)
            {
                if (!reader.IsClosed)
                {
                    reader.Close();
                }
                reader.Dispose();
            }
            if (command != null)
            {
                command.Dispose();
            }
            if (connection != null)
            {
                if (connection.State != System.Data.ConnectionState.Closed)
                {
                    connection.Close();
                }
                connection.Dispose();
            }
        }
        OleDbTransaction dataTransaction;
        public void BeginBatchOperation()
        {
            OpenConnection();

            dataTransaction = connection.BeginTransaction();
            command.Transaction = dataTransaction;
        }
        public void CommitBatchOperation()
        {
            if (dataTransaction != null)
            {
                dataTransaction.Commit();
                dataTransaction.Dispose();
            }
        }
        public void RollBackBatchOperation()
        {
            if (dataTransaction != null)
            {
                dataTransaction.Rollback();
            }
        }
        private List<string> GetAllTableNames()
        {
            List<string> tableNames = new List<string>();
            OpenConnection();
            object[] objArrRestrict;
            //select just TABLE in the Object array of restrictions.
            //Remove TABLE and insert Null to see tables, views, and other objects.
            objArrRestrict = new object[] { null, null, null, "TABLE" };
            DataTable schemaTbl = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, objArrRestrict);
            // Display the table name from each row in the schema
            foreach (DataRow row in schemaTbl.Rows)
            {
                tableNames.Add(row["TABLE_NAME"].ToString());
            }
            return tableNames;
        }
        /// <summary>
        /// Check if DB contains all the required tables, fields
        /// </summary>
        /// <returns></returns>
        public bool IsDataFileValid()
        {
            return true; //TODO: check thoroughly every  table and fields is present
        }

        public void SetConnectionString(string dataLocationFullPath)
        {
            if (connection != null)
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose();
            }
            connection = new OleDbConnection(string.Format(
                "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Persist Security Info=False;Jet OLEDB:Database Password=prjr8oZv32iul0", dataLocationFullPath));
            command = new OleDbCommand();
            command.Connection = connection;
            connection.Open();
        }

        internal bool CheckIfColumnExistsInTable(string columnName, string tableName)
        {
            OpenConnection();

            DataSet dTable = new DataSet();

            // Get the table definition loaded in a table adapter
            string strSql = "Select TOP 1 * from " + tableName;
            DataAdapter dbAdapater = new OleDbDataAdapter(strSql, connection);
            dbAdapater.Fill(dTable);

            // Get the index of the field name
            //Dim i As Integer = 
            if (dTable.Tables[0].Columns.IndexOf(columnName) == -1)
            {
                //field is missing
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

