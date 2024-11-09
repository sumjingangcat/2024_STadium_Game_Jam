using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Image timerBar;

    private float totalTime = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        timerBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerBar.fillAmount < 1) { timerBar.fillAmount += Time.deltaTime / totalTime; }
        else { Debug.Log("Zero"); }
    }
}
