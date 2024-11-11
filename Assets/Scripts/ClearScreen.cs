using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearScreen : MonoBehaviour {
    [SerializeField] private float screenTime = 2f;
    
    private bool isScreenSaved = true;

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(screenSavingTime(screenTime));
    }

    // Update is called once per frame
    void Update()
    {
        if (!isScreenSaved) {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("StartScene");
            }
        }
    }

    private IEnumerator screenSavingTime(float duration) {
        yield return new WaitForSeconds(duration);
        isScreenSaved = false;
    }
}
