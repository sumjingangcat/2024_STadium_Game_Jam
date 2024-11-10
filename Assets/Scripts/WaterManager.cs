using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WaterManager : MonoBehaviour
{
    public Image waterBar;

    private HoleManager holeManager;
    [SerializeField] private float inputWater = 0.005f;
    [SerializeField] private float waterLossPerHole = 0.005f;

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
        waterBar.fillAmount += inputWater * Time.deltaTime;

        if (waterBar.fillAmount > 0) { waterBar.fillAmount -= holeManager.activeHoles.Count * waterLossPerHole * Time.deltaTime; }
        else { Debug.Log("Zero"); }
    }
}
