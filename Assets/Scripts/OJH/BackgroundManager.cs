using System;
using System.Collections;
using System.Collections.Generic;
using Spear;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour {
    [SerializeField] private SpriteRenderer[] backgrounds;
    [SerializeField] private SpriteRenderer sun;
    [SerializeField] private SpriteRenderer moon;
    [SerializeField] private float rotationRadius = 600f;
    [SerializeField] private Vector3 rotationCenterOffset;
    [SerializeField] private float rotationStartAngle = 60f;
    [SerializeField] private float rotationEndAngle = 120f;

    [SerializeField] private TimerManager timerManager;

    private float sunAngle = 0f;
    private float moonAngle = 0f;

    private float dividedTime;
    private float sunTime = 0f;
    private float moonTime = 0f;

    private bool changeFlag = false;

    private void Start() {
        sunAngle = rotationStartAngle;
        moonAngle = rotationStartAngle;

        dividedTime = timerManager.TotalTime / 2;
        
        SoundManager.Instance.PlayBGM("chicken");
    }
    
    public IEnumerator OverlapBackground(float totalTime) {
        float dividedTime = totalTime * 0.5f;
        yield return new WaitForSeconds(dividedTime * 0.5f);
        
        backgrounds[1].gameObject.SetActive(true);
        StartCoroutine(smoothAlphaRender(backgrounds[1], dividedTime * 0.35f, 0, 1));
        yield return new WaitForSeconds(dividedTime * 0.35f);
        
        backgrounds[2].gameObject.SetActive(true);
        StartCoroutine(smoothAlphaRender(backgrounds[2], dividedTime * 0.25f, 0, 1));
        yield return new WaitForSeconds(dividedTime * 0.25f);
        SoundManager.Instance.PlayBGM("cricket");
    }
    
    private IEnumerator smoothAlphaRender(SpriteRenderer sr, float duration, float fromA, float toA) {
        yield return CoroutineUtils.Lerp(duration, t => {
            sr.color = Color.Lerp(new Color(1, 1, 1, fromA), new Color(1, 1, 1, toA), t);
        });
    }

    private void Update() {
        if (!changeFlag) {
            sun.gameObject.SetActive(true);
            moon.gameObject.SetActive(false);
            Transform trSun = sun.transform;
            trSun.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, rotationStartAngle), Quaternion.Euler(0, 0, rotationEndAngle), sunTime / dividedTime);
            trSun.position = rotationCenterOffset + trSun.up * rotationRadius;
            
            sunTime += Time.deltaTime;
            if (sunTime > dividedTime) {
                changeFlag = true;
            }
        }
        else {
            sun.gameObject.SetActive(false);
            moon.gameObject.SetActive(true);
            Transform trMoon = moon.transform;
            trMoon.rotation = Quaternion.Lerp(Quaternion.Euler(0, 0, rotationStartAngle), Quaternion.Euler(0, 0, rotationEndAngle), moonTime / dividedTime);
            trMoon.position = rotationCenterOffset + trMoon.up * rotationRadius;
            moonTime += Time.deltaTime;
        }
    }
}
