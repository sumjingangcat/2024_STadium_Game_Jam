using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIManager : MonoBehaviour {
    // public static MainUIManager Instance { get; } = new();
    // private MainUIManager() {}

    [SerializeField] private string mainSceneName;
    [SerializeField] private GameObject developerCut;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    public void GameStart() {
        SceneManager.LoadScene(mainSceneName);
    }

    public void OpenCredit() {
        developerCut.SetActive(true);
    }

    public void CloseCredit() {
        developerCut.SetActive(false);
    }
}
