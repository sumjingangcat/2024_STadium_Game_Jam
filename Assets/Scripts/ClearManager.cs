using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearManager : MonoBehaviour
{
    [SerializeField] private float clearWaterAmount;
    [SerializeField] private WaterManager waterManager;
    
    public void CheckClear()
    {
        if (waterManager.waterBar.fillAmount >= clearWaterAmount)
        {
            SceneManager.LoadScene("ClearScene");
        }
        else
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
