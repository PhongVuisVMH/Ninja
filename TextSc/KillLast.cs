using MySql.Data.MySqlClient;
using TMPro;
using UnityEngine;

public class KillLast : MonoBehaviour
{
    TextMeshProUGUI lastscore;
    private float hightscore;
    private string connectionString = "Server = localhost ; port = 3307 ; Database = ninja_return ; User = root; Password = ; SslMode = none";

    private void Awake()
    {
        lastscore = GetComponent<TextMeshProUGUI>();
       
    }

    private void Update()
    {
        loadScore();
    }
    public void loadScore()
    {
        // Tạo ra một connection mới.
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            // Mở kết nối.
            connection.Open();

            // Tạo ra command với query bạn cần.
            using (MySqlCommand command = new MySqlCommand("SELECT killcount FROM player", connection))
            {
                // Đọc dữ liệu tồn tại.
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Kiểm tra xem có dữ liệu để đọc không
                    if (reader.Read())
                    {
                        // Đọc giá trị score và cập nhật cho player.
                        hightscore = reader.GetInt32("killcount");
                    }
                }
            }
        }
        lastscore.text = "Kill: " + hightscore;
        
    }
}



