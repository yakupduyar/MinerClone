using System;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI fps;
    void Update()
    {
        fps.text = "FPS: " + (1 / Time.unscaledDeltaTime).ToString("F1");
    }
    

}
