using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{
    [SerializeField] private float fadeDuration;

    [Header("Sprites")] [SerializeField] private Sprite blockedSprite;
    [SerializeField] private Sprite blockedEmptySprite;
    [SerializeField] private Sprite waterSprite1;
    [SerializeField] private Sprite waterSprite2;
    [SerializeField] private Sprite emptySprite;
    [SerializeField] private Vector3 spriteScale;
    [SerializeField] private bool isWater1;

    [SerializeField] private float waterFlowRate;
    private float _timer;

    [SerializeField] private SpriteRenderer _mySpriteRenderer;

    private bool isBlocked;
    private bool isEmpty;

    public enum SpriteType
    {
        EmptyHole,
        Hole,
        BlockedHole
    }
    
    void Start()
    {
        transform.localScale = spriteScale;
        isBlocked = false;
    }

    void Update()
    {
        if (_timer > waterFlowRate)
        {
            SwapSprite();
            _timer = 0f;
        }

        _timer += Time.deltaTime;
    }

    public void SetPosition(Vector2 pos)
    {
        transform.position = new Vector3(pos.x, pos.y, 0);
    }

    private void SwapSprite()
    {
        if (isBlocked || isEmpty)
        {
            return;
        }
        if (isWater1)
        {
            _mySpriteRenderer.sprite = waterSprite2;
            isWater1 = !isWater1;
        }
        else
        {
            _mySpriteRenderer.sprite = waterSprite1;
            isWater1 = !isWater1;
        }
    }

    public void DestroyWithAnimation()
    {
        isBlocked = true;
        GameObject.Find("HoleManager").GetComponent<HoleManager>().holes.Remove(gameObject);
        ChangeSprite(SpriteType.BlockedHole);
        StartCoroutine(FadeAnimation());
    }

    public void ChangeSprite(SpriteType type)
    {
        Sprite newSprite = null;
        switch (type)
        {
            case SpriteType.Hole:
                newSprite = waterSprite1;
                break;
            case SpriteType.BlockedHole:
                if (isEmpty)
                {
                    newSprite = blockedEmptySprite;
                }
                else
                {
                    newSprite = blockedSprite;   
                }
                break;
            case SpriteType.EmptyHole:
                newSprite = emptySprite;
                break;
        }

        if (newSprite)
        {
            _mySpriteRenderer.sprite = newSprite;   
        }
    }

    public void SetEmpty(bool empty)
    {
        isEmpty = empty;
    }

    IEnumerator FadeAnimation()
    {
        float time = 0f;
        Color tmp;

        while (time < fadeDuration)
        {
            tmp = _mySpriteRenderer.color;
            tmp.a = 1 - time/fadeDuration;
            _mySpriteRenderer.color = tmp;
            time += Time.deltaTime;
            yield return null;
        }
    }
}