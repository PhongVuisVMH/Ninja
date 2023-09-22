using UnityEngine;
using UnityEngine.UI;

public class TimeCD : MonoBehaviour
{
    public Image defaultSkill;
    public float cooldown = 5f;
    bool isCoolDown = false;
    public KeyCode CDKey;

    void Start()
    {
        defaultSkill.fillAmount = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        DFSkill();
    }

    public void DFSkill()
    {
        if(Input.GetKey(CDKey) && isCoolDown == false ) 
        {
            isCoolDown = true;
            defaultSkill.fillAmount = 1;
        }

        if(isCoolDown)
        {
            defaultSkill.fillAmount -=1 / cooldown * Time.deltaTime;
            if(defaultSkill.fillAmount <= 0 )
            {
                defaultSkill.fillAmount = 0;
                isCoolDown=false;
            }
        }
    }
}
