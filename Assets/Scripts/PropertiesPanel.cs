using UnityEngine;

public class PropertiesPanel : MonoBehaviour
{
    private const int StopTimeValue = 0;
    private const int StartTimeValue = 1;
    
    private void OnEnable()
    {
        Time.timeScale = StopTimeValue;
    }

    private void OnDisable()
    {
        Time.timeScale = StartTimeValue;
    }
}
