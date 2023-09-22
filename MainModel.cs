using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainModel : MonoBehaviour
{
    /// <summary>
    ///  ben nay tat ca du lieu thay doi thi nen bo 1 ben rieng -> neu can luu
    ///  Data gom coin, weapon, health,....
    /// </summary>
    public static int currentWeapon { get; private set; }
    private void Awake() // load du lieu khi awake
    {
        LoadData();
    }
    public void LoadData()
    {
        currentWeapon = PlayerPrefs.GetInt("SelectedWeapon", 1); // load du lieu vu khi nao
    }
    public static void SaveData() // save vu khi
    {
        PlayerPrefs.SetInt("SelectedWeapon", currentWeapon);
        PlayerPrefs.Save();
    }
    public static void UpdateWeapon(int index) // cap nhat vu khu da thay doi va save
    {
        if (index == currentWeapon) return;
        currentWeapon = index;
        SaveData();
    }
}
