using UnityEngine;

public class KillCount : MonoBehaviour
{
    void FixedUpdate()
    {
        if (GameManager.Instance == null)
        {
            return;
        }
        else
        {
            GameManager.Instance.Killed();
        }
        
    }
}

