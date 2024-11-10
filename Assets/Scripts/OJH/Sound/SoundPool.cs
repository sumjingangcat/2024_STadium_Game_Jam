using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Spear
{
    public class SoundPool : MonoBehaviour
    {
        private List<SoundQueue> soundQueues = new();
        //private int lastIndex = -1;

        public void Awake()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                SoundQueue soundQueue = transform.GetChild(i).GetComponent<SoundQueue>();
                if (soundQueue != null)
                {
                    soundQueues.Add(soundQueue);
                }
            }
        }

        public void PlayRandomSound(float volume)
        {
            int index = Random.Range(0, soundQueues.Count);
            soundQueues[index].PlaySound(volume, true);
        }

    } //SoundPool End
}
