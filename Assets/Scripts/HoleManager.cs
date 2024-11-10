using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class HoleManager : MonoBehaviour
{
    [SerializeField] private RandomPot potObject;
    [SerializeField] private WaterManager waterManager;
    public List<GameObject> holes;
    public List<GameObject> activeHoles;

    public float maximumTime;
    public float minimumTime;
    [SerializeField] private float validateRate;
    private float _timer;
    private float _time;
    private float _validateTime;
    
    [SerializeField] private GameObject holeObject;

    private void CreateHole()
    {
        Vector2 holePos = potObject.GetRandomInnerPosition();
        GameObject newHole = Instantiate(holeObject, transform);
        newHole.GetComponent<HoleController>().SetPosition(holePos);
        if (newHole.transform.position.x < potObject.transform.position.x)
        {
            newHole.GetComponent<SpriteRenderer>().flipX = true;
        }
        holes.Add(newHole);
        ValidateHoles();
        newHole.SetActive(true);
    }

    private void ValidateHoles()
    {
        activeHoles.Clear();
        for (int i = 0; i < holes.Count; i++)
        {
            if (holes[i].transform.position.y <= waterManager.waterBar.fillAmount * potObject.GetComponent<SpriteRenderer>().bounds.size.y + potObject.transform.position.y - potObject.GetComponent<SpriteRenderer>().bounds.size.y / 2)
            {
                holes[i].GetComponent<HoleController>().SetEmpty(false);
                holes[i].GetComponent<HoleController>().ChangeSprite(HoleController.SpriteType.Hole);
                activeHoles.Add(holes[i]);
            }
            else
            {
                holes[i].GetComponent<HoleController>().SetEmpty(true);
                holes[i].GetComponent<HoleController>().ChangeSprite(HoleController.SpriteType.EmptyHole);
            }
        }
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

        if (_validateTime > validateRate)
        {
            ValidateHoles();
            _validateTime = 0f;
        }
        
        _time += Time.deltaTime;
        _validateTime += Time.deltaTime;
    }
}
