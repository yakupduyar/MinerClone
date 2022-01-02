using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        Application.targetFrameRate = Screen.currentResolution.refreshRate;
    }

}
