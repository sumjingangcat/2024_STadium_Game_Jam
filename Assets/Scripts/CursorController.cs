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
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
    }
}
