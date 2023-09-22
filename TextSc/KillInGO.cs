
using TMPro;
using UnityEngine;

public class KillInGO : MonoBehaviour
{
    TextMeshProUGUI killtext;
    private KillCount kill;
    GameManager gm;
    private void Start()
    {
        killtext = GetComponent<TextMeshProUGUI>();
        kill = FindObjectOfType<KillCount>();
    }
    private void Update()
    {
        if (kill == null)
        {
            return;
        }
        else
        {
            if (gm.kill == 0)
            {
                return;
            }
            else killtext.text = "Kill: " + gm.kill;
        }
    }
}
