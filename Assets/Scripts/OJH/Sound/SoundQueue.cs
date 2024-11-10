using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spear
{
    public class SoundQueue : MonoBehaviour
    {
        int _next = 0;
        [SerializeField] List<AudioSource> audioSources = new();

        public int Count { get; set; } = 1;

        public void Awake()
        {
            // for (int i = 0; i < Count; i++)
            // {
            //     AudioSource duplicate = Instantiate(audioSource, transform);
            //     audioSources.Add(duplicate);
            // }
        }

        public void PlaySound(float volume, bool reset = false)
        {
            if (reset) {
                audioSources[_next].Stop();
                audioSources[_next].time = 0f;
            }
            
            if (!audioSources[_next].isPlaying) {
                audioSources[_next].volume = volume;
                // Play
                audioSources[_next].Play();
                _next = (_next + 1) % audioSources.Count;
            }
        }

    } //SoundQueue End
}
