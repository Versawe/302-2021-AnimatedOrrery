using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    private bool isPaused = false;
    public Slider slide;
    public static float sliderControl;

    private void Awake()
    {
        sliderControl = slide.value;
    }

    private void Update()
    {
        print(sliderControl);
    }
    public void pauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0f;
            isPaused = true;
        }
        else if (isPaused)
        {
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    public void slideChangeValue()
    {
        sliderControl = slide.value;
    }
}
