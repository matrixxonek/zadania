using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Collections;


public class DBConection 
{
    SQLiteConnection db;
    List<Issues> myIssues;
    public void setConnection()
    {
        SQLiteConnection sqlite_conn;
        // Create a new database connection:
        //sqlite_conn = new SQLiteConnection("Data Source=C:\\Users\\Admin\\Desktop\\test.db");
         // Open the connection:
         try
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "test1.db");
            var options = new SQLiteConnectionString(databasePath, SQLiteOpenFlags.FullMutex | SQLiteOpenFlags.ReadWrite, false);
            db = new SQLiteConnection(options);
            db.CreateTable<Issues>();
            myIssues = getIssues();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public DBConection()
    {
        setConnection();
    }
    public List<Issues> getIssues()
    {
        return db.Query<Issues>("SELECT * FROM Issues");
    }
}
