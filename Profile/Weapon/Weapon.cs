using MySql.Data.MySqlClient;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public TextMeshProUGUI namew;
    public TextMeshProUGUI price;
    public TextMeshProUGUI atk;

    public int index;
    public Image icon;
    public weaponSO w;
    public int selectedWeapon;
    public GameObject note;
    public Button btnUnLock;
    public static Weapon instance;

    //private string connectionString = "Server = localhost ; port = 3307 ; Database = ninja_return ; User = root; Password = ; SslMode = none";
   // MySqlConnection conn;
    MySqlCommand command;
    //MySqlDataReader reader;
    int score ;

    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance == this) Destroy(gameObject);
        selectedWeapon = MainModel.currentWeapon;
        PlayerPrefs.GetInt("SelectedWeapon", selectedWeapon);
        
        if (w.price == 0) w.isUnlocked = true;
        else
        {
            w.isUnlocked = PlayerPrefs.GetInt(w.name, 0) == 0 ? false : true;
        }
        UpdateUI();
    }
    private void Start()
    {
        atk.text = "Atk: " + w.atk.ToString();
        icon.sprite = w.artWork;
    }

    private void FixedUpdate()
    {
        GetData();
        UpdateUI();
        //OpenConnection();
        //CloseConnection();
    }
    /*void OpenConnection()
    {
        if (connectionString == null) return;
        conn = new MySqlConnection(connectionString);
        conn.Open();
    }*/
    public void GetData()
    {
        if (WeaponSet.instance == null) return;
        score = WeaponSet.instance.score;
    }

    public void UpdateUI()
    {
        index = w.index;
        namew.text = w.namew;
        if (w.isUnlocked == true)
        {
            btnUnLock.gameObject.SetActive(false);
            btnUnLock.onClick.RemoveAllListeners();
        }
        else
        {
            price.text = "Price: " + w.price.ToString();
            if (score < w.price)
            {
                btnUnLock.gameObject.SetActive(true);
                btnUnLock.interactable = false;
            }
            else
            {
                btnUnLock.gameObject.SetActive(true);
                btnUnLock.interactable = true;
            }
        }
    }
    public void Unlock()
    {
        MainModel.UpdateWeapon(index); //tương đương SaveVuKhi()
        
        if(score < w.price)
        {

            note.SetActive(true);
        }
        else
        {
            score -= w.price;
            string lenh = "UPDATE value SET Coins = '" + score + "' ";
            command = new MySqlCommand(lenh, Connection.instance.conn);
            command.ExecuteNonQuery();
            //PlayerPrefs.SetInt("selectedWeapon", selectedWeapon);
            w.isUnlocked = true;
        }
        MainModel.UpdateWeapon(index);
        UpdateUI();
       // conn.Close();
    }
    /*public void SaveVuKhi()
    {
        //Debug.Log(index + "=============save data========");
        MainModel.UpdateWeapon(index);
        //PlayerPrefs.SetInt("SelectedWeapon", selectedWeapon);
    }*/

    /*void CloseConnection()
    {
        if (conn != null && conn.State != ConnectionState.Closed)
            conn.Close();
    }*/
}
