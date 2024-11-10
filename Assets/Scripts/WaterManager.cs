using System.Collections;
using System.Collections.Generic;
using Spear;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WaterManager : MonoBehaviour
{
    public Image waterBar;

    private HoleManager holeManager;
    [SerializeField] private float inputWater = 0.005f;
    [SerializeField] private float waterLossPerHole = 0.005f;
    [SerializeField] private float initialWaterAmount = 0f;

    private bool waterSoundStartFlag = false;
    private bool waterSoundEndFlag = true;
    private string waterFlowSEName = "running-stream-water-sound";
    private float waterFlowSoundVolume = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        holeManager = FindObjectOfType<HoleManager>();
        waterBar.fillAmount = initialWaterAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PauseMenu.isPaused)
        {
            updateWaterBar();
            updateWaterFlowSound(holeManager.activeHoles.Count);
        }
    }

    private void updateWaterBar()
    {
        waterBar.fillAmount += inputWater * Time.deltaTime;

        if (waterBar.fillAmount > 0) {
            float waterLoss = holeManager.activeHoles.Count * waterLossPerHole;
            waterBar.fillAmount -= waterLoss * Time.deltaTime;
        }
        else { Debug.Log("Zero"); }
    }

    private void updateWaterFlowSound(float activeHolesCount)
    {
        if (activeHolesCount > 0) {
            if (waterSoundEndFlag) {
                waterSoundStartFlag = true;
                waterSoundEndFlag = false;
            }
        }
        else {
            SoundManager.Instance.StopSoundQueue(waterFlowSEName);
            waterSoundEndFlag = true;
        }
        
        if (waterSoundStartFlag)
        {
            SoundManager.Instance.PlaySoundQueue(waterFlowSEName, false, activeHolesCount * waterFlowSoundVolume);
            waterSoundStartFlag = false;
        }
    }
}
