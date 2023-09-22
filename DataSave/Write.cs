using MySql.Data.MySqlClient;
using UnityEngine;

public class Write : MonoBehaviour
{
    public static Write instance;
    private string connectionString;
    private MySqlConnection conn;
    private MySqlCommand MS_Command;
    string query;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else if(instance = this)
        {
            Destroy(gameObject);
        }
        connection();
    }
    public void sendInfo()
    {
        connection();
        query = "INSERT INTO player (level, killcount, score) VALUES ('"+GameManager.Instance.level+"','"+GameManager.Instance.kill+"','"+GameManager.Instance.Scores+"')";
        MS_Command = new MySqlCommand(query, conn);
        MS_Command.ExecuteNonQuery();
        //Debug.Log("gave your info to database!");
        conn.Close();

    }

    public void connection()
    {
       
        connectionString = "Server = localhost ; port = 3307; Database = ninja_return ; User = root; Password = ; SslMode = none;";
        try
        {
            conn = new MySqlConnection(connectionString);
            conn.Open();
            //Debug.Log("Connected to database");
        }
        catch (MySqlException ex)
        {
            Debug.LogError("Database connection error: " + ex.Message);
        }

    }
}
