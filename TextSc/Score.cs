using UnityEngine;

public class Score : MonoBehaviour
{
    public void Update()
    {
        if (GameManager.Instance == null) return;
        
        else 
        {
            GameManager.Instance.Scored();
        }
    }
}
