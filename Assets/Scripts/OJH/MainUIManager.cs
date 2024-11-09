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
    
    // void Awake()
    // {
    //     DontDestroyOnLoad(transform.gameObject);
    // }

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
