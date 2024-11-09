using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class HoleManager : MonoBehaviour
{
    [SerializeField] private RandomPot potObject;
    public List<GameObject> holes;

    public float maximumTime;
    public float minimumTime;
    private float _timer;
    private float _time;
    
    [SerializeField] private GameObject holeObject;

    private void CreateHole()
    {
        Vector2 holePos = potObject.GetRandomInnerPosition();
        GameObject newHole = Instantiate(holeObject, transform);
        newHole.GetComponent<IHole>().SetPosition(holePos);
        if (newHole.transform.position.x < potObject.transform.position.x)
        {
            newHole.GetComponent<SpriteRenderer>().flipX = true;
        }
        holes.Add(newHole);
        newHole.SetActive(true);
    }

    private void Start()
    {
        _timer = 1f;
    }

    private void Update()
    {
        if (_time > _timer)
        {
            CreateHole();
            _timer = Random.Range(minimumTime, maximumTime);
            _time = 0f;
        }

        _time += Time.deltaTime;
    }
}
