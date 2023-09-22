using TMPro;
using UnityEngine;

public class ScoreInGO : MonoBehaviour
{
    TextMeshProUGUI scoretext;
    private Score score;
    GameManager gm;
    void Start()
    {
        score = FindObjectOfType<Score>();
    }
    void Update()
    {
        if(score == null) return;
        
        else
        {
            if (gm.Scores == 0) return;
            else scoretext.text = "Score: " + gm.Scores;
        }
        
    }
}
