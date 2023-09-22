using MySql.Data.MySqlClient;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
    public LoadManager load;
    public TextMeshProUGUI ScoreTXT;
    public TextMeshProUGUI KillTXT;
    public TextMeshProUGUI UserName;

    //public string Username;
    string currentUserName;
    public float Scores = 0;
    public int kill = 0;
    public int level = 0;
    public int currentScene;
    string query;
    public Sprite[] avatarPreFabs;
    public Image avatarOld;

    AudioManager audioManager;

    public static Vector2 lastCheckPointPos =new Vector2(-71, 3);
    public GameObject[] playerPreFabs;
    int characterIndex;

    public GameObject GameoverPanel;

    public void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance == this) Destroy(gameObject);

        //Lay ra anh cua avatar
        int indexAvatar = PlayerPrefs.GetInt("SavedAvatar", 0);
        avatarOld.sprite = avatarPreFabs[indexAvatar];

        //Lay ra nhan vat
        characterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        Instantiate(playerPreFabs[characterIndex], lastCheckPointPos, Quaternion.identity);
        showInfor();
    }

    private void Start()
    {
        /*if(SaveScene_Level.instance.currentUserName != "")
        {
            Debug.Log(SaveScene_Level.instance.currentUserName);
        }
        else
        {
            Debug.Log("No khonog lay duoc qua dya roi");
        }*/
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
    }

    public void Scored()
    {
        ScoreTXT.text = "Coins: " + Scores.ToString();
    }
    public void Killed()
    {
        KillTXT.text = "Killed monster: " + kill.ToString();
    }

    public void showInfor()
    {
        /*
        MySqlConnection connection = new MySqlConnection(Connection.instance.connectionString);
        // Open the connection
        connection.Open();
        query = "SELECT username FROM userinfo";
        command = new MySqlCommand(query, connection);
        reader = command.ExecuteReader();
        while(reader.Read())
        {
            currentUserName = reader.GetString("username");
            UserName.text = currentUserName.ToString();
        }
        reader.Close();
        //Close the connection
        connection.Close();*/
        UserName.text = SaveScene_Level.instance.currentUserName;
    }

    public void AddCoin()
    {
        MySqlConnection connection = new MySqlConnection(Connection.instance.connectionString);
        // Open the connection
        connection.Open();
        MySqlCommand command;
        //Save data
        query = "INSERT INTO player (killcount) VALUES ( '"+Scores+"')";
        command = new MySqlCommand(query,connection);
        command.ExecuteNonQuery();
        connection.Close();
    }
    //-----------------------------------------------
    
    public void addKill()
    {
        MySqlConnection connection = new MySqlConnection(Connection.instance.connectionString);
        // Open the connection
        connection.Open();
        MySqlCommand command;
        query = "INSERT INTO player(killcount) VALUES( '" + kill + "' )";
        command = new MySqlCommand(query);
        command.ExecuteNonQuery();
        connection.Close();
    }

    public void addLevel()
    {
        MySqlConnection connection = new MySqlConnection(Connection.instance.connectionString);
        // Open the connection
        connection.Open();
        MySqlCommand command1;
        currentScene = SceneManager.GetActiveScene().buildIndex;
        level = currentScene - 2;
        //Debug.Log(level);
        PlayerPrefs.SetInt("SavedScene", currentScene);
        query = "INSERT INTO player(level) VALUES ('"+level+"')";
        command1 = new MySqlCommand(query, connection);
        command1.ExecuteNonQuery();

        // Close the connection
        connection.Close();
    }

    public void ExitToSave()
    {
        addLevel();
        if (Write.instance == null) return;
        else Write.instance.sendInfo();
    }

    public void Death()
    {
        addLevel();
        if (Write.instance == null) return;
        else Write.instance.sendInfo();
        GameoverPanel.SetActive(true);
        audioManager.PlayAudioClip(audioManager.GameOver);
        Time.timeScale = 1f;
    }

}
