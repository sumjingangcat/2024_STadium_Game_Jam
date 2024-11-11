using System;
using System.Collections;
using System.Collections.Generic;
using Spear;
using UnityEngine;
using UnityEngine.Serialization;

public class CursorController : MonoBehaviour
{ 
    [SerializeField] private HoleManager holeManager;
    [SerializeField] private float clickDistanceThreshold;

    [SerializeField] private Texture2D cursorTexture1;
    [SerializeField] private Texture2D cursorTexture2;
    
    [SerializeField] private Texture2D cursorTextureWeb1;
    [SerializeField] private Texture2D cursorTextureWeb2;

    [SerializeField] private int textureWebSize = 16;
    [SerializeField] private int textureWindowSize = 64;

    [SerializeField] private float cursorUpdateRate;
    [SerializeField] private Vector2 offsetWindow;
    [SerializeField] private Vector2 offsetWeb;
    private float _time;
    private bool _toggleCursor;
    
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !PauseMenu.isPaused)
        {
            // left click
            float minDis = -1f;
            GameObject closestHole = null;

            // find closest hole from cursor
            for (int i = 0; i < holeManager.holes.Count; i++)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                    Camera.main.nearClipPlane));
                Vector3 holePos = holeManager.holes[i].transform.position;
                float dis = Vector2.Distance(new Vector2(holePos.x, holePos.y), new Vector2(mousePos.x, mousePos.y));
                if (dis < minDis || minDis == -1f)
                {
                    minDis = dis;
                    closestHole = holeManager.holes[i];
                }
            }
            
            // Destroy closest hole from cursor
            if (closestHole && minDis < clickDistanceThreshold)
            {
                closestHole.GetComponent<HoleController>().DestroyWithAnimation();
                SoundManager.Instance.PlaySoundQueue("frog-sound", true);
            }
        }
        if (_time > cursorUpdateRate)
        {
            SwapCursor();
            _time = 0f;
        }

        _time += Time.deltaTime;
    }

    private void SwapCursor()
    {
        if (_toggleCursor)
        {
#if UNITY_WEBGL
            Cursor.SetCursor(cursorTextureWeb2, offsetWeb, CursorMode.ForceSoftware);
#else
            Cursor.SetCursor(cursorTexture2, offsetWindow, CursorMode.Auto);
#endif
            _toggleCursor = !_toggleCursor;
        }
        else
        {
#if UNITY_WEBGL
            Cursor.SetCursor(cursorTextureWeb1, offsetWeb, CursorMode.ForceSoftware);
#else
            Cursor.SetCursor(cursorTexture1, offsetWindow, CursorMode.Auto);
#endif
            _toggleCursor = !_toggleCursor;
        }
    }

    private void Start()
    {
#if UNITY_WEBGL
        // cursorTexture1.Reinitialize(textureWebSize, textureWebSize);
        // cursorTexture2.Reinitialize(textureWebSize, textureWebSize);
        Cursor.SetCursor(cursorTextureWeb1, Vector2.zero, CursorMode.ForceSoftware);
#else
        // cursorTexture1.Reinitialize(textureWindowSize, textureWindowSize);
        // cursorTexture2.Reinitialize(textureWindowSize, textureWindowSize);
        Cursor.SetCursor(cursorTexture1, UnityEngine.Vector2.zero, CursorMode.Auto);
#endif
    }
}
