using TMPro;
using UnityEngine;

public class UsernameShow : MonoBehaviour
{
    public TextMeshProUGUI username;
    private void OnEnable()
    {
        username.text = SaveScene_Level.instance.currentUserName;
    }
}
