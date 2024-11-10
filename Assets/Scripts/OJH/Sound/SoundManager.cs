using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Spear
{
    public class SoundManager : Singleton<SoundManager> {
        [SerializeField] private List<AudioSource> backgroundMusicList = new();
        [SerializeField] private List<SoundQueue> soundQueueList = new();
        [SerializeField] private List<SoundPool> soundPoolList = new();
        
        Dictionary<string, SoundQueue> soundQueuesByName = new();
        Dictionary<string, SoundPool> soundPoolsByName = new();

        private Dictionary<string, AudioSource> backgroundMusicSources = new();

        private int prevIndex = -1;
        
        public void Awake()
        {
            foreach (var sq in soundQueueList) {
                soundQueuesByName[sq.name] = sq;
            }

            foreach (var sp in soundPoolList) {
                soundPoolsByName[sp.name] = sp;
            }
            
            foreach (var a in backgroundMusicList) {
                backgroundMusicSources[a.name] = a;
            }
        }

        public void PlaySoundQueue(string name, bool reset = false, float volume = 1f)
        {
            if (soundQueuesByName.TryGetValue(name, out SoundQueue soundQueue))
            {
                soundQueue.PlaySound(volume, reset);
            }
            else
            {
                Debug.Log($"SoundQueue {name} not found!");
            }
        }

        public void PlaySoundPool(string name, float volume = 1f) {
            if (soundPoolsByName.TryGetValue(name, out SoundPool soundPool))
            {
                soundPool.PlayRandomSound(volume);
            }
            else
            {
                Debug.Log($"SoundPool {name} not found!");
            }
        }

        public void PlayBackGround(int index) {
            if (index < backgroundMusicList.Count) {
                backgroundMusicList[index].Play();
                
                if (prevIndex != -1) {
                    backgroundMusicList[prevIndex].Stop();
                }
                
                prevIndex = index; // Cache prevIndex
            }
        }

        public void PlayBGM(string audioName, bool isLoop = false) {
            if (backgroundMusicSources.TryGetValue(audioName, out AudioSource a)) {
                a.loop = isLoop;
                a.Play();
            }
        }
        
        public void StopBGM(string audioName) {
            if (backgroundMusicSources.TryGetValue(audioName, out AudioSource a)) {
                a.Stop();
            }
        }

        public void SetBGMSetting(string audioName, float volume = 1f, float pitch = 1f) {
            if (backgroundMusicSources.TryGetValue(audioName, out AudioSource a)) {
                a.volume = volume;
                a.pitch = pitch;
            }
        }

    } //SoundManager End
}
