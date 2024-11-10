using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackButton : MonoBehaviour
{
    public void Click()
    {
        Debug.Log("Resume");
        GameObject.Find("PauseMenu").GetComponent<PauseMenu>().Resume();
    }
}
