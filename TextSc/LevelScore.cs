using TMPro;
using UnityEngine;

public class LevelScore : MonoBehaviour
{
    TextMeshProUGUI level;
    void Awake()
    {
        Saving save = new Saving();
        level.text = "Level: " + save.level;
    }
}
