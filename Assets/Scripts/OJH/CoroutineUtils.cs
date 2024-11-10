using System;
using System.Collections;
using UnityEngine;

public static class CoroutineUtils {

    /// <summary>
    /// provides a util to easily control the timing of a lerp over a duration
    /// </summary>
    /// <param name="duration">How long our lerp will take</param>
    /// <param name="action">The action to perform per frame of the lerp, is given the progress t in [0,1]</param>
    public static IEnumerator Lerp(float duration, Action<float> action) {
        float time = 0;
        while (time < duration) {
            float delta = Time.deltaTime;
            float t = (time + delta > duration) ? 1 : (time / duration);
            action(t);
            time += delta;
            yield return null;
        }
        // handle the last frame
        action(1);
    }
}
