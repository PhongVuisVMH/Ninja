using MySql.Data.MySqlClient;
using TMPro;
using UnityEngine;

public class ScoreLast : MonoBehaviour
{
    private float hightscore;
    public GameObject textPrefab; // Prefab cho text object
    public Transform content; // Content trong ScrollView
    private string connectionString = "Server = localhost ; port = 3307 ; Database = ninja_return ; User = root; Password = ; SslMode = none";

    private void Awake()
    {
        if(connectionString == null)  return;
    }
    private void FixedUpdate()
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
            using (MySqlCommand command = new MySqlCommand("SELECT score FROM player", connection))
            {
                // Đọc dữ liệu tồn tại.
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    // Kiểm tra xem có dữ liệu để đọc không
                    while (reader.Read())
                    {
                        // Đọc giá trị score và tạo text object mới để hiển thị score
                        int score = reader.GetInt32("score");
                        GameObject newText = Instantiate(textPrefab, content);
                        newText.GetComponent<TextMeshProUGUI>().text = "Điểm: " + hightscore;
                    }
                }
            }
        }
    }
}



