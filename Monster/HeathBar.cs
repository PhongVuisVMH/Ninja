using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    public Slider slider;
   public void UpdateHeathBar(float currentValue, float maxValue)
    {
        slider.value = currentValue / maxValue;
    }
   
}
