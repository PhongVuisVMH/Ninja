using MySql.Data.MySqlClient;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveScene_Level : MonoBehaviour
{
    public static SaveScene_Level instance;
    public int currentLevel;
    public string currentUserName;
    string query;
    public int indexScene;
    private string connectionString = "Server = localhost ; port = 3307 ; Database = ninja_return ; User = root; Password = ; SslMode = none";
    //static bool isCheck = false;

    private void OnEnable()
    {
        CheckInfor();
        Debug.Log("update button ================ lần 1");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        if (connectionString == null) return;
        indexScene = PlayerPrefs.GetInt("SavedScene", 0); //Chỉ khi bấm tiếp tục
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Menu") // Thay "Scene1" bằng tên của Scene 1 trong Build Settings
        {
            CheckInfor();
            Debug.Log("update button ================ lần 2");
        }
    }

    /*void Update()
    {
        if (CheckUserName.instance.btnChoiTiep.activeSelf == false && currentUserName != "" && indexScene > 0)
        {
            CheckUserName.instance.btnChoiTiep.SetActive(true);
            Debug.Log("run");
        }
    }*/
    public void CheckInfor()
    {
        MySqlConnection connection = new MySqlConnection(connectionString);
        // Open the connection
        connection.Open();
        MySqlCommand command;
        MySqlDataReader reader;
        query = "SELECT username FROM userinfo";
        command = new MySqlCommand(query, connection);
        reader = command.ExecuteReader();
        while (reader.Read())
        {
            currentUserName = reader.GetString("username");
            if (currentUserName != " " && indexScene > 0)
            {
                //Debug.Log(indexScene);
                CheckUserName.instance.btnChoiTiep.SetActive(true);
            }
            else return;
        }
        connection.Close();
    }

    public void addName()
    {
        MySqlConnection connection = new MySqlConnection(Connection.instance.connectionString);
        // Open the connection
        connection.Open();
        MySqlCommand command1;
        currentUserName = Chucnang.instance.username.text;
        if (currentUserName == "") query = "INSERT INTO userinfo(username) VALUES ('" + currentUserName + "')";
        else query = "UPDATE userinfo SET username = '" + currentUserName + "'";
        command1 = new MySqlCommand(query, connection);
        command1.ExecuteNonQuery();
        connection.Close();
    }
}
