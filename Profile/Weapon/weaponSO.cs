using UnityEngine;

[CreateAssetMenu(fileName ="New Weapon", menuName ="WeaponSO/weapons")]
public class weaponSO : ScriptableObject
{
    public Sprite artWork;
    public string namew;
    public int price;
    public int atk;
    public bool isUnlocked;
    public int index;
}
