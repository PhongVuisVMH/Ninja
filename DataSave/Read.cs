using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.UI;


public class Read : MonoBehaviour
{
    private string connectionString;
    string query;
    private MySqlConnection MS_Connection;
    private MySqlCommand MS_Command;
    private MySqlDataReader MS_Reader;
    public Text textCanvas;

    public void viewInfo()
    {

        query = "SELECT * FROM player";

        connectionString = "Server = localhost ; Database = ninja_return ; User = root; Password = ; SslMode = none;";

        MS_Connection = new MySqlConnection(connectionString);
        MS_Connection.Open();

        if(MS_Command != null)
        {
            //Debug.Log("no data in your sql!");
            return;
        }
        MS_Command = new MySqlCommand(query, MS_Connection);

        MS_Reader = MS_Command.ExecuteReader();
        while (MS_Reader.Read())
        {
            textCanvas.text += "\n              " + MS_Reader[0] + "                            " + MS_Reader[1] + "                     " + MS_Reader[2] /*+ "                    " + MS_Reader[3]*/;
        }
        MS_Reader.Close();

    }
}
