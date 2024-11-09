using UnityEngine;
using System.Collections;

public class RandomPot : MonoBehaviour {
    [SerializeField] private Transform center;
    [SerializeField] private float radius = 0;
    [SerializeField] private GameObject checkingStar;
    [SerializeField] private GameObject checkingCircle;
    
    
    // Start is called before the first frame update
    void Start() {
        
    }

    private void drawPositionArray(Vector2[] arr) {
        for (int i = 0; i < arr.Length; i++) {
            Instantiate(checkingCircle, arr[i], Quaternion.identity);
        }
    }

    private Vector2 dropZVector2(Vector3 vec3) {
        return new Vector2(vec3.x, vec3.y);
    }
    
    public Vector2 GetRandomInnerPosition() {
        Vector2 find = dropZVector2(center.position) + Random.insideUnitCircle * radius;
        return find;
    }
    
    

// Update is called once per frame
    void Update()
    {
        
    }
}
