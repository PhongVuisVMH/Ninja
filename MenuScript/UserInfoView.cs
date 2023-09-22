using MySql.Data.MySqlClient;
using System.Collections.Generic;
using UnityEngine;

public class UserInfoView : MonoBehaviour
{
    public GameObject temPlate; // Prefab cho text object
    public GameObject Content; // Content trong ScrollView
    private string connectionString = "Server = localhost ; port = 3307 ; Database = ninja_return ; User = root; Password = ; SslMode = none";
    int rowCount = 0;
    string query;

    private void Awake()
    {
        if (connectionString == null) return;
    }

    /*private void OnEnable()
    {
        if (Connection.instance == null)
        {
            Debug.Log("Dont have connection" + Connection.instance.conn);
            return;
        }
        else
        {
            Connection.instance.connection();
            //Debug.Log("=======================" + Connection.instance.conn);
        }
    }*/

    private void Start()
    {
        loadScore();
    }

    public void loadScore()
    {
        // Tạo ra một List chứa PlayerData.
        List<PlayerData> playerDataList = new List<PlayerData>();
        // Tạo ra một connection mới.
        using (MySqlConnection connection = new MySqlConnection(connectionString) )
        {
            // Mở kết nối.
            connection.Open();
            query = "SELECT level, killcount, score FROM player";
            // Tạo ra command với query để đọc db
            using (MySqlCommand command = new MySqlCommand(query, connection))
            {
                // Đọc dữ liệu tồn tại.
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rowCount++;
                        // Đọc giá trị score và tạo text object mới để hiển thị score
                        int level = reader.GetInt32("level");
                        int kill = reader.GetInt32("killcount");
                        int score = reader.GetInt32("score");

                        PlayerData playerData = new PlayerData();
                        playerData.level = level;
                        playerData.kill = kill;
                        playerData.score = score;
                        playerDataList.Add(playerData);
                    }
                }
            }
            connection.Close();
        }
        // Ấn định lại data cho các template clone từ temPlate
        foreach (PlayerData playerData in playerDataList)
        {
            GameObject gobj = Instantiate(temPlate, Content.transform);
            UserInfo obj = gobj.GetComponent<UserInfo>();
            if (obj == null)
            {
                Destroy(gobj);
                continue;
            }
            obj.Init(rowCount, playerData.level, playerData.score, playerData.kill);
        }

    }
}

//Khai báo dữ biến để lấy dữ liệu từ db
[System.Serializable]
public struct PlayerData
{
    public int level;
    public int score;
    public int kill;
}



