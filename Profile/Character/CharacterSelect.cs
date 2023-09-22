using UnityEngine;
using UnityEngine.UI;
using TMPro;
using MySql.Data.MySqlClient;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] skins;
    public int selectedCharacter;
    public Character[] characters; 

    public Button unlockButton;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI coinsText;
    int coins;
    public GameObject Notification;
    //MySqlCommand command;
   // MySqlDataReader reader;
    //MySqlConnection connection;
    //private string connectionString = "Server = localhost ; port = 3307 ; Database = ninja_return ; User = root; Password = ; SslMode = none";

    AudioManager audioManager;

    private void OnEnable()
    {
        if (Connection.instance == null)
        {
            //Debug.Log("Dont have connection" + Connection.instance.conn);
            return;
        }
        else
        {
            Connection.instance.connection();
            //Debug.Log("=======================" + Connection.instance.conn);
        }
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        Notification = GetComponent<GameObject>();
        selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject player in skins)
            player.SetActive(false);

        skins[selectedCharacter].SetActive(true);

        foreach (Character c in characters)
        {
            if (c.price == 0)
                c.isUnlocked = true;
            else
            {
                c.isUnlocked = PlayerPrefs.GetInt(c.name, 0) == 0 ? false : true;
            }
        }
        UpdateUI();
    }
    private void FixedUpdate()
    {
        loadScore();
        //CloseConnection();

    }
    public void loadScore()
    {
        /*connection = new MySqlConnection(connectionString);
        connection.Open();
        if (connection == null) return;*/
        string query = "SELECT Coins FROM value";
        // Tạo ra command với query để đọc db
        using (Connection.instance.command = new MySqlCommand(query, Connection.instance.conn))
        {
            // Đọc dữ liệu tồn tại.
            using (Connection.instance.reader = Connection.instance.command.ExecuteReader())
            {
                while (Connection.instance.reader.Read())
                {
                    // Đọc giá trị Coins 
                    coins = Connection.instance.reader.GetInt32("Coins");
                }
            }
        }
    }

    public void ChangeNext()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        skins[selectedCharacter].SetActive(false);
        selectedCharacter++;
        if (selectedCharacter == skins.Length)
            selectedCharacter = 0;

        skins[selectedCharacter].SetActive(true);
        if (characters[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);

        UpdateUI();
    }

    public void ChangePrevious()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        skins[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter == -1)
            selectedCharacter = skins.Length - 1;

        skins[selectedCharacter].SetActive(true);
        if (characters[selectedCharacter].isUnlocked)
            PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        UpdateUI();
    }

    public void UpdateUI()
    {
        coinsText.text = "Coins: " + coins.ToString();
        nameText.text = characters[selectedCharacter].name;
        if (characters[selectedCharacter].isUnlocked == true)
            unlockButton.gameObject.SetActive(false);
        else
        {
            unlockButton.GetComponentInChildren<TextMeshProUGUI>().text = "Price:" + characters[selectedCharacter].price;
            if (coins < characters[selectedCharacter].price)
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = false;
            }
            else
            {
                unlockButton.gameObject.SetActive(true);
                unlockButton.interactable = true;
            }
        }
    }

    public void Unlock()
    {
        audioManager.PlayAudioClip(audioManager.CheckPoint);
        //connection.Open();
        int price = characters[selectedCharacter].price;
        if(coins < price)
        {
            Notification.SetActive(true);
        }
        coins -= price;
        string lenh = "UPDATE value SET Coins = '"+ coins +"' ";
        Connection.instance.command = new MySqlCommand(lenh, Connection.instance.conn);
        Connection.instance.command.ExecuteNonQuery();

        PlayerPrefs.SetInt(characters[selectedCharacter].name, 1);
        PlayerPrefs.SetInt("SelectedCharacter", selectedCharacter);
        characters[selectedCharacter].isUnlocked = true;
        UpdateUI();
    }
/*
    void CloseConnection()
    {
        if (connection != null && connection.State != ConnectionState.Closed)
            connection.Close();
    }*/
}


