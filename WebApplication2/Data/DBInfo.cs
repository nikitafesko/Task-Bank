
using SQLite;
using System.Data.SQLite;
using System.Transactions;

namespace WebApplication2.Data
{
    public class DBInfo
    {
        public void CreateDb()
        {
            using (TransactionScope tran = new TransactionScope())
            {
                //SQLiteConnection.CreateFile("db.sqlite");

                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=db.sqlite;Version=3;");
                m_dbConnection.Open();

                string sql = "create table currencies(Id int, Code int,Abbreviation string,Name string, QuotName)";
                //string sql = "create table currencies_ondate ";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();


                command = new SQLiteCommand(sql, m_dbConnection);
                command.ExecuteNonQuery();

                m_dbConnection.Close();
                tran.Complete();
            }
        }
    }
}

