using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicTypes.Extensions;

namespace BasicTypes.FileProcessing
{
    public class ExcelReader : IDisposable
    {
        private string file;
        private OleDbConnection connection=null;
        private OleDbCommand command = null;
        private OleDbDataReader reader = null;
        public ExcelReader(string file)
        {
            this.file = file;
        }

        public OleDbDataReader GetTable(int tab)
        {
            connection = new OleDbConnection(ExcelReader.DetermineOledBConnectionString(file));

            connection.Open();
            DataTable schema = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

            if (schema == null)
            {
                throw new InvalidOperationException("connection.GetOleDbSchemaTable returned a null table");
            }

            string table = schema.Rows[tab]["TABLE_NAME"].ToString();

            string sql = "SELECT * FROM [" + table + "];";

            command = new OleDbCommand(sql);

            command.Connection = connection;
            reader = command.ExecuteReader();
            if (reader == null)
            {
                throw new InvalidOperationException("Command returned a null reader : " + sql);
            }
            return reader;
        }

        public static string DetermineOledBConnectionString(string fullNameOfExcelFile)
        {
            string connectionString;
            if (IntPtr.Size == 4)
            {
                // 32-bit
                //Excel “External table is not in the expected format.” //Means OLEDB.4.0 can't read that version of Excel.
                //"Provider=Microsoft.Jet.OLEDB.4.0; data source={0}; Extended Properties=Excel 8.0;" //Older versions of Excel
                connectionString =
                    String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;", fullNameOfExcelFile);
            }
            else //(IntPtr.Size == 8)
            {
                // 64-bit
                connectionString =
                    String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 12.0;", fullNameOfExcelFile);
            }

            return connectionString;
        }

        public void Dispose()
        {
            reader.SafeDispose();
            command.SafeDispose();
            connection.SafeDispose();
        }
    }
}
