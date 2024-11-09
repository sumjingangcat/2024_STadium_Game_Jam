using UnityEngine;
using System.Collections;

public class RandomPot : MonoBehaviour {
    [SerializeField] private PolygonCollider2D col2D;
    [SerializeField] private float[] rndLerpRate;
    [SerializeField] private GameObject checkingStar;
    [SerializeField] private GameObject checkingCircle;
    
    private int maxVertices = -1;
    private Vector2[] colVerticies;
    
    
    // Start is called before the first frame update
    void Start() {
        maxVertices = col2D.points.Length;
        colVerticies = col2D.points;
        /*Debug.Log($"col2D : {maxVertices}");
        for (int i = 0; i < maxVertices; i++) {
            GetRandomInnerPosition();
        }*/
        
        // drawPositionArray(col2D.points);
    }

    private void drawPositionArray(Vector2[] arr) {
        for (int i = 0; i < arr.Length; i++) {
            Instantiate(checkingCircle, arr[i], Quaternion.identity);
        }
    }
    
    public Vector2 GetRandomInnerPosition() {
        int rnd_num = Random.Range(0, maxVertices);
        
        Vector2 start = colVerticies[rnd_num];
        Vector2 end = colVerticies[(rnd_num + maxVertices / 3) % maxVertices];

        float find_rate = rndLerpRate[rnd_num % rndLerpRate.Length];
        Vector2 find = start + (end - start) * find_rate;

        Vector2 find_in_circle = find + Random.insideUnitCircle;
        
        // Debug Section
        /*Debug.Log($"rnd_num : {rnd_num}, rate : {find_rate}, find position : {find}");
        Instantiate(checkingStar, find, Quaternion.identity);*/
        
        return find;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
