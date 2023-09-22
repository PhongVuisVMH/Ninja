using MySql.Data.MySqlClient;
using TMPro;
using UnityEngine;

public class WeaponSet : MonoBehaviour
{
    //private string connectionString = "Server = localhost ; port = 3307 ; Database = ninja_return ; User = root; Password = ; SslMode = none";
    string query;
    public TextMeshProUGUI scoreText;
    public int selectedWeapon;
    public int score;
    //MySqlConnection connection;
    //MySqlCommand command;
    //MySqlDataReader reader;

    public static WeaponSet instance;
    private void Awake()
    {
        /*
        if (instance == null) instance = this;
        else if (instance == this) Destroy(gameObject);
        if (connectionString == null) return;
        */
        selectedWeapon = PlayerPrefs.GetInt("SelectedWeapons", 0);
        if (Connection.instance == null)
        {
            Debug.Log("Dont have connection" + Connection.instance.conn);
        }
        else
        {
            Connection.instance.connection();
            //Debug.Log("=======================" + Connection.instance.conn);
        }
    }
    private void FixedUpdate()
    {
        loadScore();
    }

    public void loadScore()
    {
        /*// Tạo ra một connection mới.
        connection = new MySqlConnection(connectionString);
        // Mở kết nối.
        connection.Open();*/
        query = "SELECT name, price, atk, value.Coins FROM weapons, value";
        // Tạo ra command với query để đọc db
        Connection.instance.command = new MySqlCommand(query, Connection.instance.conn);
        // Đọc dữ liệu tồn tại.
        Connection.instance.reader = Connection.instance.command.ExecuteReader();
        {
            while (Connection.instance.reader.Read())
            {
                score = Connection.instance.reader.GetInt32("Coins");
                scoreText.text = "Coins: " + score;
            }
        }
        Connection.instance.reader.Close();
        Connection.instance.reader.Dispose();
    }

    /*public void Save()
    {
        Weapon.instance.SaveVuKhi();
    }*/
}




