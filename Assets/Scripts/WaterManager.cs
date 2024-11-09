using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterManager : MonoBehaviour
{
    public Image waterBar;

    private HoleManager holeManager;
    private float inputWater = 0.005f;
    private float holeWater = 0.005f;

    // Start is called before the first frame update
    void Start()
    {
        holeManager = FindObjectOfType<HoleManager>();
        waterBar.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            updateWaterBar();
        }
    }

    private void updateWaterBar()
    {
        waterBar.fillAmount += inputWater;

        if (waterBar.fillAmount > 0) { waterBar.fillAmount -= holeManager.holes.Count * holeWater; }
        else { Debug.Log("Zero"); }
    }
}
