using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainButton : MonoBehaviour
{
    public void Click()
    {
        Debug.Log("Load StartScene");
        SceneManager.LoadScene("StartScene");
    }
}
