using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Vector2 = System.Numerics.Vector2;

public class CursorController : MonoBehaviour
{ 
    [SerializeField] private HoleManager holeManager;
    [SerializeField] private float clickDistanceThreshold;

    [SerializeField] private Sprite cursorSprite1;
    [SerializeField] private Sprite cursorSprite2;

    [SerializeField] private float cursorUpdateRate;
    [SerializeField] private UnityEngine.Vector2 offset;
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
            
            Debug.Log("minDis: " + minDis);
            // Destroy closest hole from cursor
            if (closestHole && minDis < clickDistanceThreshold)
            {
                closestHole.GetComponent<HoleController>().DestroyWithAnimation();
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
            Cursor.SetCursor(cursorSprite2.texture, offset, CursorMode.Auto);
            _toggleCursor = !_toggleCursor;
        }
        else
        {
            Cursor.SetCursor(cursorSprite1.texture, offset, CursorMode.Auto);
            _toggleCursor = !_toggleCursor;
        }
    }

    private void Start()
    {
        Cursor.SetCursor(cursorSprite1.texture, UnityEngine.Vector2.zero, CursorMode.Auto);
    }
}
