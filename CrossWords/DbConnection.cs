using System;
using System.Windows;
using System.Data.SqlClient;


namespace CrossWords;

public class DbConnection
{
    //  @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=words;Integrated Security=True";
    private string connection = @"Data Source=myserver.example.com,3306;Initial Catalog=words;User ID=root;Password=1234";

    private string query = "SELECT * FROM words";


    public void DBConnection()
    {
        SqlConnection sqlConnection = new SqlConnection(connection);

        try
        {
            sqlConnection.Open();
            Console.WriteLine("Connection is open");

            SqlCommand command = new SqlCommand(query, sqlConnection);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("Start to Read");
            }

            sqlConnection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Error : " + e);
        }
        finally
        {
            if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        
        
        
    }

}