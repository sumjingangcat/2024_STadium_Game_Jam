using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundManager : MonoBehaviour {
    [SerializeField] private SpriteRenderer[] backgrounds;

    public IEnumerator OverlapBackground(float totalTime) {
        float dividedTime = totalTime / 2;
        yield return new WaitForSeconds(dividedTime);
        
        backgrounds[1].gameObject.SetActive(true);
        StartCoroutine(smoothAlphaRender(backgrounds[1], dividedTime/2, 0, 1));
        yield return new WaitForSeconds(dividedTime/2);
        
        backgrounds[2].gameObject.SetActive(true);
        StartCoroutine(smoothAlphaRender(backgrounds[2], dividedTime/2, 0, 1));
    }
    
    private IEnumerator smoothAlphaRender(SpriteRenderer sr, float duration, float fromA, float toA) {
        yield return CoroutineUtils.Lerp(duration, t => {
            sr.color = Color.Lerp(new Color(1, 1, 1, fromA), new Color(1, 1, 1, toA), t);
        });
    }
}
