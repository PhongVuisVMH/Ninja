using UnityEngine;

public class ThongBao : MonoBehaviour
{
    public GameObject buyPanel;
    public GameObject Notification;
    public GameObject Notification1;
    public void Yesbutton()
    {
        buyPanel.SetActive(true);
        Notification.SetActive(false);
        Notification1.SetActive(false);
    }
    public void Nobutton()
    {
        Notification.SetActive(false);
        Notification1.SetActive(false);
    }public void Yesbutton1()
    {
        buyPanel.SetActive(true);
        Notification1.SetActive(false);
    }
    public void Nobutton1()
    {
        Notification1.SetActive(false);
    }
}
