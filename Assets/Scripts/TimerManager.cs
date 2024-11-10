using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public Image timerBar;

    [SerializeField] public float TotalTime = 60.0f;

    [SerializeField] private HoleManager holeManager;
    [SerializeField] private BackgroundManager backgroundManager;

    [SerializeField] private float decayRate;
    [SerializeField] private float updateRate;
    [SerializeField] private float minimumThreshold;

    // Start is called before the first frame update
    void Start()
    {
        timerBar.fillAmount = 0;
        StartCoroutine(UpdateSpawnRate());
        StartCoroutine(backgroundManager.OverlapBackground(TotalTime));
        // StartCoroutine(backgroundManager.OverlapSunMoon(totalTime));
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        if (timerBar.fillAmount < 1) { timerBar.fillAmount += Time.deltaTime / TotalTime; }
        else { GameObject.FindObjectOfType<ClearManager>().CheckClear(); }
    }

    private IEnumerator UpdateSpawnRate()
    {
        // replace true with flag
        while (true)
        {
            if (holeManager.minimumTime > minimumThreshold)
            {
                holeManager.minimumTime *= decayRate;
                holeManager.maximumTime *= decayRate;
            }
            yield return new WaitForSeconds(updateRate);
        }
    }
}
