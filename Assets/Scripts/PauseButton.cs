using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public void Click()
    {
        GameObject.FindObjectOfType<PauseMenu>().Pause();
    }
}
