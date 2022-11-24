using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace Kanbanboard
{
    public static class DataServices
    {
        public static OleDbConnection DBConnection()
        {
            string projectPath = @"..\..\..\";
            string conString = "Provider = Microsoft.ACE.OLEDB.12.0;" + @"Data Source = " + projectPath + @"\Tietokanta.accdb;";
            OleDbConnection connection = new OleDbConnection(conString);
            connection.Open();
            return connection;
        }
    }
}
