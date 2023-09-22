using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public List<GameObject> listWeapon = new List<GameObject>();
    public static bool canshoot = false;
    public GameObject weapon;
    public float lastshot;
    private float Cooldown = 1f;
    AudioManager manager;
    private void OnEnable()// moi lan mo len thi se capnhat -> thang nay khi mo len la auto goi
    {
        //Debug.Log(MainModel.currentWeapon + "=========================");
        manager = GameObject.FindGameObjectWithTag("audio").GetComponent<AudioManager>();
        /*
         * int indexweapon = PlayerPrefs.GetInt("SelectedWeapons", 0);
        weapon = weapons[indexweapon];*/
        //
        if (MainModel.currentWeapon > 0 && MainModel.currentWeapon < listWeapon.Count)// kiem tra vu khi khac mac dinh va vu khi nam trong list weapon
        {
            weapon = listWeapon[MainModel.currentWeapon]; // gan vu khi da thay doi
        }
    }

    /*private void Start()// cai nay sai dc 1 lan khi script va object enable
    {
        spawn();
    }*/
    void Update()
    {
        
        float T = Time.time -lastshot;
        if (T < Cooldown) return;
        
        else if (Input.GetKeyDown(KeyCode.E) && canshoot == true )
        {
            /*GameObject obj =  */Instantiate(weapon, transform.position, transform.rotation);
            lastshot = Time.time;
            manager.PlayAudioClip(manager.Shoot);
            //Debug.Log("Shoot =============================");
        }
    }

    /*
    private void spawn()
    {
        GameObject obj = Instantiate(weapon);
        obj.transform.position = transform.position;
        obj.transform.SetParent(transform.parent.parent, false);
        //obj.SetActive(true);
        Debug.Log("Shoot =============================");
    } */   

}
