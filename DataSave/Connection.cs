using MySql.Data.MySqlClient;
using UnityEngine;

public class Connection : MonoBehaviour
{
    public string connectionString = "Server = localhost ; port = 3307 ; Database = ninja_return ; User = root; Password = ; SslMode = none";
    public MySqlConnection conn;
    public static Connection instance;

    public MySqlCommand command;
    public MySqlDataReader reader;

    public void OnEnable()
    {
        if (instance == null) 
        {
            instance = this;
            connection();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void connection()
    {
        try
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Database connection error: " + ex.Message);
        }
    }

    private void OnApplicationQuit()
    {
        if (conn != null && conn.State != System.Data.ConnectionState.Closed)
        {
            conn.Close();
            Debug.Log("Database connection closed!");
        }
    }

}
