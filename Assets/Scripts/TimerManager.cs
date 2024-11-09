using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Slider timerSlider;

    private float stageTime = 60.0f;


    // Start is called before the first frame update
    void Start()
    {
        timerSlider = GetComponent<Slider>();
        timerSlider.maxValue = stageTime;
        timerSlider.value = timerSlider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerSlider.value > 0) { timerSlider.value -= Time.deltaTime; }
        else { Debug.Log("Zero"); }
    }
}
