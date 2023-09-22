using UnityEngine;

public class avatarSet : MonoBehaviour
{
    public GameObject[] Avatars;
    public int selectedAvt;

    private void Awake()
    {
        selectedAvt = PlayerPrefs.GetInt("SavedAvatar", 0);
        foreach (GameObject avatar in Avatars)
        {
            avatar.SetActive(false);
        }

        Avatars[selectedAvt].SetActive(true);
    }
 public void ChangeAvatar()
    {
        Avatars[selectedAvt].SetActive(false);
        selectedAvt++;
        if (selectedAvt == Avatars.Length)
            selectedAvt = 0;

        Avatars[selectedAvt].SetActive(true);
        SaveAvatar();
    }
    public void SaveAvatar()
    {
        PlayerPrefs.SetInt("SavedAvatar", selectedAvt);
    }
}

