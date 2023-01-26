using log4net;
using System;
using System.Data.SQLite;

namespace PhoneBookTestApp
{

    public class DatabaseUtil
    {

        private static readonly ILog log = LogManager.GetLogger(typeof(DatabaseUtil));

        
        public static void initializeDatabase()
        {
            var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
            dbConnection.Open();

            try
            {
                executeQuery(dbConnection, "create table PHONEBOOK (NAME varchar(255), PHONENUMBER varchar(255), ADDRESS varchar(255))");
                executeQuery(dbConnection, "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('Chris Johnson','(321) 231-7876', '452 Freeman Drive, Algonac, MI')");
                executeQuery(dbConnection, "INSERT INTO PHONEBOOK (NAME, PHONENUMBER, ADDRESS) VALUES('Dave Williams','(231) 502-1236', '285 Huron St, Port Austin, MI')");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            finally
            {
                dbConnection.Close();
            }
        }

        private static void executeQuery(SQLiteConnection dbConnection, string query)
        {
            SQLiteCommand command = new SQLiteCommand(query, dbConnection);
            command.ExecuteNonQuery();
            
        }

        public static SQLiteConnection GetConnection()
        {
            var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
            dbConnection.Open();

            return dbConnection;
        }

        public static void CleanUp()
        {
            var dbConnection = new SQLiteConnection("Data Source= MyDatabase.sqlite;Version=3;");
            dbConnection.Open();

            try
            {
                SQLiteCommand command =
                    new SQLiteCommand(
                        "drop table PHONEBOOK",
                        dbConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            finally
            {
                dbConnection.Close();
            }
        }
    }
}