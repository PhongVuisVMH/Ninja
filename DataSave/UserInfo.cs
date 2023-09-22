using TMPro;
using UnityEngine;

public class UserInfo : MonoBehaviour
{
    public TextMeshProUGUI level;
    public TextMeshProUGUI Score;
    public TextMeshProUGUI kill;
    public void Init(int id, int levelInit, int scoreInit, int killInit)
    {
        level.text ="Level: " + levelInit.ToString();
        Score.text ="Score: " + scoreInit.ToString();
        kill.text ="Kill: " + killInit.ToString();
    }
}
